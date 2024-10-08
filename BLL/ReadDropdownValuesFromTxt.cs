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
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;

namespace RPA999EnterHungary3._0DOBOZOS.BLL
{

    /// <summary>
    /// Read Dropdown Values From Txt
    /// </summary>
    public class ReadDropdownValuesFromTxt : CodedWorkflow
    {
        [Workflow]
        public (Dictionary<string, string> out_FileValueDict, int out_countFiles) Execute()
        {
            Dictionary<string, string> fileValueDict = new Dictionary<string, string>();
            int countFiles = 0;
            string filename = "";
            string fileTxt = "";
            
            // 22 (23) file
            string[] files = new string[]
            {
                "állampolgárság",
                "átvételi ország",
                "benyújtó",
                "családi állapot",
                "egészségbiztosítás",
                "előző ország",
                "FEOR",
                // "irányítószám",
                "iskolai végzettség",
                "munkakör iskolai végzettség",
                "munkáltató közterület jellege",
                "nem",
                "nemzetiség",
                "nyelv",
                "pénznem",
                "szállás emelet",
                "szállás közterület jellege",
                "szállás tartózkodási jogcíme",
                "szül_ország",
                "TEÁOR",
                "továbbut ország",
                "útlevél tipus",
                "zipcode"
            };
            
            // read text files + put filename and content in output dictionary 
            foreach(string file in files)
            {
                countFiles++;
                filename = string.Format(@"Data\Textfiles\{0}.txt", file);
                fileTxt = File.ReadAllText(filename);
                fileValueDict.Add(file, fileTxt);
            }
           
            return (out_FileValueDict: fileValueDict, out_countFiles: countFiles);
        }
    }
}