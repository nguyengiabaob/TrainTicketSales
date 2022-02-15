function Login() {
    let data = {
        Username: $("#Username").val(),
        Password: $("#Password").val()
    };
    console.log(data);
    let url = '/Admin/Home/Login1?Username=' + $("#Username").val() + '&Password=' + $("#Password").val()
    res = false;
    $.ajax({
        type: "GET",
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: JSON.stringify(data),

        success: function(response) {
            console.log(response)
            if (response.status) {
                window.open(response.result, "_self")
            }


        },
        
    }
    );
    return res;
}