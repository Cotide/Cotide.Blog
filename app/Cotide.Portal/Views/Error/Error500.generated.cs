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

namespace Cotide.Portal.Views.Error
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.4.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Error/Error500.cshtml")]
    public partial class Error500 : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Error500()
        {
        }
        public override void Execute()
        {

            
            #line 1 "..\..\Views\Error\Error500.cshtml"
  
    ViewBag.Title = "500错误";
    Layout = "~/Views/Shared/_Layout.cshtml"; 


            
            #line default
            #line hidden
WriteLiteral("<style type=\"text/css\">\r\n    BODY\r\n    {\r\n        font-size: 9pt;\r\n        color:" +
" #842b00;\r\n        line-height: 16pt;\r\n        font-family: \"Tahoma\" , \"宋体\";\r\n  " +
"      text-decoration: none;\r\n    }\r\n    TABLE\r\n    {\r\n        font-size: 9pt;\r\n" +
"        color: #842b00;\r\n        line-height: 16pt;\r\n        font-family: \"Tahom" +
"a\" , \"宋体\";\r\n        text-decoration: none;\r\n    }\r\n    TD\r\n    {\r\n        font-s" +
"ize: 9pt;\r\n        color: #842b00;\r\n        line-height: 16pt;\r\n        font-fam" +
"ily: \"Tahoma\" , \"宋体\";\r\n        text-decoration: none;\r\n    }\r\n    BODY\r\n    {\r\n " +
"       scrollbar-highlight-color: buttonface;\r\n        scrollbar-shadow-color: b" +
"uttonface;\r\n        scrollbar-3dlight-color: buttonhighlight;\r\n        scrollbar" +
"-track-color: #eeeeee;\r\n        background-color: #ffffff;\r\n    }\r\n    A\r\n    {\r" +
"\n        font-size: 9pt;\r\n        color: #842b00;\r\n        line-height: 16pt;\r\n " +
"       font-family: \"Tahoma\" , \"宋体\";\r\n        text-decoration: none;\r\n    }\r\n   " +
" A:hover\r\n    {\r\n        font-size: 9pt;\r\n        color: #0188d2;\r\n        line-" +
"height: 16pt;\r\n        font-family: \"Tahoma\" , \"宋体\";\r\n        text-decoration: u" +
"nderline;\r\n    }\r\n    H1\r\n    {\r\n        font-size: 19pt;\r\n        font-family: " +
"\"Tahoma\" , \"宋体\";\r\n    }\r\n    .ErrorMessageContext\r\n    {\r\n        padding-top: 3" +
"0px;\r\n    }\r\n</style>\r\n<div class=\"ErrorMessageContext\">\r\n    <table cellspacing" +
"=\"0\" width=\"600\" align=\"center\" border=\"0\" cepadding=\"0\">\r\n        <tbody>\r\n    " +
"        <tr colspan=\"2\">\r\n                <td valign=\"top\" align=\"middle\">\r\n    " +
"                <td>\r\n                        <td>\r\n                            " +
"<h1>\r\n                                ");


            
            #line 72 "..\..\Views\Error\Error500.cshtml"
                           Write(ViewBag.Error);

            
            #line default
            #line hidden
WriteLiteral(@"</h1>
                            您正在访问的页面出错了。
                            <hr noshade size=""0"">
                            <p>
                                ☉ 错误内容：</p>
                            <ul>
                                <li>HTTP 500 - 内部服务器错误 </li>
                            </ul>
                            <p>
                                ☉ 该提示信息来自- Cotide：<br />
                                ☉ 如果您对本站有任何疑问、意见、建议、咨询，请联系管理员
                                <hr noshade size=""0"">
                            </p>
                        </td>
            </tr>
        </tbody>
    </table>
</div>
");


        }
    }
}
#pragma warning restore 1591
