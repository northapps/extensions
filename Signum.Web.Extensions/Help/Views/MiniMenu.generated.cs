﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.Help.Views
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
    
    #line 1 "..\..\Help\Views\MiniMenu.cshtml"
    using Signum.Engine.Help;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Help\Views\MiniMenu.cshtml"
    using Signum.Engine.Maps;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 2 "..\..\Help\Views\MiniMenu.cshtml"
    using Signum.Entities.Help;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 3 "..\..\Help\Views\MiniMenu.cshtml"
    using Signum.Web.Help;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Help/Views/MiniMenu.cshtml")]
    public partial class MiniMenu : System.Web.Mvc.WebViewPage<dynamic>
    {
        public MiniMenu()
        {
        }
        public override void Execute()
        {
            
            #line 5 "..\..\Help\Views\MiniMenu.cshtml"
  
    var ns = (string)ViewData["namespace"];
    var type = (Type)ViewData["type"];
    var appendix = (string)ViewData["appendix"];

    var namespaces = HelpLogic.GetNamespaceHelps();
    var appendices = HelpLogic.GetAppendixHelps();


    Schema schema = Schema.Current;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 17 "..\..\Help\Views\MiniMenu.cshtml"
 using (Html.BeginForm("Search", "Help", FormMethod.Get, new { id = "form-search" }))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 567), Tuple.Create("\"", 621)
            
            #line 20 "..\..\Help\Views\MiniMenu.cshtml"
, Tuple.Create(Tuple.Create("", 581), Tuple.Create<System.Object, System.Int32>(HelpSearchMessage.Search.NiceToString()
            
            #line default
            #line hidden
, 581), false)
);

WriteLiteral(" name=\"q\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-search\"");

WriteLiteral("></i></button>\r\n        </div>\r\n    </div>\r\n");

            
            #line 25 "..\..\Help\Views\MiniMenu.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<h3><a");

WriteAttribute("href", Tuple.Create(" href=\"", 823), Tuple.Create("\"", 874)
            
            #line 27 "..\..\Help\Views\MiniMenu.cshtml"
, Tuple.Create(Tuple.Create("", 830), Tuple.Create<System.Object, System.Int32>(Url.Action((HelpController h) => h.Index())
            
            #line default
            #line hidden
, 830), false)
);

