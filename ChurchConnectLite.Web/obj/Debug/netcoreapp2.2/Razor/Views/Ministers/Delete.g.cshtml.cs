#pragma checksum "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0fbb496230e8c19a978c3f77cf205f5a092f64fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ministers_Delete), @"mvc.1.0.view", @"/Views/Ministers/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ministers/Delete.cshtml", typeof(AspNetCore.Views_Ministers_Delete))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\_ViewImports.cshtml"
using ChurchConnectLite.Web;

#line default
#line hidden
#line 2 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\_ViewImports.cshtml"
using ChurchConnectLite.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fbb496230e8c19a978c3f77cf205f5a092f64fe", @"/Views/Ministers/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a11b0d52d295d2f7ce312ea9911f7510ac35ffe5", @"/Views/_ViewImports.cshtml")]
    public class Views_Ministers_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ChurchConnectLite.Core.Entities.Minister>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(93, 178, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Minister</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(272, 40, false);
#line 15 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(312, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(376, 36, false);
#line 18 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(412, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(475, 41, false);
#line 21 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.About));

#line default
#line hidden
            EndContext();
            BeginContext(516, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(580, 37, false);
#line 24 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.About));

#line default
#line hidden
            EndContext();
            BeginContext(617, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(680, 44, false);
#line 27 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.FaceBook));

#line default
#line hidden
            EndContext();
            BeginContext(724, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(788, 40, false);
#line 30 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.FaceBook));

#line default
#line hidden
            EndContext();
            BeginContext(828, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(891, 43, false);
#line 33 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Twitter));

#line default
#line hidden
            EndContext();
            BeginContext(934, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(998, 39, false);
#line 36 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Twitter));

#line default
#line hidden
            EndContext();
            BeginContext(1037, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1100, 52, false);
#line 39 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.InstagramProfile));

#line default
#line hidden
            EndContext();
            BeginContext(1152, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1216, 48, false);
#line 42 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.InstagramProfile));

#line default
#line hidden
            EndContext();
            BeginContext(1264, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1327, 41, false);
#line 45 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1368, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1432, 37, false);
#line 48 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1469, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1532, 41, false);
#line 51 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(1573, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1637, 37, false);
#line 54 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
            EndContext();
            BeginContext(1674, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1737, 46, false);
#line 57 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PictureUrl));

#line default
#line hidden
            EndContext();
            BeginContext(1783, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1847, 42, false);
#line 60 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PictureUrl));

#line default
#line hidden
            EndContext();
            BeginContext(1889, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1952, 47, false);
#line 63 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DateEntered));

#line default
#line hidden
            EndContext();
            BeginContext(1999, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2063, 43, false);
#line 66 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DateEntered));

#line default
#line hidden
            EndContext();
            BeginContext(2106, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2169, 43, false);
#line 69 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AppUser));

#line default
#line hidden
            EndContext();
            BeginContext(2212, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2276, 42, false);
#line 72 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AppUser.Id));

#line default
#line hidden
            EndContext();
            BeginContext(2318, 68, true);
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2387, 42, false);
#line 75 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Church));

#line default
#line hidden
            EndContext();
            BeginContext(2429, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2493, 41, false);
#line 78 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Church.ID));

#line default
#line hidden
            EndContext();
            BeginContext(2534, 44, true);
            WriteLiteral("\r\n        </dd class>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(2578, 206, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fbb496230e8c19a978c3f77cf205f5a092f64fe15217", async() => {
                BeginContext(2604, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2614, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0fbb496230e8c19a978c3f77cf205f5a092f64fe15610", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 83 "C:\Users\Administrator\source\repos\Main ChurchConnect - DONE\ChurchConnectLite.Web\Views\Ministers\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2650, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(2733, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0fbb496230e8c19a978c3f77cf205f5a092f64fe17550", async() => {
                    BeginContext(2755, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2771, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2784, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChurchConnectLite.Core.Entities.Minister> Html { get; private set; }
    }
}
#pragma warning restore 1591
