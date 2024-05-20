using Renci.SshNet;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BackGroudJob_Demo2
{
    public class SSH_Net
    {
        public void ListFiles()
        {
            var host = "192.168.1.87";
            var username = "tester";
            var password = "password";

            var remoteDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\Files\\FileCSV\\";

            using (SftpClient sftp = new SftpClient(new PasswordConnectionInfo(host, 22, username, password)))
            {
                try
                {
                    sftp.Connect();

                    var files =  sftp.ListDirectory("/data/");

                    foreach (var file in files)
                    {
                        Console.WriteLine(file.Name);
                    }
                    
                    sftp.Disconnect();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }
            }
        }
    }
}
