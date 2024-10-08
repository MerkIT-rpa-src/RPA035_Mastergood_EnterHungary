using System;
using System.Diagnostics;
using System.Management;
using System.Security.Authentication;
using System.Security.Principal;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace Merkit_RPA_Framework.Framework.Framework.Functions
{
    public class CustomFunctions
    {
        public static int KillProcessByNameCurrentUserOnly(string processName, bool currentUserOnly)
        {
           
            try
             {
                 string userName = null;
            
                 if (currentUserOnly)
                 {
                     WindowsIdentity user = WindowsIdentity.GetCurrent();
            
                     if (user == null)
                     {
                         throw new InvalidCredentialException("No current user ? !");
                     }
            
                     userName = user.Name;
                 }
            
                 var processFinder = new ManagementObjectSearcher(string.Format("Select * from Win32_Process where Name = '{0}'", processName));
                 var processes = processFinder.Get();
            
                 if (processes.Count == 0)
                 {
                    return 0;
                 }
            
                 foreach (System.Management.ManagementObject managementObject in processes)
                 {
                     try
                     {
                         var pId = Convert.ToInt32(managementObject["ProcessId"]);
                         var process = Process.GetProcessById(pId);
            
                         if (currentUserOnly) //current user
                         {
                             var processOwnerInfo = new object[2];
                             managementObject.InvokeMethod("GetOwner", processOwnerInfo);
                             var processOwner = (string)processOwnerInfo[0];
                             var net = (string)processOwnerInfo[1];
            
                             if (!string.IsNullOrEmpty(net))
                             {
                                 processOwner = string.Format(@"{0}\{1}", net, processOwner);
                             }
            
                             if (string.CompareOrdinal(processOwner, userName) == 0)
                             {
                                 process.Kill();
                             }
                         }
                         else //any user                    
                         {
                             process.Kill();
                         }
                     }
                     catch (Exception ex2)
                     {
                     }
            
                 }
             }
             catch (Exception ex)
             {
                 //There is a good chance for UnauthorizedAccessException here, so
                 //log the error or handle otherwise.
             };
             
             return 0;
        }
        
        public static void SendSMTPEmail(string body, bool isBodyHtml, string subject, string to, string cc, string bcc, int port, string host, bool enableSsl, string hostEmail, string hostUserName, SecureString hostPassword)
        {
            try
            {
                using(SmtpClient client = new SmtpClient())
                {
                    NetworkCredential credential = new NetworkCredential(hostUserName, new System.Net.NetworkCredential(string.Empty, hostPassword).Password);
                    using(MailMessage message = new MailMessage())
                    {
                        MailAddress fromHostAddress = new MailAddress(hostEmail);
                    
                        client.Host = host;
                        client.Port = port;
                        client.UseDefaultCredentials = false;
                        client.EnableSsl = enableSsl;
                        client.Credentials = credential;
                    
                        message.From = fromHostAddress;
                        message.Subject = subject;
                        message.Body = body;
                        message.IsBodyHtml = isBodyHtml;                    
                        message.To.Add(to); //multiple email addresses must be separeted with comma (,)
                        
                        client.Send(message);
                    }                    
                }    
                
            }catch(Exception ex)
            {
                throw ex;
                        
            }
        }
    }
}