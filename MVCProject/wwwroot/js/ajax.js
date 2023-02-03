var token = $("input[name='__RequestVerificationToken']").val();
function PostMethodAjax(url, data, callbackfunction, errorfunction) {
    $.ajax({
        type: "POST",
        headers:
        {
            "RequestVerificationToken": token
        },
        dataType: "json",
        url: url,
        data: data,
        success: function (response) {
            callbackfunction(response)
        },
        failure: function (response) {
            errorfunction(response)
            console.log("ERROR:" + response.responseText);
        },
        error: function (response) {
            errorfunction(response)
            console.log("ERROR:" + response.responseText);
        }
    });
}

function GetMethodAjax(url, data, callbackfunction, errorfunction) {
    $.ajax({
        type: "GET",
        headers:
        {
            "RequestVerificationToken": token
        },
        dataType: "json",
        url: url,
        data: data,
        success: function (response) {
            callbackfunction(response)
        },
        failure: function (response) {
            errorfunction(response)
            console.log("ERROR:" + response.responseText);
        },
        error: function (response) {
            errorfunction(response)
            console.log("ERROR:" + response.responseText);
        }
    });
}