#pragma checksum "D:\TrainTicketSales\TrainTicketSales\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9c9b7ca6ce1d33a6258f89dcb3294fd0a272e82"
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
#line 1 "D:\TrainTicketSales\TrainTicketSales\Views\_ViewImports.cshtml"
using TrainTicketSales;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\TrainTicketSales\TrainTicketSales\Views\_ViewImports.cshtml"
using TrainTicketSales.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9c9b7ca6ce1d33a6258f89dcb3294fd0a272e82", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd9cec730505dec38fceb63d41156386e7b4e5dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\TrainTicketSales\TrainTicketSales\Views\Home\Index.cshtml"
  
    
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Trang chủ";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div style=""width:100%"">
    <div class=""row"">
    <div class=""col-xs-12 col-sm-4 et-col-md-3"">
        <div class=""col-md-12 et-widget"" style=""margin-bottom: 5px;"">
            <div class=""row et-widget-header"">
                <img style=""height:10px"" src=""./Images/widgetIcon.png"" />
                <span>Thông tinh hành trình</span>
            </div>
            <div class=""form-group style-title2"">
                <h6 class=""ng-binding"">Ga đi</h6>
                <span class=""control-label ng-binding ng-hide"" ng-show=""gaDiError"">Ga đi không hợp lệ</span>
                <input type=""text"" class=""form-control input-sm"">
            </div>
            <div class=""form-group style-title2"">
                <h6 class=""ng-binding"">Ga về</h6>
                <span class=""control-label ng-binding ng-hide"" ng-show=""gaDiError"">Ga đi không hợp lệ</span>
                <input type=""text"" class=""form-control input-sm"">
            </div>
            <div class=""et-direct-block"">
                <i");
            WriteLiteral(@"nput type=""radio"" value=""0"" name=""oneWay"">
                <span>Một chiều</span>
                <input type=""radio"" value=""0"" name=""oneWay"">
                <span>khứ hồi</span>
            </div>
            <div class=""form-group style-title2"">
                <h6 class=""ng-binding"">Ngày đi</h6>
                <span class=""control-label ng-binding ng-hide"" ng-show=""gaDiError"">Ga đi không hợp lệ</span>
                <div class='input-group date' id='datetimepicker1'>
                    <input type=""text"" class=""form-control input-sm"">
                    <span class=""input-group-addon"" style=""display: flex; justify-content: center; align-items: center;"">
                        <span class=""fa fa-calendar""></span>
                    </span>

                </div>
            </div>
            <div class=""form-group style-title2"">
                <h6 class=""ng-binding"">Ngày đi</h6>
                <span class=""control-label ng-binding ng-hide"" ng-show=""gaDiError"">Ga đi không hợp lệ<");
            WriteLiteral(@"/span>
                <div class='input-group date' id='datetimepicker'>
                    <input type=""text"" class=""form-control input-sm"">
                    <span class=""input-group-addon"" style=""display: flex; justify-content: center; align-items: center;"">
                        <span><i class=""fa fa-calendar""></i></span>
                    </span>
                </div>
            </div>
            <div class="" col-md-12 text-center"" style=""margin-top: 2px;"">
                <a class=""btn btn-sm et-btn "">Tìm kiếm</a>
            </div>
        </div>
    </div>
        <div class=""col-xs-12 col-sm-8 et-col-md-6"">
            <div class=""et-col-md-12 et-widget alert alert-info"" style=""margin-bottom: 0px;color:#0091d4"">
                <p>
                    Thực hiện Quyết định số 1839/QĐ-BGTVT ngày 20/10/2021 của Bộ GTVT
                    Hướng dẫn tạm thời về tổ chức hoạt động vận tải hành khách bằng ĐS đảm bảo thích ứng an toàn, linh hoạt, k
                    iểm soát hi");
            WriteLiteral(@"ệu quả dịch Covid 19, quý khách vui lòng đọc kỹ mục Điều kiện hành khách đi tàu từ ngày 21/10/2021
                    bên dưới.
                    <br />
                <p>Ngoài ra để kiểm soát và ngăn ngừa dịch bệnh Covid-19, Ngành Đường sắt kính đề nghị Quý khách hàng khi đến ga mua vé hoặc đi tàu thực hiện các biện pháp phòng chống dịch bệnh theo THÔNG ĐIỆP 5K của Bộ Y tế Khẩu trang – Khử khuẩn – Khoảng cách – Không tập trung – Khai báo y tế<</p>
                </p>
            </div>
        </div>
        </div>
</div>
");
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