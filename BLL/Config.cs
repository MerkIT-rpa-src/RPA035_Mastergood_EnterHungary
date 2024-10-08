using RPA999EnterHungary3._0DOBOZOS.ObjectRepository;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using UiPath.CodedWorkflows;
using UiPath.Core;
using UiPath.Core.Activities.Storage;
using UiPath.Orchestrator.Client.Models;
using UiPath.Testing;
using UiPath.Testing.Activities.TestData;
using UiPath.Testing.Activities.TestDataQueues.Enums;
using UiPath.Testing.Enums;
using UiPath.UIAutomationNext.API.Contracts;
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;

namespace Merkit_RPA_Framework.BLL
{
    public enum LangEnum
    {
        Hu = 0,
        En = 1
    }
    public class Config 
    {
        #region "Mandatory config properties - Process parameters"

        public string AppName { get; set; }             //RPA888
        public string AppCode { get; set; }             //Simple_Test_App
        public Boolean LogToFile { get; set; }          // if custom log needed
        public string LogDir { get; set; }              // in case custom log true       
        public string AssetFolder { get; set; }         // Define the used asset folder (default Shared) - For email credentials
        public int MaxProcessableItemCount { get; set; }    //QueueItems count
        public bool UseOrchestrator { get; set; }           //For logging (log in Orchestrator)
        public int ErrorWeight { get; set; }                //For InstantAbort
        public int MaxAllowedErrorCount { get; set; }
        public int LogLevel { get; set; }               //0 - info, 1 - warn, 2 - error
        public string Queue { get; set; }
        public string OrchestratorFolder {get; set; }             
        public Boolean IgnoreUploadedQueueItems {get; set; }             
        public string ProcessesToKill {get; set;}               
        public string ClientConfigFolder { get; set; }                   
        public LangEnum Lang { get; set; }
        public string LogFileName { get; set; }         // If LogToFile true
        public string DebugLogFileName { get; set; }    // If LogToFile true

        #endregion
        
        #region Additional Project specific properties
        // ADD HERE THE ADDITIONAL CONFIG PROPERTIES
        // public string AdditionalConfigProp { get; set; } ...
        
        
        
        
        // END OF ADDITIONAL PROPERTIES
        #endregion
        
    }
    
    public class EmailConfig
    {
          
        #region "Email parameters"

        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpCredentialAssetName { get; set; } 
        public bool SmtpEnableSsl { get; set; }        
        public string SmtpHostEmail { get; set; }        
        
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }        
        public string[] Attachment { get; set; }
        public bool IsBodyHtml { get; set; }
        public string Cc { get; set; }
        public string BCc { get; set; }
        public int SenderType { get; set; }
        public string SentOnBehalfOf { get; set; }
        public string OutlookAccount { get; set; }       
        public Boolean UseMerkitTemplate { get; set; }        
        public string MsgBody_Table { get; set;}        
        
        #endregion
    }
}