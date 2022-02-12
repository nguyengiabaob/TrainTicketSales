$(document).ready(function () {
    $(function () {
        $('#datetimepicker1').datetimepicker({
            format: "DD/MM/YYYY",
            date: new Date()
        });
        $('#datetimepicker').datetimepicker({
            format: "DD/MM/YYYY"
        });
    });
    let sBegin = localStorage.getItem('StationBegin');
    let SEnd = localStorage.getItem('StationEnd');
    let date = moment('8/2/2022', 'DD/MM/yyyy').toDate();
    console.log(moment(date).format("YYYY/MM/DD"));
    let option = localStorage.getItem('Option');
    if (option == 0 || option == 1) {
        ShowTwoWay(sBegin, SEnd, date, 0);

        //$.get('api/Schedules/GetTrain?StationBegin=' + sBegin + '&StationEnd=' + SEnd + '&date=' + `${moment(date).format("YYYY/MM/DD")}`).done(res => {
        //    let data = [];
        //    let htmlTrain = "";
        //    data = res;
        //    let stt = 1;
        //    let trainClick = 0;
        //    console.log(data);
        //    $.each(data, function (i, e) {

        //        htmlTrain += `<div class="col-xs-4 col-sm-3 et-col-md-2 et-train-block active-train-${e.id}"}  data-stt=${stt}>
        //                <div class="et-train-head">
        //                    <div style="width: 40%; margin-bottom: 3px" class="center-block">
        //                        <div style="color: rgb(85, 85, 85);" class="et-train-lamp text-center ng-binding">
        //                            ${e.trainsList[0].name}
        //                        </div>
        //                    </div>
        //                    <div class="et-train-head-info">
        //                        <div class="et-no-margin">
        //                            <span class="float-left et-bold">
        //                                TG đi
        //                            </span>
        //                            <span class="float-right">
        //                                ${moment(new Date(e.dateBegin)).format("DD/MM HH:SS")}
        //                            </span>
        //                        </div>
        //                        <div class="et-no-margin">
        //                            <span class="float-left et-bold">
        //                                TG đên
        //                            </span>
        //                            <span class="float-right ">
        //                                ${moment(new Date(e.dateEnd)).format("DD/MM HH:SS")}
        //                            </span>
        //                        </div>
        //                        <div class="et-no-margin">
        //                            <div class="et-col-50">
        //                                <div class="et-text-sm">
        //                                    SL chỗ Đặt
        //                                </div>
        //                                <div style="margin-left: 5px;" class="et-text-large et-bold float-left">
        //                                    0
        //                                </div>

        //                            </div>
        //                            <div class="et-col-50 text-center">
        //                                <div class="et-text-sm">
        //                                    SL chỗ trống
        //                                </div>
        //                                <div style="margin-right: 5px;" class="et-text-large et-bold float-right">
        //                                    260
        //                                </div>
        //                            </div>
        //                        </div>
        //                    </div>
        //                    <div class="et-no-margin">
        //                        <div class="et-col-50">
        //                            <span class="et-train-lamp-bellow-left"></span>
        //                        </div>
        //                        <div class="et-col-50">
        //                            <span class="et-train-lamp-bellow-right"></span>
        //                        </div>
        //                    </div>
        //                </div>
        //                <div class="et-train-base"></div>
        //                <div class="et-train-base-2"></div>
        //                <div class="et-train-base-3"></div>
        //                <div class="et-train-base-4"></div>
        //                <div class="et-train-base-5"></div>
        //            </div>`
        //        stt++;
        //    })
        //    //$('.train-group').html(htmlTrain);
        //    let htmlhead = `<div class="row et-page-header" style="margin-bottom: 40px;">
        //        <span class="et-main-label">
        //            ngày ${date} từ Hà Nội đến Sài Gòn
        //        </span>
        //    </div>
        //     <div class="row et-train-list">
        //        <div class="train-group">`
        //        + htmlTrain +
        //        `</div>
        //    </div>
        //    <div class="row"  style="margin-left: -10px;">
        //        <div class="col-md-12 et-no-margin ListCabin">`
        //    $(".col-xs-12 .col-sm-9 .et-col-md-9").html(htmlhead);
        //    $.each(data, function (i, e) {

        //        $(`.active-train-${e.id}`).on('click', function () {
        //            if (trainClick != 0) {
        //                $(`.active-train-${trainClick} .et-train-head`).removeClass("et-train-head-selected");
        //            }
        //            $(`.active-train-${e.id} .et-train-head`).addClass("et-train-head-selected");
        //            let CabinList = [...e.trainsList[0].cabin];
        //            let htmlCabin = "";
        //            let stt = 0;
        //            let activeCabin = 0;

        //            CabinList.reverse().map((item) => {
        //                htmlCabin += `<div class="et-car-block  active-Cabin-${item.id}">
        //            <div class="et-car-icon et-car-icon-avaiable">
        //                <img style="width:48px ; height:23px" src='/Images/trainCar2.png' />
        //            </div>
        //            <div class="text-center text-info et-car-label">${item.index}</div>
        //        </div>`


        //            })
        //            htmlCabin += `<div class="et-car-block">
        //            <div class="et-car-icon">
        //                <img style="width:48px ; height:23px" src='/Images/train2.png' />
        //            </div>
        //            <div class="text-center text-info et-car-label ng-binding">${e.trainCode}</div>
        //        </div>`
        //            htmlCabin += `</div>
        //                   <div class="row et-car-floor-region" style="width: 100%;">
        //            <div class=" col-xs-12 col-sm-12 col-md-12 text-center tile-cabin">`
        //            $('#ListCabin').html(htmlCabin);
        //            CabinList.reverse().map(async item => {

        //                let seat = await CountSeatinCabin(item.id);
        //                if (seat === 0) {
        //                    $(`.active-Cabin-${item.id} .et-car-icon`).addClass("et-car-icon-sold-out");
        //                }

        //            })
        //            CabinList.map(item => {


        //                if (stt == 0) {
        //                    stt = item.id;
        //                    console.log(stt);
        //                }
        //                $(`.active-Cabin-${item.id}`).on('click', function () {
        //                    if (activeCabin != 0) {
        //                        $(`.active-Cabin-${activeCabin} .et-car-icon`).removeClass("et-car-icon-selected");
        //                    }
        //                    $(`.active-Cabin-${item.id} .et-car-icon`).addClass("et-car-icon-selected");
        //                    activeCabin = item.id;
        //                    $('.tile-cabin').html(`
        //                           <h6>Toa số ${item.index}: ${item.cabinCategoryName}</h6>
        //                            </div>
        //                            <div class="et-col-5">
        //                    <div class="et-car-previous-floor text-center">&lt;</div>
        //                        </div>
        //                    <div class="et-col-90">
        //                        <div class="et-car-floor">`)
        //                    ShowSeatInCabin(item.id, item.cabinCategoryCode);
        //                })
        //            })
        //            if (stt != 0) {
        //                $(`.active-Cabin-${stt}`).trigger('click');
        //            }


        //            trainClick = e.id;
        //        })
        //        if ($(`.active-train-${e.id}`).data("stt") == 1) {
        //            $(`.active-train-${e.id}`).trigger('click');
        //        }
        //    })
        //})
    }
    if (option == 1) {
        ShowTwoWay(SEnd, sBegin, date, 1);
    }
})
function ShowSeatInCabin(cabinId, cabinCode,option) {
    $.get(`api/Seats/GetByTrain?cabinId=${cabinId}`)
        .done(res => {
            let length = [...res].length;
            console.log(length);
            if (cabinCode === "NGOI") {
                let newArray = Array2dSeat([...res], 4);
                console.log(newArray);
                let htmlShowSeat = "";
                let htmlShowSeatLeft = ` <div class="et-car-door"></div>
                            <div class="et-car-nm-64-half-block">
                                <div class="et-full-width">`;
                let htmlShowSeatRight = `<div class="et-car-nm-64-half-block">
                               <div class="et-full-width" style="margin-left: 8px;">`;

                for (let d = 0; d < 4; d++) {
                    for (let c = 0; c < (length / 4).toFixed(); c++) {
                        if (newArray[d][c].index <= length / 2) {
                            if (newArray[d][c].status === false) {

                                htmlShowSeatLeft += `<div class="et-car-nm-64-sit">
                                        <div class="et-car-seat-left et-seat-h-35">
                                            <div class="et-col-16 et-sit-side"></div>
                                            <div class="et-col-84 et-sit-sur-outer">
                                                <div class="et-sit-sur text-center et-sit-avaiable">
                                                    <div data-container="body" data-toggle="popover" data-placement="top" title="Giá bán" data-content="${Number(newArray[d][c].price).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')} VND" data-trigger="hover">
                                                        <span>${newArray[d][c].index}</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>`
                            }
                            else {
                                htmlShowSeatLeft += `   <div class="et-car-nm-64-sit">
                                        <div class="et-car-seat-left et-seat-h-35">
                                            <div class="et-col-16 et-sit-side"></div>
                                            <div class="et-col-84 et-sit-sur-outer">
                                                <div class="et-sit-sur text-center et-sit-bought">
                                                    <div data-container="body" data-toggle="popover" data-placement="top" data-content="chỗ đã bán" data-trigger="hover">
                                                        <span>${newArray[d][c].index}</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>`
                            }

                        }
                        else {

                            if (newArray[d][c].status === false) {

                                htmlShowSeatRight += `<div class="et-car-nm-64-sit">
                                        <div class="et-car-seat-right et-seat-h-35">

                                            <div class="et-col-84 et-sit-sur-outer-invert">
                                                <div class="et-sit-sur-invert text-center et-sit-avaiable">
                                                    <div data-container="body" data-toggle="popover" data-placement="top" title="Giá bán" data-content="${Number(newArray[d][c].price).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')} VND" data-trigger="hover">
                                                        <span>${newArray[d][c].index}</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="et-col-16 et-sit-side"></div>
                                        </div>
                                    </div>`
                            }
                            else {
                                htmlShowSeatRight += ` <div class="et-car-nm-64-sit">
                                        <div class="et-car-seat-right et-seat-h-35">

                                            <div class="et-col-84 et-sit-sur-outer-invert">
                                                <div class="et-sit-sur-invert text-center  et-sit-bought">
                                                    <div data-container="body" data-toggle="popover" data-placement="top" data-content="chỗ đã bán" data-trigger="hover">
                                                        <span>${newArray[d][c].index}</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="et-col-16 et-sit-side"></div>
                                        </div>
                                    </div>`
                            }
                        }
                    }
                }

                htmlShowSeatLeft += ` </div>
                                </div>`;
                htmlShowSeatRight += ` </div>
                                 </div>
                            <div class="et-car-door"></div>`;
                htmlShowSeat = htmlShowSeatLeft +
                    `<div class="et-car-seperator">

                   <div></div>

                  <div></div>
              </div>`
                    + htmlShowSeatRight + 
                    `   
                    </div>
                    </div>
                    `;
                if (option == 1) {
                    htmlShowSeat += `</div>`
                }
                console.log(htmlShowSeat);
                $(".et-car-floor").html("")
                $(".et-car-floor").html(htmlShowSeat);
                if ($(".row.et-car-floor-region .et-col-5.close-door").length == 0) {
                    $(".row.et-car-floor-region").append(`<div class="et-col-5 close-door">
                        <div class="et-car-next-floor text-center">&gt;</div>
                    </div>
                </div>
            </div>`)
                }
                
            }
            else {
               
                let Seat2 = [...res];
                console.log(Seat2);
                let htmltitlefoor = ""
                let htmlseat = "";
                let htmlCabin = "";
                let b = [];
                for (let i = 3; i >=1 ; i--) {
                    if (Seat2.filter(e => e.floorCode == "T" + i).length > 0) {
                        let List = Seat2.filter(e => e.floorCode == "T" + i)
                        console.log(`${i}`, List)
                        b.push(List.length);
                        htmltitlefoor += `<div class="et-bed-way et-full-width text-center small">Tầng ${i}</div>`
                        
                        //let length = (List.length / 2).toFixed();
                        List.forEach(item => {
                            if (item.index % 2 === 0) {
                                if (item.status === false) {
                                    console.log(item.index);
                                    htmlseat += `<div class="et-col-1-16 et-seat-h-35 ">
                                    <div class="et-bed-right">
                                        <div class="et-bed-outer">
                                            <div class="et-bed text-center et-sit-avaiable">
                                                <div data-container="body" data-toggle="popover" data-placement="top" title="Giá bán" data-content="${Number(item.price).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')} VND" data-trigger="hover">
                                                    <span>${item.index}</span>
                                                </div>
                                            </div>
                                            <div class="et-bed-illu"></div>
                                        </div>
                                    </div>
                                </div>`

                                }
                                else {
                                    console.log(item.index);
                                    htmlseat += `<div class="et-col-1-16 et-seat-h-35 ">
                                    <div class="et-bed-right">
                                        <div class="et-bed-outer">
                                            <div class="et-bed text-center et-sit-bought">
                                                <div data-container="body" data-toggle="popover" data-placement="top" data-content="chỗ đã bán" data-trigger="hover">
                                                    <span>${item.index}</span>
                                                </div>
                                            </div>
                                            <div class="et-bed-illu"></div>
                                        </div>
                                    </div>
                                </div>`
                                }

                            }
                            else {
                                if (item.status === false) {
                                    console.log(item.index);
                                    htmlseat += `<div class="et-col-1-16 et-seat-h-35 ">
                                    <div class="et-bed-left">
                                        <div class="et-bed-outer">
                                            <div class="et-bed text-center et-sit-avaiable">
                                                <div data-container="body" data-toggle="popover" title="Giá bán" data-placement="top" data-content="${Number(item.price).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')} VND" data-trigger="hover">
                                                    <span>${item.index}</span>
                                                </div>
                                            </div>
                                            <div class="et-bed-illu"></div>
                                        </div>
                                    </div>
                                </div>`

                                }
                                else {
                                    console.log(item.index);
                                    htmlseat += `<div class="et-col-1-16 et-seat-h-35 ">
                                    <div class="et-bed-left">
                                        <div class="et-bed-outer">
                                            <div class="et-bed text-center et-sit-bought">
                                                <div data-container="body" data-toggle="popover" data-placement="top" data-content="chỗ đã bán" data-trigger="hover">
                                                    <span>${item.index}</span>
                                                </div>
                                            </div>
                                            <div class="et-bed-illu"></div>
                                        </div>
                                    </div>
                                </div>`
                                }
                            }
                        })
                        let loop = 7 -(List.length / 2).toFixed();
                        for(let j = 0; j <= loop; j++)
                            {
                            htmlseat += `<div class="et-col-1-16 et-seat-h-35 " style=" visibility: hidden">
                                    <div class="et-bed-left">
                                        <div class="et-bed-outer">
                                            <div class="et-bed text-center et-sit-bought">
                                                <div data-container="body" data-toggle="popover" data-placement="top" data-content="chỗ đã bán" data-trigger="hover">
                                                    <span></span>
                                                </div>
                                            </div>
                                            <div class="et-bed-illu"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="et-col-1-16 et-seat-h-35 " style="visibility: hidden">
                                    <div class="et-bed-right">
                                        <div class="et-bed-outer">
                                            <div class="et-bed text-center et-sit-bought">
                                                <div data-container="body" data-toggle="popover" data-placement="top" data-content="chỗ đã bán" data-trigger="hover">
                                                    <span></span>
                                                </div>
                                            </div>
                                            <div class="et-bed-illu"></div>
                                        </div>
                                    </div>
                                </div>`
                            }
                       
                    }
                    else {
                        htmltitlefoor += `<div class="et-bed-way et-full-width"></div>`
                        htmlCabin +=`<div class="et-bed-way et-full-width"></div>`
                    }
                }
                let maxCabin = (Math.max(...b) / 2).toFixed();
                console.log('cabin', maxCabin)
                if (maxCabin > 0 && maxCabin <= 7) {
                    htmlCabin +=` <div class="et-bed-way et-full-width et-text-sm">`
                    for (let i = 1; i <= 7; i++) {
                        htmlCabin +=`<div class="et-col-1-8 text-center">Khoang ${i}</div>`
                    }
                    htmlCabin += ` </div>`;
                }
                let htmltotal = `<div class="et-col-1-18 et-car-floor-full-height">
                                  <div class="et-bed-way et-full-width"></div>`
                    + htmltitlefoor +
                    `</div>`+
                    `<div class="et-col-8-9">`
                    + htmlCabin + htmlseat
                     +`  </div>
                    </div>`;
                if (option == 1) {
                    htmltotal += `</div>`
                }
                console.log(htmltotal);
                $(".et-car-floor").html(htmltotal);
                if ($(".row.et-car-floor-region .et-col-5.close-door").length == 0) {
                    $(".row.et-car-floor-region").append(`<div class="et-col-5 close-door">
                        <div class="et-car-next-floor text-center">&gt;</div>
                    </div>
                </div>
            </div>`)
                }
               
               
            }
            $('[data-toggle="popover"]').popover();
            console.log($('[data-toggle="popover"]'));
        })
}
async function CountSeatinCabin(id) {
    let count = 0;
    let data = [...await $.get(`api/Seats/GetByTrain?cabinId=${id}`)];
    data.forEach(item => {
        if (item.status == false) {
            count++;
        }
    })
    console.log('count', count);
    return count;
}
function Array2dSeat(arrayBegin, size) {
    let length = arrayBegin.length;
    console.log(arrayBegin);
    var arr = Array.from(Array(size), () => new Array((length / size).toFixed()));
   
        for (let c = 0; c < (length / size).toFixed(); c++)
        {
            for (let d = 0; d < size; d++) {
                if (c % 2 == 0) {
                  
                    arr[d][c] = arrayBegin[d + c * size];
                }
                else {
                    arr[d][c] = arrayBegin[(c + 1) * 4 - d - 1];
                }
                
            }
        }
  
    return arr;
}
function ShowTwoWay(sBegin, SEnd, day, option) {
    $.get('api/Schedules/GetTrain?StationBegin=' + sBegin + '&StationEnd=' + SEnd + '&date=' + `${moment(day).format("YYYY/MM/DD")}`).done(res => {
        let data = [];
        let htmlTrain = "";
        data = res;
        let stt = 1;
        let trainClick = 0;
        console.log(data);
        console.log(res);
        $.each(data, function (i, e) {

            htmlTrain += `<div class="col-xs-4 col-sm-3 et-col-md-2 et-train-block active-train-${e.id}"  data-stt=${stt}>
                        <div class="et-train-head">
                            <div style="width: 40%; margin-bottom: 3px" class="center-block">
                                <div style="color: rgb(85, 85, 85);" class="et-train-lamp text-center ng-binding">
                                    ${e.trainsList[0].name}
                                </div>
                            </div>
                            <div class="et-train-head-info">
                                <div class="et-no-margin">
                                    <span class="float-left et-bold">
                                        TG đi
                                    </span>
                                    <span class="float-right">
                                        ${moment(new Date(e.dateBegin)).format("DD/MM HH:SS")}
                                    </span>
                                </div>
                                <div class="et-no-margin">
                                    <span class="float-left et-bold">
                                        TG đên
                                    </span>
                                    <span class="float-right ">
                                        ${moment(new Date(e.dateEnd)).format("DD/MM HH:SS")}
                                    </span>
                                </div>
                                <div class="et-no-margin">
                                    <div class="et-col-50">
                                        <div class="et-text-sm">
                                            SL chỗ Đặt
                                        </div>
                                        <div style="margin-left: 5px;" class="et-text-large et-bold float-left">
                                            0
                                        </div>

                                    </div>
                                    <div class="et-col-50 text-center">
                                        <div class="et-text-sm">
                                            SL chỗ trống
                                        </div>
                                        <div style="margin-right: 5px;" class="et-text-large et-bold float-right">
                                            260
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="et-no-margin">
                                <div class="et-col-50">
                                    <span class="et-train-lamp-bellow-left"></span>
                                </div>
                                <div class="et-col-50">
                                    <span class="et-train-lamp-bellow-right"></span>
                                </div>
                            </div>
                        </div>
                        <div class="et-train-base"></div>
                        <div class="et-train-base-2"></div>
                        <div class="et-train-base-3"></div>
                        <div class="et-train-base-4"></div>
                        <div class="et-train-base-5"></div>
                    </div>`
            stt++;
        })
        //$('.train-group').html(htmlTrain);
        let htmltile1 = option == 0 ? `<div class="row et-page-header" style="margin-bottom: 40px;">
                <span class="et-main-label">
                   Chiều đi: ngày ${moment(day).format("DD/MM/YYYY")} từ Hà Nội đến Sài Gòn
                </span>
            </div>`: `<div class="row et-page-header" style="margin-bottom: 40px;">
                <span class="et-main-label">
                  Chiều về: ngày ${moment(day).format("DD/MM/YYYY")}từ Hà Nội đến Sài Gòn
                </span>
            </div>`;
        let htmlhead = htmltile1 + `
             <div class="row et-train-list">
                <div class="train-group">`
            + htmlTrain +
            `</div>
            </div>
            <div class="row bigContainer"  style="margin-left: -10px;">
                <div class="col-md-12 et-no-margin ListCabin">`
        console.log(htmlhead);
        if (option == 1) {
            $(".showtrain").append(`<div class="TwoWay">` + htmlhead);
        }
        else {
            $(".showtrain").html(htmlhead);
        }
        if (option == 0) {
            $.each(data, function (i, e) {

                $(`.active-train-${e.id}`).on('click', function () {
                    if (trainClick != 0) {
                        $(`.active-train-${trainClick} .et-train-head`).removeClass("et-train-head-selected");
                    }
                    $(`.active-train-${e.id} .et-train-head`).addClass("et-train-head-selected");
                    let CabinList = [...e.trainsList[0].cabin];
                    let CabinList2 = [...e.trainsList[0].cabin];
                    let htmlCabin = "";
                    let stt = 0;
                    let activeCabin = 0;

                    if (option == 0) {
                        CabinList.reverse().map((item) => {
                            htmlCabin += `<div class="et-car-block  active-Cabin-${item.id}">
                    <div class="et-car-icon et-car-icon-avaiable">
                        <img style="width:48px ; height:23px" src='/Images/trainCar2.png' />
                    </div>
                    <div class="text-center text-info et-car-label">${item.index}</div>
                </div>`


                        })
                        htmlCabin += `<div class="et-car-block">
                    <div class="et-car-icon">
                        <img style="width:48px ; height:23px" src='/Images/train2.png' />
                    </div>
                    <div class="text-center text-info et-car-label">${e.trainCode}</div>
                </div>`
                    }

                    
                    $('.ListCabin').html(htmlCabin);
                    if ($(".bigContainer .row.et-car-floor-region").length == 0) {
                        let html = `</div>
                           <div class="row et-car-floor-region" style="width: 100%;">
                    <div class=" col-xs-12 col-sm-12 col-md-12 text-center tile-cabin">`
                        $(".bigContainer").append(html);
                    }
                    
                    CabinList2.map(async item => {

                        let seat = await CountSeatinCabin(item.id);
                        if (seat === 0) {
                            $(`.active-Cabin-${item.id} .et-car-icon`).addClass("et-car-icon-sold-out");
                        }

                    })
                    CabinList2.map(item => {


                        if (stt == 0) {
                            stt = item.id;
                            console.log(stt);
                        }
                        $(`.active-Cabin-${item.id}`).on('click', function () {
                            if (activeCabin != 0) {
                                $(`.active-Cabin-${activeCabin} .et-car-icon`).removeClass("et-car-icon-selected");
                            }
                            $(`.active-Cabin-${item.id} .et-car-icon`).addClass("et-car-icon-selected");
                            activeCabin = item.id;
                            $('.tile-cabin').html(`
                                   <h6>Toa số ${item.index}: ${item.cabinCategoryName}</h6>
                                    </div>`)
                            if ($(".row.et-car-floor-region .et-col-5.oneway").length == 0 && !$(".row.et-car-floor-region .et-car-floor ") == 0) {
                                console.log("1");
                                $(".row.et-car-floor-region").append(`<div class="et-col-5 oneway">
                            <div class="et-car-previous-floor text-center">&lt;</div>
                                </div>
                            <div class="et-col-90">
                                <div class="et-car-floor">`)
                            }
                          
                            ShowSeatInCabin(item.id, item.cabinCategoryCode, option);
                        })
                    })
                    if (stt != 0) {
                        $(`.active-Cabin-${stt}`).trigger('click');
                    }


                    trainClick = e.id;
                })
                if ($(`.active-train-${e.id}`).data("stt") == 1) {
                    $(`.active-train-${e.id}`).trigger('click');
                }
            })
        }
        else {
            $.each(data, function (i, e) {

                $(`.TwoWay .active-train-${e.id}`).on('click', function () {
                    if (trainClick != 0) {
                        $(`.active-train-${trainClick} .et-train-head`).removeClass("et-train-head-selected");
                    }
                    $(`.TwoWay .active-train-${e.id} .et-train-head`).addClass("et-train-head-selected");
                    let CabinList = [...e.trainsList[0].cabin];
                    let CabinList2 = [...e.trainsList[0].cabin];
                    let htmlCabin = "";
                    let stt = 0;
                    let activeCabin = 0;

                        htmlCabin += `<div class="et-car-block">
                    <div class="et-car-icon">
                        <img style="width:48px ; height:23px" src='/Images/train2.png' />
                    </div>
                    <div class="text-center text-info et-car-label">${e.trainCode}</div>
                </div>`
                        CabinList.map((item) => {
                            htmlCabin += `<div class="et-car-block  active-Cabin-${item.id}">
                    <div class="et-car-icon et-car-icon-avaiable">
                        <img style="width:48px ; height:23px" src='/Images/trainCar2.png' />
                    </div>
                    <div class="text-center text-info et-car-label">${item.index}</div>
                </div>`


                        })

                    

                    htmlCabin += `</div>
                           <div class="row et-car-floor-region" style="width: 100%;">
                    <div class=" col-xs-12 col-sm-12 col-md-12 text-center tile-cabin">`
                    $('.TwoWay .ListCabin').html(htmlCabin);
                    CabinList2.map(async item => {

                        let seat = await CountSeatinCabin(item.id);
                        if (seat === 0) {
                            $(`.TwoWay .active-Cabin-${item.id} .et-car-icon`).addClass("et-car-icon-sold-out");
                        }

                    })
                    CabinList2.map(item => {


                        if (stt == 0) {
                            stt = item.id;
                            console.log(stt);
                        }
                        $(`.TwoWay .active-Cabin-${item.id}`).on('click', function () {
                            if (activeCabin != 0) {
                                $(`.TwoWay .active-Cabin-${activeCabin} .et-car-icon`).removeClass("et-car-icon-selected");
                            }
                            $(`.TwoWay .active-Cabin-${item.id} .et-car-icon`).addClass("et-car-icon-selected");
                            activeCabin = item.id;
                            $('.TwoWay .tile-cabin').html(`
                                   <h6>Toa số ${item.index}: ${item.cabinCategoryName}</h6>
                                    </div>`);
                            $(".TwoWay .row.et-car-floor-region").append(`<div class="et-col-5">
                            <div class="et-car-previous-floor text-center">&lt;</div>
                                </div>
                            <div class="et-col-90">
                                <div class="et-car-floor">`)     
                            ShowSeatInCabin(item.id, item.cabinCategoryCode,option);
                        })
                    })
                    if (stt != 0) {
                        $(`.TwoWay .active-Cabin-${stt}`).trigger('click');
                    }


                    trainClick = e.id;
                })
                if ($(`.TwoWay .active-train-${e.id}`).data("stt") == 1) {
                    $(`.TwoWay .active-train-${e.id}`).trigger('click');
                }
            })
        }
    })

}

