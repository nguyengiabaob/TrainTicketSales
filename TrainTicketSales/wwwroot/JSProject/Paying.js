import { error } from "jquery";

$(document).ready(function () {
    let countclick = 0;
    var currentGfgStep, nextGfgStep, previousGfgStep;
    var opacity;
    var current = 1;
    var steps = $(".step >div").length;
    console.log(steps)
    setProgressBar(current);
    $("#prev").click(function () {
        if (current > 1) {
            console.log(current)
            currentGfgStep = $(`.step >div:nth-child(${current})`);
            var active = $(` #step-img div:nth-child(${current}) img:nth-child(1)`);
            var inactive = $(`#step-img div:nth-child(${current}) img:nth-child(2)`);
            previousGfgStep = currentGfgStep.prev();
            inactive.show();
            active.hide();
            var percent = parseFloat(100 / steps) * current;
            $(".et-step-bar").removeClass("et-step-bar" + percent);
            // $("#progressbar li").eq($("fieldset")
            //     .index(currentGfgStep)).removeClass("active");

            previousGfgStep.show();
            currentGfgStep.hide();
            // currentGfgStep.animate({ opacity: 0 }, {
            //     step: function (now) {
            //         opacity = 1 - now;

            //         currentGfgStep.css({
            //             'display': 'none',
            //             'position': 'relative'
            //         });
            //         previousGfgStep.css({ 'opacity': opacity });
            //     },
            //     duration: 500
            // });
            setProgressBar(--current);
        }
    });
    onchangeText();
    if ($(".col-xs-8.et-col-md-4 .error").length > 0) {
        $(".col-xs-8.et-col-md-4  input").removeClass("errorvalidate");
    }
    function setProgressBar(currentStep) {
        var percent = parseFloat(100 / steps) * currentStep;
        percent = percent.toFixed();
        $(".et-step-bar").addClass("et-step-bar" + percent);
    }
    showTablePaying();
    $.get("/Cart/ListCart").done((res) => {
        let infomain;
        let infosub;
        $("#next").on('click', function () {
            
            if (countclick == 0) {
                var t = validateInfomation(res.result)
                console.log('123');
                $("#formmain").validate({
                    rules: {
                        mainName: "required",
                        mainEmail: {
                            required: true,
                            email: true
                        },
                        mainCMND: {
                            required: "required",
                        },
                        mainVerify: {
                            required: true,
                            equalTo: "#emailMain"
                        },
                        mainPhone: {
                            required: true,
                            maxlength: 15,
                        }

                    },
                    messages: {
                        mainName: "Vui lòng nhập họ tên!",
                        mainEmail: {
                            required: "Vui lòng nhập vào email",
                            email: "Email không hợp lệ !"
                        },
                        mainCMND: {
                            required: "Vui lòng nhập vào CMND",
                        },
                        mainVerify: {
                            required: "sdadas",
                            equalTo: "dsadasdasd"
                        },

                        mainPhone: {
                            required: "Vui lòng nhập số điện thoại",
                            maxlength: "số điện thoại không quá 10 ký tự",

                        }
                    },
                
                })
                var validateform = $("#formmain").valid();
                console.log($(".col-xs-8.et-col-md-4 .error"));
                if ($(".col-xs-8.et-col-md-4 .error").length > 0) {
                    $(".col-xs-8.et-col-md-4  input").addClass("errorvalidate");
                }
                else {
                    $(".col-xs-8.et-col-md-4  input").removeClass("errorvalidate");
                }
                var checkMethodPaying = $("#methodPaying").is(':checked');
                if (t == true && validateform === true && checkMethodPaying === true) {

                    infomain = getInFoMain();
                    currentGfgStep = $(`.step >div:nth-child(${current})`);
                    // var active= $(`.step div:nth-child(${current+1} img:ntn-child(1))`);
                    // var inactive= $(`.step div:nth-child(${current+1} img:ntn-child(2)`);
                    // console.log(active);
                    // console.log(inactive);
                    nextGfgStep = currentGfgStep.next();
                    var active = $(` #step-img div:nth-child(${current + 1}) img:nth-child(1)`);
                    var inactive = $(`#step-img div:nth-child(${current + 1}) img:nth-child(2)`);
                    console.log(active);
                    inactive.hide();
                    active.show();
                    // $("#progressbar li").eq($("fieldset")
                    //     .index(nextGfgStep)).addClass("active");
                    currentGfgStep.hide();
                    nextGfgStep.show();
                    loadInfo2();
                    countclick++;
                    // currentGfgStep.animate({ opacity: 0 }, {
                    //     step: function (no w) {
                    //         opacity = 1 -now;

                    //         currentGfgStep.css({
                    //             'display': 'none',
                    //             'position': 'relative'
                    //         });
                    //         nextGfgStep.css({ 'opacity': opacity });
                    //     },
                    //     duration: 500
                    // });
                    setProgressBar(++current);
                }
            }
            if (countclick == 2) {
                $.ajax({
                    url: "/api/SalesOrder",
                    method: "POST",
                    data: { saleOrder: data },
                    success: (res) => {
                        currentGfgStep = $(`.step >div:nth-child(${current})`);
                        // var active= $(`.step div:nth-child(${current+1} img:ntn-child(1))`);
                        // var inactive= $(`.step div:nth-child(${current+1} img:ntn-child(2)`);
                        // console.log(active);
                        // console.log(inactive);
                        nextGfgStep = currentGfgStep.next();
                        var active = $(` #step-img div:nth-child(${current + 1}) img:nth-child(1)`);
                        var inactive = $(`#step-img div:nth-child(${current + 1}) img:nth-child(2)`);
                        console.log(active);
                        inactive.hide();
                        active.show();
                        // $("#progressbar li").eq($("fieldset")
                        //     .index(nextGfgStep)).addClass("active");
                        currentGfgStep.hide();
                        nextGfgStep.show();
                        countclick++;
                        // currentGfgStep.animate({ opacity: 0 }, {
                        //     step: function (no w) {
                        //         opacity = 1 -now;

                        //         currentGfgStep.css({
                        //             'display': 'none',
                        //             'position': 'relative'
                        //         });
                        //         nextGfgStep.css({ 'opacity': opacity });
                        //     },
                        //     duration: 500
                        // });
                        setProgressBar(++current);
                    },
                    error: (e) => { console.log(e) }
                })

                
            }
            })
            //console.log(validateInfomation(res.result))
            //if (validateInfomation(res.result)==true) {

            
        let a = res.result;
        
        for (let i = 0; i < a.length; i++) {
            $(`.et-btn-cancel.paying-cancel-${i}`).on('click', function () {

                let data = a[i];
                $.ajax({
                    url: "/Cart/DeleteItemCart",
                    method: "POST",
                    data: { item: data },
                    success: (res) => {
                        console.log(res.status);
                        showTablePaying(); 
                    },
                    error: (e) => console.log(e)
                })
            })
        }
    })

})
function showTablePaying() {
    $.get("/Cart/ListCart").done((res) => {
        let a = res.result;
        let html = "";
        let total = 0;
        if (a.filter(item => item.direction == "DI").length > 0) {
            html += `<tr class="et-table-group-header cd">
                                <td colspan="1" style="text-align:center">
                                    <label>
                                        Chiều đi
                                    </label>
                                    <div>
                                        Vui lòng nhập địa chỉ cưu trú, lưu trú vào phần địa chỉ lưu trú kế bên
                                    </div>
                                </td>
                                <td colspan="7" style="text-align:left ; vertical-align:middle">
                                    <div class="input-group input-group-sm">
                                        <span class="style-input input-group-addon text-left" style="padding-right:22px">
                                            Địa chỉ nơi đi
                                            <span style="color:red;">*</span>
                                        </span>

                                        <input class=" container-paying form-control" placeholder="Ghi rõ số nhà, xã/phường, quận/huyện/thị xã, tỉnh/thành phố" style="border-top-right-radius: 4px !important;border-bottom-right-radius: 4px !important;" />
                                    </div>
                                    <div class="input-group input-group-sm">
                                        <span class=" style-input input-group-addon text-left">
                                            Địa chỉ nơi đến
                                            <span style="color:red;">*</span>
                                        </span>

                                        <input class="container-paying form-control" placeholder="Ghi rõ số nhà, xã/phường, quận/huyện/thị xã, tỉnh/thành phố" style="border-top-right-radius: 4px !important;border-bottom-right-radius: 4px !important;" />
                                    </div>
                                </td>
                            </tr>`

            for (let i = 0; i < a.length; i++) {
                if (a[i].direction == "DI") {
                    html += ` <tr class="info-sub-${i}">
                                <td class="et-table-cell" style="padding: 0px;border-bottom: solid 2px #ccc;">
                                    <div class="input-group input-group-sm " style="margin-bottom: 6px;width: 100%;">
                                        <span class="input-group-addon text-left " style="width: 84px;">Họ tên</span>
                                        <input type="text" placeholder="Thông tin hành khách" class="form-control input-sm" />
                                    </div>
                                    <div class="input-group input-group-sm" style="margin-bottom: 6px;width: 100%;">
                                        <span class=" input-group-addon text-left " style="width: 84px;">đối tượng</span>
                                        <select class="form-control input-sm">
                                                <option value="0" selected="selected" label="Người lớn">Người lớn</option>
                                                <option value="1" label="Trẻ em">Trẻ em</option>
                                                <option value="2" label="Người cao tuổi">Người cao tuổi</option>
                                        </select>
                                    </div>
                                    <div class="input-group input-group-sm" style="margin-bottom: 6px;width: 100%;">
                                        <span class=" text-left input-group-addon" style="width: 84px;">Số giấy tờ</span>
                                        <input type="text" placeholder="Số CMND/ Hộ chiếu/ Ngày tháng năm sinh trẻ em" class="form-control input-sm" />
                                    </div>
                                </td>
                                <td style="font-size: 10px;border-bottom: solid 2px #ccc;">
                                    <div class="text-center">
                                        <img src="~/Images/waring20.png" tooltip="Vé hết thời gian giữ, không còn trong giỏ vé.">
                                    </div>
                                    <div>
                                        <div>
                                            ${a[i].nameTrain}
                                        </div>
                                        <div>
                                           ${a[i].time}
                                        </div>
                                        <div>
                                            ${a[i].cabin}
                                        </div>
                                         <div>
                                            ${a[i].cabinName}
                                        </div>
                                    </div>
                                </td>
                                <td class="et-table-cell text-right" style="border-bottom: solid 2px #ccc;">
                                   ${Number(a[i].price).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                                </td>
                                @*Giảm đối tượng*@
                                <td class="et-table-cell text-right" style="border-bottom: solid 2px #ccc;">
                                    0
                                </td>
                                @*khuyến mại*@
                                <td class="et-table-cell text-left" style="border-bottom: solid 2px #ccc;">
                                    <div>
                                        Không có khuyến mại cho vé này
                                    </div>
                                </td>
                                @*Bảo hiểm*@
                                <td class="et-table-cell text-right" style="border-bottom: solid 2px #ccc;">
                                    1,000
                                </td>
                                @*Thành tiền*@
                                <td class="et-table-cell text-right" style="border-bottom: solid 2px #ccc;">
                                   ${Number(a[i].price + 1000).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                                </td>
                                <td style="vertical-align: middle;border-bottom: solid 2px #ccc;">
                                    <a class="et-btn-cancel paying-cancel-${i}">

                                    </a>
                                </td>
                            </tr>`
                    total += a[i].price + 1000;
                }
            }
        }
        if (a.filter(item => item.direction == "VE").length > 0) {

            html += `<tr class="et-table-group-header cd">
                                <td colspan="1" style="text-align:center">
                                    <label>
                                        Chiều về
                                    </label>
                                    <div>
                                      
                                    </div>
                                </td>
                                <td colspan="7" style="text-align:left ; vertical-align:middle visibility:hidden">
                                    <div class="input-group input-group-sm">
                                        <span class="style-input input-group-addon text-left" style="padding-right:22px">
                                            Địa chỉ nơi đi
                                            <span style="color:red;">*</span>
                                        </span>

                                        <input class=" container-paying form-control" placeholder="Ghi rõ số nhà, xã/phường, quận/huyện/thị xã, tỉnh/thành phố" style="border-top-right-radius: 4px !important;border-bottom-right-radius: 4px !important;" />
                                    </div>
                                    <div class="input-group input-group-sm">
                                        <span class=" style-input input-group-addon text-left">
                                            Địa chỉ nơi đến
                                            <span style="color:red;">*</span>
                                        </span>

                                        <input class="container-paying form-control" placeholder="Ghi rõ số nhà, xã/phường, quận/huyện/thị xã, tỉnh/thành phố" style="border-top-right-radius: 4px !important;border-bottom-right-radius: 4px !important;" />
                                    </div>
                                </td>
                            </tr>`

            for (let i = 0; i < a.length; i++) {
                if (a[i].direction == "VE") {
                    html += ` <tr class="info-sub-${i}">
                                <td class="et-table-cell" style="padding: 0px;border-bottom: solid 2px #ccc;">
                                    <div class="input-group input-group-sm" style="margin-bottom: 6px;width: 100%;">
                                        <span class="input-group-addon text-left " style="width: 84px;">Họ tên</span>
                                        <input type="text" placeholder="Thông tin hành khách" class="form-control input-sm" />
                                    </div>
                                    <div class="input-group input-group-sm" style="margin-bottom: 6px;width: 100%;">
                                        <span class=" input-group-addon text-left " style="width: 84px;">đối tượng</span>
                                        <select class="form-control input-sm">
                                                <option value="0" selected="selected" label="Người lớn">Người lớn</option>
                                                <option value="1" label="Trẻ em">Trẻ em</option>
                                                <option value="2" label="Người cao tuổi">Người cao tuổi</option>
                                        </select>
                                    </div>
                                    <div class="input-group input-group-sm" style="margin-bottom: 6px;width: 100%;">
                                        <span class=" text-left input-group-addon" style="width: 84px;">Số giấy tờ</span>
                                        <input type="text" placeholder="Số CMND/ Hộ chiếu/ Ngày tháng năm sinh trẻ em" class="form-control input-sm" />
                                    </div>
                                </td>
                                <td style="font-size: 10px;border-bottom: solid 2px #ccc;">
                                    <div class="text-center">
                                        <img src="~/Images/waring20.png" tooltip="Vé hết thời gian giữ, không còn trong giỏ vé.">
                                    </div>
                                    <div>
                                        <div>
                                            ${a[i].nameTrain}
                                        </div>
                                        <div>
                                           ${a[i].time}
                                        </div>
                                        <div>
                                            ${a[i].cabin}
                                        </div>
                                         <div>
                                            ${a[i].cabinName}
                                        </div>
                                    </div>
                                </td>
                                <td class="et-table-cell text-right" style="border-bottom: solid 2px #ccc;">
                                   ${Number(a[i].price).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                                </td>
                                @*Giảm đối tượng*@
                                <td class="et-table-cell text-right" style="border-bottom: solid 2px #ccc;">
                                    0
                                </td>
                                @*khuyến mại*@
                                <td class="et-table-cell text-left" style="border-bottom: solid 2px #ccc;">
                                    <div>
                                        Không có khuyến mại cho vé này
                                    </div>
                                </td>
                                @*Bảo hiểm*@
                                <td class="et-table-cell text-right" style="border-bottom: solid 2px #ccc;">
                                    1,000
                                </td>
                                @*Thành tiền*@
                                <td class="et-table-cell text-right" style="border-bottom: solid 2px #ccc;">
                                   ${Number(a[i].price + 1000).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}
                                </td>
                                <td style="vertical-align: middle;border-bottom: solid 2px #ccc;">
                                    <a class="et-btn-cancel paying-cancel-${i}">

                                    </a>
                                </td>
                            </tr>`
                    total += a[i].price + 1000;
                }
            }
        }
        $(".table-paying").html(html);
        $("tfoot .bg-info").html(
            `<td colspan="6">
            <span style="font-weight:700; float:right">Tổng tiền</span>
        </td>
        <td class="text-right" style="font-weight:700">
            <span>${Number(total).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}</span>
        </td>
        <td>&nbsp;</td>`)
        $(`.info-sub-0 input[placeholder="Thông tin hành khách"]`).on('input', function () {
            console.log('7894564');
            $(`.col-xs-8.et-col-md-4  input[name="mainName"]`).val($(this).val());

        });
        $(`.info-sub-0 input[placeholder="Số CMND/ Hộ chiếu/ Ngày tháng năm sinh trẻ em"]`).on('input', function () {
            console.log('7894564');
            $(`.col-xs-8.et-col-md-4  input[name="mainCMND"]`).val($(this).val());

        });
    })
}
function validateInfomation(Arr) {
    let checked = 0;
    for (let i = 0; i < Arr.length; i++) {
        const format = /[0-9]{9}/;
        let nameSub = $(`.info-sub-${i} input[placeholder="Thông tin hành khách"]`).text();
        let combox = $(`.info-sub-${i} select.form-control.input-sm option:selected`).val();
        console.log(nameSub);
        let cmnd = $(`.info-sub-${i} input[placeholder="Số CMND/ Hộ chiếu/ Ngày tháng năm sinh trẻ em"]`).text();
        if (nameSub == "" || combox == null || cmnd == "" || !format.test(cmnd)) {
            console.log($(`.info-sub-${i}  .input-group.input-group-sm`));
            $(`.info-sub-${i}  .input-group.input-group-sm`).addClass("errorvalidate");
            checked += 1;
            
        }
        
        else {
            $(`.info-sub-${i}  .input-group.input-group-sm`).removeClass("errorvalidate");
            
        }
    }
    if (checked > 0)
        return false;
    else {
        return true;
    }

}
function onchangeText() {
    
    $(`.col-xs-8.et-col-md-4  input[name = "mainName"]`).on('input', function () {
        $(`.info-sub-0 input[placeholder="Thông tin hành khách"]`).val($(this).val());

    });
    $(`.col-xs-8.et-col-md-4  input[name = "mainCMND"]`).on('input', function () {
        $(`.info-sub-0 input[placeholder="Số CMND/ Hộ chiếu/ Ngày tháng năm sinh trẻ em"]`).val($(this).val());

    });
}
function getInFoMain() {
    let subIfo = [];
    let mainName = $(`.col-xs-8.et-col-md-4  input[name = "mainName"]`).text();
    let orderDay = new Date.now();
    let mainPhone = $(`.col-xs-8.et-col-md-4  input[name = "mainPhone"]`).text();
    let mainemail = $(`.col-xs-8.et-col-md-4  input[name = "mainEmail"]`).text();
    let maincmnd = $(`.col-xs-8.et-col-md-4  input[name = "mainCMND"]`).text();
    $.get("/Cart/ListCart").done((res) => {
        let a = res.result
        for (let i = 0; i < a.length; i++) {
            let nameSub = $(`.info-sub-${i} input[placeholder="Thông tin hành khách"]`).text();
            let combox = $(`.info-sub-${i} select.form-control.input-sm option:selected`).val();
            let cmnd = $(`.info-sub-${i} input[placeholder="Số CMND/ Hộ chiếu/ Ngày tháng năm sinh trẻ em"]`).text();
            let seatid = a[i].id;
            let item = {
                id: 0,
                saleOrderId: 0,
                name: nameSub,
                identityCard: cmnd,
                adult: combox> 0 ? false : true,
                seatId: String(seatid)
            }
            subIfo.push(item);
        }
    })

    let mainInfo = {
        name: mainName,
        orderDate: orderDay,
        phoneNumber: mainPhone,
        email: mainemail,
        identityCard: maincmnd,
        saleOrderDetail: subIfo,

    }
    return mainInfo;
}
function loadInfo2(info) {
    $("#VerifyInfo").html(` <table style="width:100%">
                            <tr>
                                <td>
                                    <table style="width:80%">
                                        <tr>
                                            <td width="50%">
                                                <span> họ tên</span>
                                            </td>
                                            <td width="50%">
                                                <span style="font-weight:700"> ${info.name}</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table style="width:80%">
                                        <tr>
                                            <td width="50%">
                                                <span>Mã hội viên</span>
                                            </td>
                                            <td width="50%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width:80%">
                                        <tr>
                                            <td width="50%">
                                                <span> CMND/hộ chiếu:</span>
                                            </td>
                                            <td width="50%">
                                                <span style="font-weight:700"> ${info.identityCard}</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <table style="width:80%">
                                        <tr>
                                            <td width="50%">
                                                <span> số di động:</span>
                                            </td>
                                            <td width="50%">
                                                <span style="font-weight:700">${info.phoneNumber}</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <table style="width:80%">
                                        <tr>
                                            <td width="50%">
                                                <span> Email:</span>
                                            </td>
                                            <td width="50%">
                                                <span style="font-weight:700">${info.email}</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width:80%">
                                        <tr>
                                            <td width="50%">
                                                <span>Phương thức thanh toán </span>
                                            </td>
                                            <td width="50%">
                                                <span style="font-weight:700">Phương thức thanh toán trả sau</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </table>`)

    $.get("/Cart/ListCart").done((res) => {
        let html = "";
        let countMoney = 0;
        let b = [...res]
        let d = [...info.saleOrderDetail];
        if (b.length > 0) {
            for (let i = 0; i < b.length; i++) {
                d.forEach(item => {
                    if (item.seatId === b[i].id) {

                        html += `  <tr>
                                <td>
                                    <p>1</p>
                                </td>
                                <td>
                                    <div>
                                        <div style="display:flex">
                                            <div style="margin-right:15px">
                                                Họ tên : ${item.name}
                                            </div>
                                            <div>
                                               đối tượng : ${item.adult > 0 ? 'trẻ em' : 'Ngưởi lớn'}
                                            </div>
                                            <div style="margin-right:15px">
                                               Số giấy tờ :${item.identityCard}
                                            </div>
                                        </div>
                                        <div>
                                            Hành trình :${b[i].nameTrain + b[i].time + b[i].Cabin + b[i].cabinName}
                                        </div>
                                    </div>
                                </td>
                          
                            </tr>`
                        countMoney += b[i].price + 1000;
                    }
                })


            }
            $(".tb-detail tbody").html(html + `<tr>
                                <td colspan="2">
                                    <span style="float:right; font-weight:700">Tông tiền</span>
                                </td>
                                <td colspan="2">
                                    <span style="float:right; font-weight:700">${Number(countMoney).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')}</span>
                                </td>
                            
                            </tr>`)
        }
    })
  
}

    
}