WriteLiteral(">");

            
            #line 27 "..\..\Help\Views\MiniMenu.cshtml"
                                                      Write(HelpMessage.Help.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("</a></h3>\r\n<h4>");

            
            #line 28 "..\..\Help\Views\MiniMenu.cshtml"
Write(HelpMessage.Entities.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n<ul>\r\n");

            
            #line 30 "..\..\Help\Views\MiniMenu.cshtml"
    
            
            #line default
            #line hidden
            
            #line 30 "..\..\Help\Views\MiniMenu.cshtml"
     foreach (var item in namespaces.OrderBy(a => a.Namespace))
    {

            
            #line default
            #line hidden
WriteLiteral("        <li>\r\n");

            
            #line 33 "..\..\Help\Views\MiniMenu.cshtml"
            
            
            #line default
            #line hidden
            
            #line 33 "..\..\Help\Views\MiniMenu.cshtml"
             if (item.Namespace != ns)
            {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1131), Tuple.Create("\"", 1204)
            
            #line 35 "..\..\Help\Views\MiniMenu.cshtml"
, Tuple.Create(Tuple.Create("", 1138), Tuple.Create<System.Object, System.Int32>(Url.Action((HelpController h) => h.ViewNamespace(item.Namespace))
            
            #line default
            #line hidden
, 1138), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 36 "..\..\Help\Views\MiniMenu.cshtml"
               Write(item.Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 37 "..\..\Help\Views\MiniMenu.cshtml"
                if (item.Before != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                <small>");

            
            #line 39 "..\..\Help\Views\MiniMenu.cshtml"
                  Write(HelpMessage.In0.NiceToString(item.Before));

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n");

            
            #line 40 "..\..\Help\Views\MiniMenu.cshtml"
                }
            }
            else
            {
                
            
            #line default
            #line hidden
            
            #line 44 "..\..\Help\Views\MiniMenu.cshtml"
           Write(item.Title);

            
            #line default
            #line hidden
            
            #line 44 "..\..\Help\Views\MiniMenu.cshtml"
                           
                if (item.Before != null)
                {

            
            #line default
            #line hidden
WriteLiteral("                <small>");

            
            #line 47 "..\..\Help\Views\MiniMenu.cshtml"
                  Write(HelpMessage.In0.NiceToString(item.Before));

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n");

            
            #line 48 "..\..\Help\Views\MiniMenu.cshtml"
                }
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 51 "..\..\Help\Views\MiniMenu.cshtml"
            
            
            #line default
            #line hidden
            
            #line 51 "..\..\Help\Views\MiniMenu.cshtml"
             if (item.Namespace == ns || type != null && item.Namespace == type.Namespace)
            {   

            
            #line default
            #line hidden
WriteLiteral("                <ul>\r\n");

            
            #line 54 "..\..\Help\Views\MiniMenu.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 54 "..\..\Help\Views\MiniMenu.cshtml"
                     foreach (var t in item.Types.Where(t => schema.IsAllowed(t, inUserInterface: true) == null))
                    {
                        if (t != type)
                        {

            
            #line default
            #line hidden
WriteLiteral("                        <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 2016), Tuple.Create("\"", 2045)
            
            #line 58 "..\..\Help\Views\MiniMenu.cshtml"
, Tuple.Create(Tuple.Create("", 2023), Tuple.Create<System.Object, System.Int32>(HelpUrls.EntityUrl(t)
            
            #line default
            #line hidden
, 2023), false)
);

WriteLiteral(">");

            
            #line 58 "..\..\Help\Views\MiniMenu.cshtml"
                                                        Write(t.NiceName());

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 59 "..\..\Help\Views\MiniMenu.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                        <li>");

            
            #line 62 "..\..\Help\Views\MiniMenu.cshtml"
                       Write(t.NiceName());

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n");

            
            #line 63 "..\..\Help\Views\MiniMenu.cshtml"
                        }
                    }

            
            #line default
            #line hidden
WriteLiteral("                </ul>\r\n");

            
            #line 66 "..\..\Help\Views\MiniMenu.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </li>\r\n");

            
            #line 68 "..\..\Help\Views\MiniMenu.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</ul>\r\n<h4>");

            
            #line 70 "..\..\Help\Views\MiniMenu.cshtml"
Write(HelpMessage.Appendices.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 71 "..\..\Help\Views\MiniMenu.cshtml"
    
            
            #line default
            #line hidden
            
            #line 71 "..\..\Help\Views\MiniMenu.cshtml"
     if (Navigator.IsCreable(typeof(AppendixHelpDN), isSearch: true))
    {

            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 2452), Tuple.Create("\"", 2509)
            
            #line 73 "..\..\Help\Views\MiniMenu.cshtml"
, Tuple.Create(Tuple.Create("", 2459), Tuple.Create<System.Object, System.Int32>(Url.Action((HelpController c) => c.NewAppendix())
            
            #line default
            #line hidden
, 2459), false)
);

WriteLiteral(">+</a> \r\n");

            
            #line 74 "..\..\Help\Views\MiniMenu.cshtml"
    }
            
            #line default
            #line hidden
WriteLiteral("></h4>\r\n<ul>\r\n");

            
            #line 76 "..\..\Help\Views\MiniMenu.cshtml"
    
            
            #line default
            #line hidden
            
            #line 76 "..\..\Help\Views\MiniMenu.cshtml"
     foreach (var item in appendices)
    {
        if (item.UniqueName != appendix)
        {

            
            #line default
            #line hidden
WriteLiteral("        <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 2651), Tuple.Create("\"", 2724)
            
            #line 80 "..\..\Help\Views\MiniMenu.cshtml"
, Tuple.Create(Tuple.Create("", 2658), Tuple.Create<System.Object, System.Int32>(Url.Action((HelpController h) => h.ViewAppendix(item.UniqueName))
            
            #line default
            #line hidden
, 2658), false)
);

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 81 "..\..\Help\Views\MiniMenu.cshtml"
       Write(item.Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n        </li>\r\n");

            
            #line 83 "..\..\Help\Views\MiniMenu.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("        <li>\r\n");

WriteLiteral("            ");

            
            #line 87 "..\..\Help\Views\MiniMenu.cshtml"
       Write(item.Title);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </li>\r\n");

            
            #line 89 "..\..\Help\Views\MiniMenu.cshtml"
        }
    }

            
            #line default
            #line hidden
WriteLiteral("</ul>\r\n\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
