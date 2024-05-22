using BackGroudJob_Demo2.Data;
using BackGroudJob_Demo2.Data.Models;
using BackGroudJob_Demo2.DTOs;
using CsvHelper;
using MailKit.Security;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Quartz;
using Renci.SshNet;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using JsonException = Newtonsoft.Json.JsonException;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace BackGroudJob_Demo2
{
    public class BackgroudJobService_Quartz : IJob
    {
        private readonly ILogger<BackgroundJobService> _logger;
        private readonly Dbcontext_User _context;
        private readonly SendMailSettings _sendMainConfig;
        private readonly HttpClient _httpClient = new HttpClient();


        public BackgroudJobService_Quartz(ILogger<BackgroundJobService> logger,
                                          Dbcontext_User context,
                                          IOptions <SendMailSettings> sendMainConfig)
        {
            _logger = logger;
            _context = context;
            _sendMainConfig = sendMainConfig.Value;
        }

        public async Task Execute(IJobExecutionContext t)
        {
            try
            {
                _logger.LogInformation("Start");

                await SendMailEthereal("heoninh47@gmail.com","Hello","dem qua e tuyet lam");
                await SendMailSmtp4dev("heoninh444@gmail.com","Hello","dem qua e tuyet lam");

                /*---------------------------------------------------------------*/

                //var configRebex = new SSHConfiguration
                //{
                //    Host = "192.168.1.87",
                //    UserName = "tester",
                //    Password = "password",
                //    Port = 22
                //};

                //await SSH(1, configRebex,"./test");
                //await SSH(2, configRebex, "textDelete.txt");
                //await SSH(3, configRebex, "textDownload.txt", "F:\\Visual Studio\\BackGroudJob_Demo2\\BackGroudJob_Demo2\\bin\\Debug\\net8.0\\Files\\FileCSV\\");
                //await SSH(4, configRebex, "textReName1.txt", "textReName2.txt");

                /*---------------------------------------------------------------*/

                //string GetUsersURL = "https://localhost:7156/api/User";

                //var resultGetUsers = await GetAPIAsync<UserInfoResponse>(GetUsersURL, "GetUsers");

                //List<UserInfo> usersStatus1 = resultGetUsers.UserInfos.Where(x=>x.Status  == 1 ).ToList();   
                //List<UserInfo> usersStatus0 = resultGetUsers.UserInfos.Where(x=>x.Status  == 0 ).ToList();

                //var firtFileName = "namefile";
                //var fileExtension = ".csv";
                //var getDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory ) + "\\Files\\FileCSV\\";

                //if (!Directory.Exists(getDirectory))
                //{
                //   System.IO.Directory.CreateDirectory(getDirectory);
                //}

                //var time = DateTime.Now.ToString("yyyyMMddHHmmss");
                //var pathFile = getDirectory + firtFileName + "_" + time + fileExtension;

                //await InsertUsersIntoDatabase(usersStatus1);
                //await ExportFileCSV(usersStatus0, pathFile);

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

        public async Task<T> GetAPIAsync<T>(string url, string nameAPICall)
        {
            try
            {
                var reponse = await _httpClient.GetAsync(url);
                reponse.EnsureSuccessStatusCode();

                var reponseContent = await reponse.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(reponseContent))
                {
                    _logger.LogInformation("Reponse content null" + nameAPICall);
                    return default(T);  
                }

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                };

                var result = JsonConvert.DeserializeObject<T>(reponseContent);

                return result;

            }catch (HttpRequestException ex)
            {
                _logger.LogError($"Error Http,{ex.Message}"); 
                return default(T);  
            }catch (Exception ex)
            {
                _logger.LogError($"Error,{ex.Message}");
                return default(T);

            }
        }

        public async Task SendMail(string toAddress, SendMailSettings configMail, params Object[] args)
        {
            try
            {
                using( var email = new MimeMessage())
                {
                    string subject = (string)args[0];
                    string body = (string)args[1];

                    email.From.Add(new MailboxAddress("Server", configMail.SenderEmail));
                    email.To.Add(new MailboxAddress("customer", toAddress));

                    email.Subject = subject;

                    var builder = new BodyBuilder()
                    {
                        TextBody = body
                    };

                    email.Body = builder.ToMessageBody();

                    using (var smtp = new SmtpClient())
                    {
                        smtp.Connect(configMail.SmtpServer, configMail.SmtpPort, false );

                        if (configMail.StatusAuthentication)
                        {
                            smtp.Authenticate(configMail.SenderEmail, configMail.Password);
                        }

                        smtp.Send(email);
                        Console.WriteLine("SendMail true");
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
        public async Task SendMailEthereal(string toAddress, params Object[] args)
        {
            //ethereal.email
            var config = new SendMailSettings
            {
                SmtpServer = _sendMainConfig.SmtpServer,
                SenderEmail = _sendMainConfig.SenderEmail,  
                SenderName = _sendMainConfig.SenderName,    
                SmtpPort = _sendMainConfig.SmtpPort,    
                Password = _sendMainConfig.Password,
                StatusAuthentication = true,
            };

            await SendMail(toAddress, config, args);

        }

        public async Task SendMailSmtp4dev (string toAddress, params Object[] args)
        {
            //Smtp4dev
            var config = new SendMailSettings
            {
                SmtpServer = "localhost",
                SenderEmail = "beNinh@gmail.com",
                SenderName = "beNinh6mui",
                SmtpPort = 25,
                Password = string.Empty,
                StatusAuthentication = false,
            };

            await SendMail(toAddress, config, args);
        }

        public async Task SSH(int number , SSHConfiguration config, params Object[] args)
        {
            var sSH_Net = new SSH_Net(config);

            switch (number)
            {
                case 1:
                    if (args.Length > 0 && args[0] is string showFile) {
                        sSH_Net.ShowFiles(showFile);
                    }
                    break;
                case 2:
                    if (args.Length > 0 && args[0] is string deleteFile)
                    {
                        sSH_Net.DeleteFile(deleteFile);
                    }
                    break;
                case 3:
                    if (args.Length > 0 && args[0] is string serverFile && args[0] is string pathLocalFile)
                    {
                        sSH_Net.DownloadFiles(serverFile, pathLocalFile);
                    }
                    break;
                case 4:
                    if (args.Length > 0 && args[0] is string nameServerFile && args[1] is string newNameFile) 
                    { 
                        sSH_Net.ReNameFile(nameServerFile, newNameFile);
                    }
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
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
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task  ExportFileCSV(List<UserInfo> userInfos , string pathFile)
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
