#pragma checksum "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8a27c49a5235e54d873394a6483c82b908103c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_SaleOrders_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/SaleOrders/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8a27c49a5235e54d873394a6483c82b908103c5", @"/Areas/Admin/Views/SaleOrders/Index.cshtml")]
    public class Areas_Admin_Views_SaleOrders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TrainTicketSales.Models.Entity.SaleOrder>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Danh sách đặt vé</h1>\r\n\r\n    <div class=\"table-responsive\">\r\n        <table id=\"dtBasicExample\" class=\"table table-bordered\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 15 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 18 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 21 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.OrderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 24 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 27 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 30 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 33 "D:\VuongNQ\TrainTicketSales\TrainTicketSales\Areas\Admin\Views\SaleOrders\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.IdentityCard));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        Total\r\n                    </th>\r\n\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n\r\n");
            DefineSection("Script", async() => {
                WriteLiteral(@"
<script>
                var table = null;
                var BaoCao = (function () {
        return {
            renderDatatable: function () {
                if (table) {
                    table.destroy();
                }

                 table = $('#dtBasicExample').DataTable({
                    pageLength: 25,
                    order: [0, 'asc'],
                    ajax: {
                        url: '/Admin/SaleOrders/Index1',

                        dataSrc: function (res) {
                            if(res.status)
                            {
                            console.log(res.result);
                            return res.result;
                            }
                            else
                            {
                                return """";
                            }
                        }
                        //dataSrc: """"
                    },
                    columns: [
                        {
        ");
                WriteLiteral(@"                    ""title"": ""STT"",
                            ""width"": ""5%"",
                            ""data"": null,
                        },
                        //{
                        //    ""title"": ""Mã đặt vé"",
                        //    ""data"": ""code"",
                        //},
                        {
                            ""title"": ""Tên người đặt"",
                            ""data"": null,
                            ""mRender"": function (data, type, full) {
                                //return `<span class=""font-weight-bold"">${data.name}</span>`;
                                return `<a href=""${data.actionLink}""><span class=""font-weight-bold"">${data.name}</span></a> `;
                            }
                        },
                        {
                            ""title"": ""Mã đặt vé"",
                            ""data"": ""code"",
                        },
                        {
                            ""title"": ""Trạng thái"",
     ");
                WriteLiteral(@"                       ""data"": ""status"",
                        },
                        {
                            ""title"": ""Ngày đặt vé"",
                            ""data"": ""orderDate"",
                        },
                        {
                            ""title"": ""Số điện thoại"",
                            ""data"": ""phoneNumber"",
                        },
                        {
                            ""title"": ""Email"",
                            ""data"": ""email"",
                        },
                        {
                            ""title"": ""CMND"",
                            ""data"": ""identityCard"",
                        },
                        {
                            ""title"": ""Tổng tiền"",
                            ""data"": ""total"",
                        },
                        //{
                        //    ""title"": """",
                        //    ""data"": """",
                        //},
                    ]
           ");
                WriteLiteral(@"     });
                table.on('order.dt search.dt', function () {
                    table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                        cell.innerHTML = i + 1;
                    });
                }).draw();

                $('.dataTables_length').addClass('bs-select');
            },
            //triggerControls: () => {
            //    $(""#loctheonam"").on('change', function () {
            //        year = $(this).val();
            //        BaoCao.renderDatatable(year);
            //    })
            //},
        }
    })();
    BaoCao.renderDatatable();
    //BaoCao.triggerControls();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TrainTicketSales.Models.Entity.SaleOrder>> Html { get; private set; }
    }
}
#pragma warning restore 1591
