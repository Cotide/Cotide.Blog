﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17626
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cotide.Portal.Views.Shared
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
    
    #line 1 "..\..\Views\Shared\_BlogLayout.cshtml"
    using Cotide.Domain.Contracts.Task;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.4.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_BlogLayout.cshtml")]
    public partial class BlogLayout : System.Web.Mvc.WebViewPage<dynamic>
    {
        public BlogLayout()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Views\Shared\_BlogLayout.cshtml"
   
    Layout = "~/Views/Shared/_BaseLayout.cshtml";  
 

            
            #line default
            #line hidden

DefineSection("Head", () => {

WriteLiteral("\r\n    ");


            
            #line 6 "..\..\Views\Shared\_BlogLayout.cshtml"
Write(Html.StyleSheet("bootstrap/docs.css"));

            
            #line default
            #line hidden
WriteLiteral(@" 
    <style type=""text/css"">
        body{position: relative; margin: 10px;} a{color: #a3163c; text-decoration: none;} .content_left{float: left; padding-right: 8px; padding-left: 5px; width: 15%;} .content_right{float: left; width: 81%;} .backToTop{display: none; width: 18px; line-height: 1.2; padding: 5px 0; background-color: #C00; color: #fff; font-size: 12px; text-align: center; position: fixed; _position: absolute; right: 10px; bottom: 100px; _bottom: auto; cursor: pointer; opacity: .6; filter: Alpha(opacity=60);}
    </style>
    ");


            
            #line 10 "..\..\Views\Shared\_BlogLayout.cshtml"
Write(Html.JavaScript("bootstrap/bootstrap-dropdown.js"));

            
            #line default
            #line hidden
WriteLiteral("  \r\n");


});

WriteLiteral("\r\n");


DefineSection("Content", () => {


            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                 WriteLiteral("  <div class=\"navbar navbar-inverse\"> ");

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                                                         Html.RenderAction("UserNav", "Blog");
            
            #line default
            #line hidden

            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                                                                                               WriteLiteral("</div><div class=\"container-fluid\">  <div class=\"row\">  <div class=\"content_left " +
"bs-docs-sidebar\" style=\"padding: 0px 20px 0px 10px;\"> ");

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                                                                                                                                                                                                                                        Html.RenderAction("HistoryUserHead", "Blog");
            
            #line default
            #line hidden
WriteLiteral(" </div>  <div class=\"content_right\"> ");


            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                                                                                                                                                                                                                                                                                                                      Write(RenderBody());

            
            #line default
            #line hidden

            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                                                                                                                                                                                                                                                                                                                                        WriteLiteral(" </div> </div>  <div class=\"row-fluid\"> ");

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                  Html.RenderAction("FavoritesUserLink", "Blog");
            
            #line default
            #line hidden

            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                  WriteLiteral("   </div>  </div>  ");

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Shared\_BlogLayout.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                       Html.RenderPartial("~/Views/Shared/_MainBottom.cshtml");

            
            #line default
            #line hidden

});

WriteLiteral("\r\n");


        }
    }
}
#pragma warning restore 1591
