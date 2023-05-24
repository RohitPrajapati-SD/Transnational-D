

var GetLogin = function () {
    
    var textFiled = $('#txtUsername').val();
    var password = $('#txtPassword').val();
    var loginurl = "/api/login/GetLogin";
    alert(password);
    var loginData = JSON.stringify({ "Email": textFiled, "Password": password });
   
    $.ajax({
        type: "POST",
        data: loginData,
        url: loginurl,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
          
            alert(result.Message)
        },
        error: function (result) {
          
            alert(result.Message)
        }
    });
};