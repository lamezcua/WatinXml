using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QaCommon;

namespace WatinXml
{
    class CommandLineArgs
    {
            [Argument(ArgumentType.Required, HelpText =
                "Required: Must specify XML source file")]
            public string fileName = String.Empty;
            [Argument(ArgumentType.AtMostOnce, HelpText =
                "Start URL. By default will use the one specified on the scenario")]
            public string urlToStart = String.Empty;
            [Argument(ArgumentType.AtMostOnce, HelpText =
                "Test Name, by default is program name. It is used for logging")]
            public string testName = String.Empty;
    }
}
