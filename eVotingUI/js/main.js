let _baseUrl = "https://localhost:44314/api";

$(document).ready(function () {
    let userId = window.localStorage.getItem("userId");
    if(userId != null){
        $.ajax({
            url: _baseUrl+'/account/userVoted?userId='+userId, 
            type: 'GET',
            contentType: "application/json",
            dataType: "json",
            cache: false,
            async: false,
            success: function (result) {
                if(result.data.userVoted){
                    $(".voteMenu").addClass("d-none");
                }else {
                    $(".voteMenu").removeClass("d-none");

                }
            }
        });
    }

});