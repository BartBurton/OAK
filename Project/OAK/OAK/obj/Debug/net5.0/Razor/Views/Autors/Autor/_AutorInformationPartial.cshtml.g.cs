#pragma checksum "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Autors\Autor\_AutorInformationPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f371282261c632707644982d935733269df34d87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Autors_Autor__AutorInformationPartial), @"mvc.1.0.view", @"/Views/Autors/Autor/_AutorInformationPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f371282261c632707644982d935733269df34d87", @"/Views/Autors/Autor/_AutorInformationPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f76cc2e4116cae2e1b3085a713b3710e1ae1225", @"/Views/_ViewImports.cshtml")]
    public class Views_Autors_Autor__AutorInformationPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Autor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("profile_settings"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/icons/settings.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EditProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Autors\Autor\_AutorInformationPartial.cshtml"
  
    Autor CurrentUser = User.GetCurrentUser().Result;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"autor_inf\">\r\n    <div class=\"autor_img_center\">\r\n        ");
#nullable restore
#line 9 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Autors\Autor\_AutorInformationPartial.cshtml"
   Write(Html.Raw("<img class='autor_img' " +
        "src=\"data:image/png; base64," + Convert.ToBase64String(Model.Avatar) + "\" />"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <p class=\"autor_name\">");
#nullable restore
#line 13 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Autors\Autor\_AutorInformationPartial.cshtml"
                     Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n");
#nullable restore
#line 16 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Autors\Autor\_AutorInformationPartial.cshtml"
     if (Model.ID == CurrentUser?.ID)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f371282261c632707644982d935733269df34d876860", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f371282261c632707644982d935733269df34d877127", async() => {
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Autors\Autor\_AutorInformationPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <p class=\"autor_status\">");
#nullable restore
#line 24 "C:\Users\MAXXXYMIRON\Desktop\OAK\Project\OAK\OAK\Views\Autors\Autor\_AutorInformationPartial.cshtml"
                       Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Autor> Html { get; private set; }
    }
}
#pragma warning restore 1591
