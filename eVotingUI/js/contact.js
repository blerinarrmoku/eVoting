let _baseUrl = "https://localhost:44314/api";

$(document).ready(function () {
    $("#contact_form").submit(function(event) {
        event.preventDefault();
        var _name = $("#name").val();
        var _email = $("#email").val();
        var _message = $("#message").val();

        var _model = {
            "name": _name,
            "email": _email,
            "message": _message
        }
        $.ajax({
            url: _baseUrl+'/contact/createContact', 
            type: 'POST',
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(_model),
            cache: false,
            async: false,
            success: function (result) {
                alert(result.message);
                window.location.reload();
            }
        });
    });
});