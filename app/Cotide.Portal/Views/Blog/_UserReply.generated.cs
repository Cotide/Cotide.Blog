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
    
    #line 4 "..\..\Views\Blog\_UserReply.cshtml"
    using Cotide.Web.Controllers.Blog.ViewModel.Article;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.4.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Blog/_UserReply.cshtml")]
    public partial class UserReply : System.Web.Mvc.WebViewPage<SaveMessageViewModel>
    {
        public UserReply()
        {
        }
        public override void Execute()
        {

            
            #line 1 "..\..\Views\Blog\_UserReply.cshtml"
  
    Layout = null;


            
            #line default
            #line hidden


WriteLiteral("\r\n");


            
            #line 7 "..\..\Views\Blog\_UserReply.cshtml"
 using (
        Html.BeginForm("SaveMessage", "Blog", FormMethod.Post,
                           new { @id = "SaveMessageFrom" }))
{ 

            
            #line default
            #line hidden
WriteLiteral("    <p>\r\n        ");


            
            #line 12 "..\..\Views\Blog\_UserReply.cshtml"
   Write(Html.HiddenFor(x => x.ArticleId));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <span>\r\n            <em>评论内容</em></span>\r\n            <div id=\"msgTip\">" +
"\r\n</div>\r\n        ");


            
            #line 17 "..\..\Views\Blog\_UserReply.cshtml"
   Write(Html.TextAreaFor(x => x.Comment, new
                                            {
                                                @rows = "5",
                                                @style = "width: 98%;",
                                                @tabindex = "4",
                                                @placeholder = "请输入评论的内容"
                                            }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </p>\r\n");



WriteLiteral("    <p>\r\n        <button type=\"submit\" class=\"btn btn-primary\">\r\n            <i c" +
"lass=\"icon-user\"></i>评论</button>\r\n    </p>\r\n");



WriteLiteral("    <div class=\"fix\">\r\n    </div>\r\n");


            
            #line 31 "..\..\Views\Blog\_UserReply.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral(@"<script type=""text/javascript"">
    $(function () { 
        $(""#SaveMessageFrom"").ajaxPostForm(function() {
            // 评论前验证
            if ($.trim($(""#Comment"").val()) == """") {  
                cotide.dialog.showResultMsg(""msgTip"", ""请输入您的评论内容!"", ""info"");
                return false;
            }
            return true;
        }, function () {
            // 评论成功
            $(""#Comment"").val("""");  
            cotide.dialog.showResultMsg(""msgTip"", ""评论成功!"", ""success"");
            $(""#articleCommentPanl"").ajaxLoadData(""");


            
            #line 45 "..\..\Views\Blog\_UserReply.cshtml"
                                              Write(Url.Action("ArticleComment", "Blog", new { @id = Model.ArticleId }));

            
            #line default
            #line hidden
WriteLiteral("\");\r\n        },function () {\r\n            // 评论失败\r\n            cotide.dialog.show" +
"ResultMsg(\"msgTip\", \"评论失败，请联系管理员!\", \"error\");\r\n        });\r\n    })\r\n</script>\r\n");


        }
    }
}
#pragma warning restore 1591
