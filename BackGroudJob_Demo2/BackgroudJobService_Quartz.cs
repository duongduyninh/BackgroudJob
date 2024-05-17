using BackGroudJob_Demo2.Data;
using BackGroudJob_Demo2.Data.Models;
using CsvHelper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Quartz;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.Json;
using JsonException = Newtonsoft.Json.JsonException;


namespace BackGroudJob_Demo2
{
    public class BackgroudJobService_Quartz : IJob
    {
        private readonly ILogger<BackgroundJobService> _logger;
        private readonly Dbcontext_User _context;
        private readonly HttpClient _httpClient = new HttpClient();


        public BackgroudJobService_Quartz(ILogger<BackgroundJobService> logger,
                                          Dbcontext_User context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Execute(IJobExecutionContext t)
        {
            try
            {
                _logger.LogInformation("Start");

                var usersResponse = await _httpClient.GetAsync("https://localhost:7156/api/User");
                usersResponse.EnsureSuccessStatusCode();

                var usersResponseContent = await usersResponse.Content.ReadAsStringAsync();
              
                if (string.IsNullOrWhiteSpace(usersResponseContent))
                {
                    _logger.LogInformation("User null");
                }

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                };

                var userInfoResponse = JsonConvert.DeserializeObject<UserInfoResponse>(usersResponseContent, settings);

                List<UserInfo> usersStatus1 = userInfoResponse.UserInfos.Where(x => x.Status == 1).ToList();
                List<UserInfo> usersStatus0 = userInfoResponse.UserInfos.Where(x => x.Status == 0).ToList();

                var firtFileName = "namefile";
                var fileExtension = ".csv";
                var getDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory ) + "\\Files\\FileCSV\\";

                if (!Directory.Exists(getDirectory))
                {
                   System.IO.Directory.CreateDirectory(getDirectory);
                }

                var time = DateTime.Now.ToString("yyyyMMddHHmmss");
                var pathFile = getDirectory + firtFileName + "_" + time + fileExtension;

                await InsertUsersIntoDatabase(usersStatus1);
                ExportFileCSV(usersStatus0, pathFile);

            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error calling API: {ex.Message}");
            }
            catch (JsonException ex)
            {
                _logger.LogError($"Error parsing JSON response: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task InsertUsersIntoDatabase( List<UserInfo> userInfos)
        {
            List<User> users = new List<User>();
            foreach (UserInfo userInfo in userInfos)
            {
                users.Add(new User
                {
                    UserName = userInfo.UserName,
                    Email = userInfo.Email,
                    Discription = userInfo.Description,
                    Status = userInfo.Status,
                });
            }
            await _context.Users.AddRangeAsync(users);

            try
            {
                _context.SaveChanges();
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async void ExportFileCSV(List<UserInfo> userInfos , string pathFile)
        {
            try
            {
                using (var writer = new StreamWriter(pathFile))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<UserInfo>();

                    await csv.NextRecordAsync();

                    csv.WriteRecords(userInfos);
                }

                Console.WriteLine("Export file success, pathFile : " + pathFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error export file CSV: " + ex.Message);
            }
            Console.WriteLine(pathFile);
        }
    }
}
