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

namespace Cotide.Portal.Views.Blog
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Blog/_HistoryUserHead.cshtml")]
    public partial class HistoryUserHead : System.Web.Mvc.WebViewPage<Cotide.Web.Controllers.ViewModels.HistoryUserViewModel>
    {
        public HistoryUserHead()
        {
        }
        public override void Execute()
        {

            
            #line 1 "..\..\Views\Blog\_HistoryUserHead.cshtml"
  
    Layout = null;


            
            #line default
            #line hidden

WriteLiteral("<ul class=\"nav nav-tabs nav-stacked \">\r\n    <li>\r\n        <p style=\"text-align: c" +
"enter;\">\r\n            <a href=\"javascript:void(0);\">\r\n                <img style" +
"=\"width: 150px; height: 150px;\" src=\"");


            
            #line 9 "..\..\Views\Blog\_HistoryUserHead.cshtml"
                                                          Write(Model.ImgHead);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"img-polaroid\"></a></p>\r\n    </li>\r\n    <li class=\"active\"><a style=\"back" +
"ground-color: #a3163c; color: #fff; text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.2);\"\r\n" +
"        href=\"javascript:void(0);\">中文名：");


            
            #line 12 "..\..\Views\Blog\_HistoryUserHead.cshtml"
                                  Write(Model.RealName);

            
            #line default
            #line hidden
WriteLiteral(" </a></li>\r\n");


            
            #line 13 "..\..\Views\Blog\_HistoryUserHead.cshtml"
     if (!string.IsNullOrEmpty(Model.EnRealName))
    {

            
            #line default
            #line hidden
WriteLiteral("        <li><a href=\"javascript:void(0);\">英文名: ");


            
            #line 15 "..\..\Views\Blog\_HistoryUserHead.cshtml"
                                          Write(Model.EnRealName);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");


            
            #line 16 "..\..\Views\Blog\_HistoryUserHead.cshtml"
    }

            
            #line default
            #line hidden

            
            #line 17 "..\..\Views\Blog\_HistoryUserHead.cshtml"
     if (!string.IsNullOrEmpty(Model.Email))
    {

            
            #line default
            #line hidden
WriteLiteral("        <li><a href=\"javascript:void(0);\"><i class=\"icon-envelope\"></i>");


            
            #line 19 "..\..\Views\Blog\_HistoryUserHead.cshtml"
                                                                  Write(Model.Email);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n        </li>\r\n");


            
            #line 21 "..\..\Views\Blog\_HistoryUserHead.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</ul>\r\n<!-- 文章分类 -->\r\n");


            
            #line 24 "..\..\Views\Blog\_HistoryUserHead.cshtml"
  Html.RenderAction("_ArticleType", "Blog"); 

            
            #line default
            #line hidden
WriteLiteral("<!-- 时间分类 -->\r\n");


            
            #line 26 "..\..\Views\Blog\_HistoryUserHead.cshtml"
  Html.RenderAction("ArticleDate", "Blog");

            
            #line default
            #line hidden
WriteLiteral("<!-- 标签 -->\r\n");


            
            #line 28 "..\..\Views\Blog\_HistoryUserHead.cshtml"
  Html.RenderAction("ArticleTag", "Blog"); 

            
            #line default
            #line hidden
WriteLiteral("<!-- 最近文章 -->\r\n");


            
            #line 30 "..\..\Views\Blog\_HistoryUserHead.cshtml"
  Html.RenderAction("HistoryArticle", "Blog"); 

            
            #line default
            #line hidden
WriteLiteral(" ");


        }
    }
}
#pragma warning restore 1591
