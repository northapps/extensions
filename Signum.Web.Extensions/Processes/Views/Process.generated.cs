﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.Processes.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Signum.Entities;
    
    #line 1 "..\..\Processes\Views\Process.cshtml"
    using Signum.Entities.Processes;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Processes/Views/Process.cshtml")]
    public partial class Process : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Process()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Processes\Views\Process.cshtml"
Write(Html.ScriptCss("~/processes/Content/Processes.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 4 "..\..\Processes\Views\Process.cshtml"
Write(Html.ScriptsJs("~/Processes/Scripts/SF_Process.js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 6 "..\..\Processes\Views\Process.cshtml"
 using (var e = Html.TypeContext<ProcessDN>())
{
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.State, f => f.ReadOnly = true));

            
            #line default
            #line hidden
            
            #line 8 "..\..\Processes\Views\Process.cshtml"
                                                            
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Processes\Views\Process.cshtml"
Write(Html.EntityLine(e, f => f.Algorithm));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Processes\Views\Process.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Processes\Views\Process.cshtml"
Write(Html.EntityLine(e, f => f.Session, f => f.ReadOnly = true));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Processes\Views\Process.cshtml"
                                                               
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Processes\Views\Process.cshtml"
Write(Html.EntityLine(e, f => f.Data, f => f.ReadOnly = true));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Processes\Views\Process.cshtml"
                                                            
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.MachineName));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Processes\Views\Process.cshtml"
                                          
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.ApplicationName));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Processes\Views\Process.cshtml"
                                              
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.CreationDate));

            
            #line default
            #line hidden
            
            #line 14 "..\..\Processes\Views\Process.cshtml"
                                           
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.PlannedDate, f => { f.HideIfNull = true; f.ReadOnly = true; }));

            
            #line default
            #line hidden
            
            #line 15 "..\..\Processes\Views\Process.cshtml"
                                                                                            
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.CancelationDate, f => { f.HideIfNull = true; f.ReadOnly = true; }));

            
            #line default
            #line hidden
            
            #line 16 "..\..\Processes\Views\Process.cshtml"
                                                                                                
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.QueuedDate, f => { f.HideIfNull = true; f.ReadOnly = true; }));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Processes\Views\Process.cshtml"
                                                                                           
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.ExecutionStart, f => { f.HideIfNull = true; f.ReadOnly = true; }));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Processes\Views\Process.cshtml"
                                                                                               
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.ExecutionEnd, f => { f.HideIfNull = true; f.ReadOnly = true; }));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Processes\Views\Process.cshtml"
                                                                                             
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.SuspendDate, f => { f.HideIfNull = true; f.ReadOnly = true; }));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Processes\Views\Process.cshtml"
                                                                                            
    
            
            #line default
            #line hidden
            
            #line 21 "..\..\Processes\Views\Process.cshtml"
Write(Html.ValueLine(e, f => f.ExceptionDate, f => { f.HideIfNull = true; f.ReadOnly = true; }));

            
            #line default
            #line hidden
            
            #line 21 "..\..\Processes\Views\Process.cshtml"
                                                                                              
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\Processes\Views\Process.cshtml"
Write(Html.EntityLine(e, f => f.Exception, f => { f.HideIfNull = true; f.ReadOnly = true; }));

            
            #line default
            #line hidden
            
            #line 22 "..\..\Processes\Views\Process.cshtml"
                                                                                           
    
    if (e.Value.State == ProcessState.Executing || e.Value.State == ProcessState.Queued)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("Progress:\r\n");

WriteLiteral("    <br />\r\n");

WriteLiteral("    <br />\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"progressContainer\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"progressBar\"");

WriteLiteral(" id=\"progressBar\"");

WriteAttribute("style", Tuple.Create(" style=\"", 1556), Tuple.Create("\"", 1633)
, Tuple.Create(Tuple.Create("", 1564), Tuple.Create("height:", 1564), true)
, Tuple.Create(Tuple.Create(" ", 1571), Tuple.Create("100%;", 1572), true)
, Tuple.Create(Tuple.Create(" ", 1577), Tuple.Create("width:", 1578), true)
            
            #line 30 "..\..\Processes\Views\Process.cshtml"
, Tuple.Create(Tuple.Create(" ", 1584), Tuple.Create<System.Object, System.Int32>(Math.Round((double?)e.Value.Progress ?? 0, 0)
            
            #line default
            #line hidden
, 1585), false)
, Tuple.Create(Tuple.Create("", 1631), Tuple.Create("%;", 1631), true)
);

WriteLiteral(">\r\n        </div>\r\n    </div>\r\n");

            
            #line 33 "..\..\Processes\Views\Process.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(function () {\r\n            SF.Process.refreshUpdate(\'");

            
            #line 36 "..\..\Processes\Views\Process.cshtml"
                                 Write(e.Value.Id);

            
            #line default
            #line hidden
WriteLiteral("\', \'");

            
            #line 36 "..\..\Processes\Views\Process.cshtml"
                                                Write(e.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\',\r\n            \"");

            
            #line 37 "..\..\Processes\Views\Process.cshtml"
        Write(Url.Action("GetProgressExecution", "Process"));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n    })\r\n    </script>\r\n");

            
            #line 40 "..\..\Processes\Views\Process.cshtml"

    }
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
