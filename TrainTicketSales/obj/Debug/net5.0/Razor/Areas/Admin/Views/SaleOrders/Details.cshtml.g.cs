#pragma checksum "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0efd88d57c26eca3486a03ce3b522f7d3432512e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_SaleOrders_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/SaleOrders/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0efd88d57c26eca3486a03ce3b522f7d3432512e", @"/Areas/Admin/Views/SaleOrders/Details.cshtml")]
    public class Areas_Admin_Views_SaleOrders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TrainTicketSales.ModelsViews.SaleOrderViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Chi tiết đơn hàng</h1>\r\n\r\n<dl class=\"row\">\r\n    <dd><input type=\"hidden\" id=\"id\"");
            BeginWriteAttribute("value", " value=\"", 298, "\"", 317, 1);
#nullable restore
#line 11 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
WriteAttributeValue("", 306, Model.Id, 306, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></dd>\r\n\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 14 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 17 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 20 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.OrderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 23 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayFor(model => model.OrderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 26 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 29 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 32 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 35 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 38 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.IdentityCard));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 41 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayFor(model => model.IdentityCard));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n        <dt class=\"col-sm-4\">\r\n        ");
#nullable restore
#line 44 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-8\">\r\n        ");
#nullable restore
#line 47 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Details.cshtml"
   Write(Html.DisplayFor(model => model.StatusName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n   \r\n\r\n</dl>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0efd88d57c26eca3486a03ce3b522f7d3432512e7478", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrainTicketSales.ModelsViews.SaleOrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
