#pragma checksum "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "456878bf4665665f26d28ed9ad73dcd708134aae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Views\_ViewImports.cshtml"
using TrainTicketSales;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Views\_ViewImports.cshtml"
using TrainTicketSales.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"456878bf4665665f26d28ed9ad73dcd708134aae", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd9cec730505dec38fceb63d41156386e7b4e5dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formSearch"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/JSProject/Home.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Views\Home\Index.cshtml"
  

    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Trang ch???";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .dropbtn {
        background-color: #04AA6D;
        color: white;
        padding: 16px;
        font-size: 16px;
        border: none;
        cursor: pointer;
    }

        .dropbtn:hover, .dropbtn:focus {
            background-color: #3e8e41;
        }

    #myInput {
        box-sizing: border-box;
        background-image: url('searchicon.png');
        background-position: 14px 12px;
        background-repeat: no-repeat;
        font-size: 16px;
        padding: 14px 20px 12px 45px;
        border: none;
        border-bottom: 1px solid #ddd;
    }

        #myInput:focus {
            outline: 3px solid #ddd;
        }

    .dropdown {
        position: relative;
        display: inline-block;
    }

    .dropdown-content {
        display: none;
        position: absolute;
        background-color: #f6f6f6;
        min-width: 230px;
        overflow: auto;
        border: 1px solid #ddd;
        z-index: 1;
    }

        .dropdown-content a ");
            WriteLiteral(@"{
            color: black;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
        }

    .dropdown a:hover {
        background-color: #ddd;
    }

    .show {
        display: block;
    }
</style>

<div style=""width:100%"">
    
    <div class=""row"">
        
        <div class=""col-xs-12 col-sm-4 et-col-md-3"">
            <div class=""col-md-12 et-widget"" style=""margin-bottom: 5px;"" >
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "456878bf4665665f26d28ed9ad73dcd708134aae5839", async() => {
                WriteLiteral(@"
                    <div style=""align-items:center"" class=""row et-widget-header"">
                        <img style=""height:10px ;margin-left:5px"" src=""./Images/widgetIcon.png"" />
                        <span>Th??ng tinh h??nh tr??nh</span>
                    </div>
                    <div class=""form-group style-title2"">
                        <h6 class=""ng-binding"">Ga ??i</h6>
                        <span id=""errornameA""></span>
                        <input id=""StartingStation"" name=""nameA"" type=""text"" class=""form-control input-sm"">

                    </div>
                    <div class=""form-group style-title2"">
                        <h6 class=""ng-binding"">Ga v???</h6>
                        <span id=""errornameB""></span>
                        <input id=""stops"" name=""nameB"" type=""text"" class=""form-control input-sm"">

                    </div>
                    <div class=""et-direct-block"">
                        <input type=""radio"" value=""0"" name=""oneWay"">
                ");
                WriteLiteral(@"        <span>M???t chi???u</span>
                        <input type=""radio"" value=""1"" name=""oneWay"">
                        <span>kh??? h???i</span>
                    </div>
                    <div class=""form-group style-title2"">
                        <h6 class=""ng-binding"">Ng??y ??i</h6>
                        <span id=""errordateA""></span>
                        <div class='input-group date' id='datetimepicker1'>
                            <input type=""text"" name=""dateA"" class=""form-control input-sm"" >
                            <span class=""input-group-addon"" style=""display: flex; justify-content: center; align-items: center;"">
                                <span class=""fa fa-calendar""></span>
                            </span>

                        </div>
                    </div>
                    <div class=""form-group style-title2"">
                        <h6 class=""ng-binding"">Ng??y v???</h6>
                        <span id=""errordateB""></span>
                        <div");
                WriteLiteral(@" class='input-group date' id='datetimepicker'>
                            <input type=""text"" name=""dateB"" class=""form-control input-sm"" >
                            <span class=""input-group-addon"" style=""display: flex; justify-content: center; align-items: center;"">
                                <span><i class=""fa fa-calendar""></i></span>
                            </span>
                        </div>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""  col-md-12 text-center"" style=""margin-top: 2px;"">
                    <a id=""btn-search-main"" class=""btn btn-sm et-btn "">T??m ki???m</a>
                </div>
            </div>
        </div>
        <div class=""col-xs-12 col-sm-8 et-col-md-6"">
            <div class=""et-col-md-12 et-widget alert alert-info"" style=""margin-bottom: 0px;color:#0091d4"">
                <p>
                    Th???c hi???n Quy???t ?????nh s??? 1839/Q??-BGTVT ng??y 20/10/2021 c???a B??? GTVT
                    H?????ng d???n t???m th???i v??? t??? ch???c ho???t ?????ng v???n t???i h??nh kh??ch b???ng ??S ?????m b???o th??ch ???ng an to??n, linh ho???t, k
                    i???m so??t hi???u qu??? d???ch Covid 19, qu?? kh??ch vui l??ng ?????c k??? m???c ??i???u ki???n h??nh kh??ch ??i t??u t??? ng??y 21/10/2021
                    b??n d?????i.
                    <br />
                <p>Ngo??i ra ????? ki???m so??t v?? ng??n ng???a d???ch b???nh Covid-19, Ng??nh ???????ng s???t k??nh ????? ngh??? Qu?? kh??ch h??ng khi ?????n ga mua v?? ho???c ??i t??u th???c hi???n c??c bi???n ph??p ph??ng ch???ng d???ch b???nh theo TH??NG ??I???P");
            WriteLiteral(" 5K c???a B??? Y t??? Kh???u trang ??? Kh??? khu???n ??? Kho???ng c??ch ??? Kh??ng t???p trung ??? Khai b??o y t???<</p>\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Script", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "456878bf4665665f26d28ed9ad73dcd708134aae11160", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
<script>
        function myFunction() {
      document.getElementById(""myDropdown"").classList.toggle(""show"");
    }

    function filterFunction() {
      var input, filter, ul, li, a, i;
      input = document.getElementById(""myInput"");
      filter = input.value.toUpperCase();
      div = document.getElementById(""myDropdown"");
      a = div.getElementsByTagName(""a"");
      for (i = 0; i < a.length; i++) {
        txtValue = a[i].textContent || a[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
          a[i].style.display = """";
        } else {
          a[i].style.display = ""none"";
        }
      }
    }
</script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
