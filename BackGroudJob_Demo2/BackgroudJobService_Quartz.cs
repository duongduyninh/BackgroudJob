using BackGroudJob_Demo2.Data;
using BackGroudJob_Demo2.Data.Models;
using BackGroudJob_Demo2.DTOs;
using BackGroudJob_Demo2.DTOs.Requests.LeadAPI;
using BackGroudJob_Demo2.DTOs.Responses.APIUser;
using BackGroudJob_Demo2.DTOs.Responses.LeadAPI;
using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle;
using CsvHelper;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Org.BouncyCastle.Asn1.Ocsp;
using Quartz;
using Renci.SshNet;
using Serilog;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
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

                //await SendMailEthereal("heoninh47@gmail.com","Hello","dem qua e tuyet lam");
                //await SendMailSmtp4dev("heoninh444@gmail.com","Hello","dem qua e tuyet lam");

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

                /*---------------------------------------------------------------*/
                //string GetUsersURL = "https://localhost:7156/api/User";
                //var result = await GetAPIAsync<GetUsersResponse>(GetUsersURL);
                /*--------------------------*/
                //string postuserurl = "https://localhost:7156/api/user";
                //var request = new Adduserrequest
                //{
                //    Username = "ninhdeptrai",
                //    Email = "ninhdeptraiihon@gmail.com",
                //    Discription = "qua depj trai",
                //    Phonenumber = 545685654,
                //    Status = 1
                //};
                //var result = await postapiasync<adduserresponse, adduserrequest>(postuserurl, request);
                /*--------------------------*/
                //string PostUserURL = "https://localhost:7156/api/User/AddUsers";
                //List<AddUserRequest> users = new List<AddUserRequest>();

                //for (int i = 0; i < 3; i++)
                //{
                //    AddUserRequest user = new AddUserRequest
                //    {
                //        UserName = "ninhdeptrai" + i,
                //        Email = "Ninhdeptraiihon" + i + "@gmail.com",
                //        Discription = "qua depj trai" + i,
                //        Status = 1
                //    };
                //    users.Add(user);
                //}
                //AddUsersRequest request = new AddUsersRequest 
                //{
                //    UserInfos = users,
                //};
                //var result = await PostAPIAsync<AddUserResponse, AddUsersRequest>(PostUserURL, request);
                /*--------------------------*/
                //string PutUserURL = "https://localhost:7156/api/User";
                //var request = new UpdateUserRequest
                //{
                //    UserId = 2,
                //    UserName = "ninhdeptrai",
                //    Email = "ninhdeptraiihon@gmail.com",
                //    Description= "qua depj trai",
                //    PhoneNumber = 545685654,
                //    Status = 1
                //};
                //var result = await PutAPIAsync<UpdateUserResponse, UpdateUserRequest>(PutUserURL, request);
                /*--------------------------*/
                //string DeleteUserURL = "https://localhost:7156/api/User/"+ 10;
                //var result = await DeleteAPIAsync<DeleteUserResponse>(DeleteUserURL);
                /*---------------------------------------------------------------*/
                //string pathFileJson = @"E:\\SiliconStack\\Lead API Implementation\\lead-notification-response-sample.json";
                //string jsonContext = await File.ReadAllTextAsync(pathFileJson);

                //var settings = new JsonSerializerSettings
                //{
                //    NullValueHandling = NullValueHandling.Ignore,
                //    Formatting = Formatting.Indented
                //};

                //try
                //{
                //    NotificationForVehicleResponse response = JsonConvert.DeserializeObject<NotificationForVehicleResponse>(jsonContext, settings);
                //    var jsonExport = JsonConvert.SerializeObject(response, settings);
                //    var fileName = $"ExportedFile_{DateTime.Now:yyyyMMdd_HHmmss}.json";

                //    var pathFile = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\Files\\FileJson\\";

                //    if (!Directory.Exists(pathFile))
                //    {
                //        System.IO.Directory.CreateDirectory(pathFile);
                //    }

                //    var filePath = Path.Combine(pathFile, fileName);
                //    File.WriteAllText(filePath, jsonExport);
                //}
                //catch (Exception ex)
                //{
                //    LoggerError(ex);
                //}
                /*---------------------------------------------------------------*/
                //string filePath1 = @"E:\\SiliconStack\\Lead API Implementation\\lead-notification-response-sample.json";
                //string filePath2 = @"F:\\Visual Studio\\BackGroudJob_Demo2\\BackGroudJob_Demo2\\bin\\Debug\\net8.0\\Files\\FileJson\\ExportedFile_20240524_142056.json";

                //bool checkFileEquality = await CheckFileEquality(filePath1, filePath2);
                //if (checkFileEquality)
                //{
                //    Console.WriteLine("file1 & file2 FIT");
                //}
                /*---------------------------------------------------------------*/
                // await NotificationForVehicle();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                /*---------------------------------------------------------------*/
                await TestReflection();
            }
            catch (Exception ex)
            {
                LoggerError(ex);
            }
           
        }

        public async Task<NotificationForVehicleResponse> NotificationForVehicle()
        {
            string accessToken = null;
            var request = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", "a153bd20-e947-4380-aee3-9cfc3da0bc74"),
                new KeyValuePair<string, string>("client_secret", "rdcQCsLROzbgZ6HaAJpnAgDlU1KQig3A0hOcJzQs"),
                new KeyValuePair<string, string>("scope", "machine2machine client_a153bd20-e947-4380-aee3-9cfc3da0bc74")
            });

            GetNotificationForVehicleRequest requet2 = new GetNotificationForVehicleRequest
            {
                tspId = 79,
                vin = "12345678901234568"
            };

            string url = "https://auth-i.bmwgroup.net/auth/oauth2/realms/root/realms/machine2machine/access_token";

            try
            {
                var responseAccessToken = await PostAPIAsync<GetAccessTokenE2EResponse>(url, request);

                accessToken = responseAccessToken.Access_Token;

                string url2 = "https://tsp-e2e-emea.bmw.com/ts-pffs/lead/v1/notifications-for-vehicle";

                NotificationForVehicleResponse response = await PostAPIAsync<NotificationForVehicleResponse>(url2, requet2, accessToken);

                Log.Information("Response NotificationForVehicle");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<T> HandleAPIResponse<T>(HttpResponseMessage response) where T : baseResponse, new()
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) 
            {
               // _logger.LogError("UnSuccess: {0} {1} ", (int)response.StatusCode, responseContent);
                T error = new T { StatusCodeAPI = (int)response.StatusCode , Message = responseContent } ; 
                return error;
            }

            try
            {
                var result = JsonConvert.DeserializeObject<T>(responseContent);
                result.StatusCodeAPI = (int)response.StatusCode;
                return result;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex,$"Error deserializing response");
                return null;
            }
        }

        public async Task<T> GetAPIAsync<T>(string url) where T : baseResponse , new()
        {
            var response = await _httpClient.GetAsync(url);
            return await HandleAPIResponse<T>(response);
        }

        public async Task<T> PostAPIAsync<T>(string url, Object request ,string authToken = null ) where T : baseResponse , new()
        {
            if (!string.IsNullOrEmpty(authToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }

            HttpContent content;
            if (request is HttpContent)
            {
                content = request as HttpContent;
            }
            else
            {
                var json = JsonConvert.SerializeObject(request);
                content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.PostAsync(url, content);
            return await HandleAPIResponse<T>(response);
        }

        public async Task<T> PutAPIAsync<T , TRequest>(string url , TRequest request) where T : baseResponse , new()
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent (json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            return await HandleAPIResponse<T>(response);
        }

        public async Task<T> DeleteAPIAsync<T>(string url) where T:baseResponse , new() 
        {
            var response = await _httpClient.DeleteAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("UnSuccess:"+ (int)response.StatusCode , "," +responseContent);
                return new T { StatusCodeAPI = (int)response.StatusCode, Message = responseContent };
            }
            return new T
            {
                StatusCodeAPI = (int)response.StatusCode,
                Message = responseContent
            };
        }   

        //public async Task<T> GetAPIAsync<T>(string url, string nameAPICall)
        //{
        //    try
        //    {
        //        var reponse = await _httpClient.GetAsync(url);
        //        reponse.EnsureSuccessStatusCode();

        //        var reponseContent = await reponse.Content.ReadAsStringAsync();
        //        if (string.IsNullOrWhiteSpace(reponseContent))
        //        {
        //            _logger.LogInformation("Reponse content null" + nameAPICall);
        //            return default(T);  
        //        }

        //        var settings = new JsonSerializerSettings
        //        {
        //            ContractResolver = new DefaultContractResolver()
        //        };

        //        var result = JsonConvert.DeserializeObject<T>(reponseContent);

        //        return result;

        //    }catch (HttpRequestException ex)
        //    {
        //        _logger.LogError($"Error Http,{ex.Message}"); 
        //        return default(T);  
        //    }catch (Exception ex)
        //    {
        //        _logger.LogError($"Error,{ex.Message}");
        //        return default(T);

        //    }
        //}

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

        public async Task<bool> CheckFileEquality(string file1 , string file2)
        {
            string[] file1db = File.ReadAllLines(file1);
            string[] file2db = File.ReadAllLines(file2);

            //if (file1db.Length != file2db.Length)
            //{
            //    Console.WriteLine("Error 1");
            //    return false;
            //}

            for (int i = 0; i < file1db.Length; i++)
            {
                if (file1db[i] != file2db[i])
                {
                    Console.WriteLine($"Error file no fit  {i + 1}.");
                    return false;
                }
            }

            return true;
        }

        public void LoggerError(Exception ex)
        {
            switch (ex)
            {
                case HttpRequestException httpException:
                    _logger.LogError(httpException, $"Error calling API: {httpException.Message}");
                    break;
                case JsonException jsonException:
                    _logger.LogError(jsonException, $"Error JSON response: {jsonException.Message}");
                    break;
                case FileNotFoundException fileNotFoundException:
                    _logger.LogError(fileNotFoundException, $"File not found: {fileNotFoundException.FileName}");
                    break;
                case InvalidOperationException invalidOperationException:
                    _logger.LogError(invalidOperationException, $"Invalid operation: {invalidOperationException.Message}");
                    break;
                case ArgumentNullException argumentNullException:
                    _logger.LogError(argumentNullException, $"Argument cannot be null: {argumentNullException.ParamName}");
                    break;
                case ArgumentException argumentException:
                    _logger.LogError(argumentException, $"Argument error: {argumentException.Message}");
                    break;
                case FormatException formatException:
                    _logger.LogError(formatException, $"Format error: {formatException.Message}");
                    break;
                case OverflowException overflowException:
                    _logger.LogError(overflowException, $"Overflow error: {overflowException.Message}");
                    break;
                case IndexOutOfRangeException indexOutOfRangeException:
                    _logger.LogError(indexOutOfRangeException, $"Index out of range: {indexOutOfRangeException.Message}");
                    break;
                case TimeoutException timeoutException:
                    _logger.LogError(timeoutException, $"Timeout error: {timeoutException.Message}");
                    break;
                case IOException ioException:
                    _logger.LogError(ioException, $"IO error: {ioException.Message}");
                    break;
                case UnauthorizedAccessException unauthorizedAccessException:
                    _logger.LogError(unauthorizedAccessException, $"Unauthorized access error: {unauthorizedAccessException.Message}");
                    break;
                case DbException dbException:
                    _logger.LogError(dbException, $"Database error: {dbException.Message}");
                    break;
                default:
                    _logger.LogError(ex, $"Unexpected error: {ex.Message}");
                    break;
            }
        }

        public async Task TestReflection()
        {
            string className = File.ReadAllText("C:\\Users\\Admin\\Downloads\\AU Keepass E2E (2).txt").Trim();

            Type classType = Type.GetType(className);
            Console.WriteLine(classType.FullName);
        }
    }
}
