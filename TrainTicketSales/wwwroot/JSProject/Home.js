$(document).ready(function () {
    var radios = $('input:radio[name=oneWay]');
    window.onhashchange = function () {
        //if (window.location.pathname = "/") {
        //    $("#main").load("/Home")
        //}
        console.log(window.location.pathname);
    }
    if (localStorage.getItem('Date') != null) {
        $('#datetimepicker1').find("input").val(localStorage.getItem('Date'));
    }
    if (localStorage.getItem('Option') != null) {
        radios.filter(`[value=${localStorage.getItem('Option')}]`).prop('checked', true)
    }
    else {
       
        radios.filter('[value=0]').prop('checked', true);
    }
    $('input:radio[name=oneWay]').change(
        function () {
            if ($(this).is(':checked') && $(this).val() == 0) {
                // append goes here
                localStorage.setItem('Option', 0);
            }
            if ($(this).is(':checked') && $(this).val() == 1) {
                // append goes here
                localStorage.setItem('Option', 1);
            }
        });
    $('#btn-search-main').on('click', function () {
        let date = $('#datetimepicker1').find("input").val();
        if (date != "") {
            window.history.pushState("string", "", "/KetQuaTimKiem");
            $("#main").load("/Home/Main");
            localStorage.setItem('StationBegin', 173)
            localStorage.setItem('StationEnd', 1)
            localStorage.setItem('Date', date);
        }
    })
   
})