#pragma checksum "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f84a223e41367d482b9f42a4b33df4a5773b0c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Trains_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Trains/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f84a223e41367d482b9f42a4b33df4a5773b0c9", @"/Areas/Admin/Views/Trains/Details.cshtml")]
    public class Areas_Admin_Views_Trains_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TrainTicketSales.Models.Entity.Train>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Train</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Des));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
       Write(Html.DisplayFor(model => model.Des));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n    <hr />\r\n    <h4>Tổng số khoang</h4>\r\n    <table id=\"tb\" class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 34 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Cabin.ToList()[0].Index));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Cabin Code\r\n                </th>\r\n                <th>\r\n                    Des\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 46 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
             foreach (var item in Model.Cabin)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 50 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Index));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 53 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CabinCategoryCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CabinCategoryCodeNavigation.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n\r\n\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1647, "\"", 1706, 1);
#nullable restore
#line 61 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
WriteAttributeValue("", 1654, Url.Action("Details", "Cabins", new {id =@item.Id}), 1654, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> Details</a>|\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 65 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1861, "\"", 1887, 1);
#nullable restore
#line 70 "D:\VuongNQ\Code\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\Trains\Details.cshtml"
WriteAttributeValue("", 1876, Model.Code, 1876, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n");
            DefineSection("Script", async() => {
                WriteLiteral("\r\n<script>\r\n            // Call the dataTables jQuery plugin\r\n    $(document).ready(function() {\r\n      $(\'#tb\').DataTable();\r\n    });\r\n</script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrainTicketSales.Models.Entity.Train> Html { get; private set; }
    }
}
#pragma warning restore 1591