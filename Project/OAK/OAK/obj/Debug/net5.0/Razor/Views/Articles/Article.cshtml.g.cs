#pragma checksum "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ef09ca565aabda428cbdc03b046294bf4b22907"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Articles_Article), @"mvc.1.0.view", @"/Views/Articles/Article.cshtml")]
namespace AspNetCore
{
    #line hidden
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\_ViewImports.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\_ViewImports.cshtml"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\_ViewImports.cshtml"
using System.Threading.Tasks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\_ViewImports.cshtml"
using OAK.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\_ViewImports.cshtml"
using OAK.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ef09ca565aabda428cbdc03b046294bf4b22907", @"/Views/Articles/Article.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f76cc2e4116cae2e1b3085a713b3710e1ae1225", @"/Views/_ViewImports.cshtml")]
    public class Views_Articles_Article : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Article>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("profile_settings"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/icons/settings.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EditArticle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("article-views"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/icons/views.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("article-likes"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/icons/favorite no.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
  
    Autor CurrentUser = User.GetCurrentUser().Result;
    List<(string Type, short Number, byte[] Data)> Content = ViewBag.Content;

    string RightString(string str, int len)
    {

        StringBuilder rstr = new StringBuilder(str);
        rstr = rstr.Replace("\r\n", "</br>");

        int flag = 0;

        for (int i = 0; i < rstr.Length; i++)
        {
            flag++;
            if (rstr[i] == ' ') { flag = 0; }
            if (flag == len)
            {
                rstr = rstr.Insert(i, "</br>");
                i += 5;
                flag = 0;
            }
        }

        return rstr.ToString();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 32 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
Write(await Html.PartialAsync("~/Views/Articles/Article/_jsSetLikePartial.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 34 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
Write(await Html.PartialAsync("~/Views/Articles/Article/_ArticleInformationPartial.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<!-- Статья -->\r\n<div class=\"article\">\r\n    <!-- Заголовок -->\r\n    <h1 class=\"article_title\">");
#nullable restore
#line 40 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
                         Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n\r\n");
#nullable restore
#line 43 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
     if (CurrentUser != null && Model.AutorID == CurrentUser?.ID)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ef09ca565aabda428cbdc03b046294bf4b229078978", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2ef09ca565aabda428cbdc03b046294bf4b229079245", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
                                                                  WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr>\r\n\r\n");
#nullable restore
#line 51 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
     foreach (var item in Content)
    {
        if (item.Type == "text")
        {
            string value = Encoding.UTF8.GetString(item.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"article_text\">");
#nullable restore
#line 56 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
                               Write(Html.Raw(RightString(value, 50)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 57 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
        }
        else if (item.Type == "sub")
        {
            string value = Encoding.UTF8.GetString(item.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"article_subtitle\">");
#nullable restore
#line 61 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
                                   Write(Html.Raw(RightString(value, 40)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 62 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
        }
        else if (item.Type == "img")
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
       Write(Html.Raw("<img class='article_image' " +
                "src=\"data:image/png; base64," + Convert.ToBase64String(item.Data) + "\" />"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
                                                                                              
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2ef09ca565aabda428cbdc03b046294bf4b2290714924", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <p class=\"article-views-count\">");
#nullable restore
#line 72 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
                              Write(Model.Views);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n    <div id=\"like\" style=\"cursor:pointer;\" data-url=\"");
#nullable restore
#line 74 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
                                                 Write(Url.Action("SetLike") + "?id=" + Model.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2ef09ca565aabda428cbdc03b046294bf4b2290716693", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <p class=\"article-likes-count\">");
#nullable restore
#line 76 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
                                  Write(Model.LikesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n\r\n            $.get(\"");
#nullable restore
#line 84 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Articles\Article.cshtml"
               Write(Url.Action("ArticleIsLiked") + "?id=" + Model.ID);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""").done(function (data) {
                SetLike(data, ""#like"");
            });

            $(""#like"").click(function () {
                $.get($(this).data(""url"")).done(function (data) {
                    SetLike(data.access, ""#like"");
                    $(""#like > p"").text(data.count);
                });
            });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICurrentUser User { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Article> Html { get; private set; }
    }
}
#pragma warning restore 1591
