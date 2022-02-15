jQuery.validator.addMethod("equals", function (value, element, param) {
    return this.optional(element) || $.inArray(value, param) >=0;
});
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
    var stationa = $("#StartingStation");
    var stationb = $("#stops");
    var productNames = new Array();
    var productIds = new Object();
    $.get('/api/Stations').done(
        res => {
            let a= res
           $.each(a, function (index, product) {
                    productNames.push(product.name);
                    productIds[product.name] = product.id;
                });
            stationa.typeahead({ source: productNames, autoSelect: true, });
            stationb.typeahead({ source: productNames, autoSelect: true, });
            });
        
        
    //stationa.typeahead({
    //    source: function (query, process) {
    //        $.ajax({
    //            url: 'api/Stations',
    //            type: 'GET',
    //            dataType: 'JSON',
    //            async: true,
    //            success: function (data) {
    //                process(data);
    //            }
    //        });
    //    }
    //    },
    //    autoSelect: true,
    //});
    stationa.change(function () {
        var current = stationa.typeahead("getActive");
        matches = [];

        if (current) {

           
            if (current.name == stationa.val()) {
                matches.push(current.name);
                
            }
        }
    });
    stationb.change(function () {
        var current = stationa.typeahead("getActive");
        matches = [];

        if (current) {


            if (current.name == stationb.val()) {
                matches.push(current.name);
            }
        }
    });
    allchange();
    var radios = $('input:radio[name=oneWay]');
    if (localStorage.getItem('Date') != null) {
        $('#datetimepicker1').find("input").val(localStorage.getItem('Date'));
    }
    if (localStorage.getItem('Option') != null) {
        radios.filter(`[value=${localStorage.getItem('Option')}]`).prop('checked', true)
    }
    else {
       
        radios.filter('[value=0]').prop('checked', true);
        if ($(`input[name="dateA"]`).val()) {
            $(`input[name="dateB"]`).val($(`input[name="dateA"]`).val());
        }
        localStorage.setItem('Option', 0);
    }
    $('input:radio[name=oneWay]').change(
        function () {
            if ($(this).is(':checked') && $(this).val() == 0) {
                // append goes here
                if ($(`input[name="dateA"]`).val()) {
                    $(`input[name="dateB"]`).val($(`input[name="dateA"]`).val());
                }
                localStorage.setItem('Option', 0);
            }
            if ($(this).is(':checked') && $(this).val() == 1) {
                // append goes here
                localStorage.setItem('Option', 1);
            }
        });
    $('#btn-search-main').on('click', function () {
        
        
        if (check(productNames)) {
            let date = $('#datetimepicker1').find("input").val();
            let datenew = moment(date, 'DD/MM/yyyy').toDate();
            let date2 = $('#datetimepicker').find("input").val();
            let stationa = $('#StartingStation').val();
            let stationb = $('#stops').val();
            $.ajax({
                url: `/api/Schedules/GetTrain?StationBegin=${getid(productIds, stationa)}&StationEnd=${getid(productIds, stationb)}&date=${moment(datenew).format("YYYY/MM/DD")}`,
                method: "GET",
                success: (res) => {
                    let arr = [...res]
                    if (arr.length==0) {
                        alert("Không có chuyến tàu của bạn hoạt động");
                    }
                    else {
                        console.log(getid(productIds, stationa));
                        window.history.pushState("string", "", "/KetQuaTimKiem");

                        localStorage.setItem('StationBegin', getid(productIds, stationa))
                        localStorage.setItem('StationEnd', getid(productIds, stationb))
                        localStorage.setItem('Date', date);
                        if (localStorage.getItem('Option') == 1) {
                            localStorage.setItem('DateEnd', date);
                        }
                        $("#main").load("/Home/Main");
                    }
                },
                error: (e) => {
                    console.log(e);
                }

            })
        }
            })
            
        
       
            
       
    
   
})
function getid(ArrId, Name) {
    return ArrId[Name];
}
function check(productNames) {
    console.log(productNames);
    $("#formSearch").validate({
        rules: {
          
            nameA: {
                required: true,
                equals: productNames
            },
            nameB: {
                required: true,
                equals: productNames
            },
            dateA: {
                required: true,
              
            },
            dateB: {
                required: true,
               
                
            }

        },
        messages: {
            nameA: "Ga đi không hợp lệ",
              
           
            nameB: "Ga đi không hợp lệ",

            dateA: {
                required: "Ngày đi không hợp lệ",
               
            },
            dateB: {
                required: "Ngày về không hợp lệ",
              
              
            },

         
        },
        errorPlacement: function (error, element) {
            if (element.attr("name") == "nameA") {
                error.appendTo("#errornameA");
            }
            if (element.attr("name") == "nameB") {
                error.appendTo("#errornameB");
            }
            if (element.attr("name") == 'dateA') {

                error.appendTo("#errordateA");
            }
            if (element.attr("name") == 'dateB') {
                error.appendTo("#errordateB");
            }
           
             }
    })
    let t = $("#formSearch").valid();
    console.log($('#errornameA').length > 0);
    if ($('#errornameA .error').length > 0) {
        $(`input[name="nameA"]`).addClass("errorvalidate")
    }
    else {
        $(`input[name="nameB"]`).removeClass("errorvalidate")
    }
    if ($('#errornameB .error').length > 0) {
        $(`input[name="nameB"]`).addClass("errorvalidate")
    }
    else {
        $(`input[name="nameB"]`).removeClass("errorvalidate")
    }
    if ($('#errordateB .error').length > 0) {
        $(`input[name="dateB"]`).addClass("errorvalidate")
    }
    else {
        $(`input[name="dateB"]`).removeClass("errorvalidate")
    }
    if ($('#errordateA .error').length > 0) {
        $(`input[name="dateA"]`).addClass("errorvalidate")
    }
    else {
        $(`input[name="dateA"]`).removeClass("errorvalidate")
    }
    return t;
}
function allchange() {
    $(`input[name="nameA"]`).on('change', function () {
        console.log('12315456');
        if ($(`input[name="nameA"]`).hasClass("valid")) {
            $(`input[name="nameA"]`).removeClass("errorvalidate");
           

        }
        else {
            if ($('#errornameA .error').length > 0) {

                $(`input[name="nameA"]`).addClass("errorvalidate");
            }
        }

    })
    $(`input[name="nameB"]`).on('change', function () {

        if ($(`input[name="nameB"]`).hasClass("valid")) {
            $(`input[name="nameB"]`).removeClass("errorvalidate");


        }
        else {
            if ($('#errornameB .error').length > 0) {

                $(`input[name="nameB"]`).addClass("errorvalidate");
            }
        }
    })
    $(`input[name="dateA"]`).on('change', function () {
        console.log('change');
        if ($('#errordateA .error').css("display") == 'none') {
            $(`input[name="dateA"]`).removeClass("errorvalidate")
        }
        else {
           
            $(`input[name="dateA"]`).addClass("errorvalidate")
        }

    })
    $(`input[name="dateB"]`).on('change', function () {
        console.log('change');
        if ($('#errordateB .error').css("display") == 'none') {
            $(`input[name="dateB"]`).removeClass("errorvalidate")
        }
        else {

            $(`input[name="dateB"]`).addClass("errorvalidate")
        }

    })
    $('#datetimepicker').on('dp.change', function () {

        
            $(`input[name="dateB"]`).removeClass("errorvalidate")
       
 
    })
    $('#datetimepicker1').on('dp.change', function () {


        $(`input[name="dateA"]`).removeClass("errorvalidate")
        if ($(`input[name="dateA"]`).val()) {
            $(`input[name="dateB"]`).val($(`input[name="dateA"]`).val());
        }

    })
   
}