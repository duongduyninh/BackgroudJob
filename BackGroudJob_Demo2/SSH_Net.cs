using BackGroudJob_Demo2.DTOs;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.Extensions.Hosting;
using Renci.SshNet;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace BackGroudJob_Demo2
{
    public class SSH_Net
    {
        private readonly SSHConfiguration _sshConfig;

        public SSH_Net(SSHConfiguration sshConfig) 
        {
            _sshConfig = sshConfig;
        }

        private SftpClient SFTPConnect()
        {
            return new SftpClient(new PasswordConnectionInfo(_sshConfig.Host, _sshConfig.Port, _sshConfig.UserName, _sshConfig.Password));
        }       
        public void ShowFiles(string  pathFile)
        {
            using (var sftp = SFTPConnect())
            {
                try
                {
                    sftp.Connect();

                    var files = sftp.ListDirectory(pathFile);

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

        public void DownloadFiles(string pathServerFile , string localFile) 
        {

            using (var sftp = SFTPConnect())
            {
                try
                {
                    sftp.Connect();

                    using (var handleLocalFile = File.OpenWrite(Path.Combine(localFile, pathServerFile)))
                    {
                        sftp.DownloadFile(pathServerFile, handleLocalFile);
                    }
                    sftp.Disconnect();

                }catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
        }

        public void ReNameFile (string existingName , string newName) 
        {
            using (var sftp = SFTPConnect())
            {
                try
                {
                    sftp.Connect();
                    sftp.RenameFile(existingName, newName);
                    sftp.Disconnect();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }
            }
        }

        public void DeleteFile (string existingName) 
        { 
            using (var sftp = SFTPConnect()) 
            {
                try
                {
                    sftp.Connect();

                    if (sftp.Exists(existingName))
                    {
                        sftp.Delete(existingName);
                    }  
                    sftp.Disconnect();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());       
                }
            }
        }    

    }
}
