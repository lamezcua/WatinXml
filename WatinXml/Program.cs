using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QaCommon;
using wxCore;

namespace WatinXml
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            CommandLineArgs cmdArgs = new CommandLineArgs();
            if (Parser.ParseArgumentsWithUsage(args, cmdArgs))
            {
                try
                {
                    wxScenario scenarioToTest = WxSerialize.DeserializeScenario(cmdArgs.fileName);
                    // Override test name if provided
                    if (cmdArgs.testName != string.Empty)
                        scenarioToTest.Name = cmdArgs.testName;
                    //Overrride start url if provided (or exit if none)
                    if (cmdArgs.urlToStart != string.Empty)
                        scenarioToTest.StartUrl = cmdArgs.urlToStart;
                    else
                    {
                        if (scenarioToTest.StartUrl == String.Empty)
                            throw new ApplicationException("Start URL cannot be empty: none specified!");
                    }
                    // Execute test pages
                    scenarioToTest.TestPages();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
