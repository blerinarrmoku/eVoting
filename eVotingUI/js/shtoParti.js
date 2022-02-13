let _baseUrl = "https://localhost:44314/api";

$(document).ready(function () {
    let emailSignedIn = window.localStorage.getItem("email");
    $("#emailSpace").html(emailSignedIn);

    $("#shtoPartiForm").submit(function( event ) {
        event.preventDefault();
        var _name = $("#emriPartis").val();
        var _imageUrl = $("#fotoPartis").val();
        var _shkurtesa = $("#shkurtesaPartis").val();

        if(_name == "" || _shkurtesa == "" || _imageUrl == ""){
            alert("Fill all the boxes");
            return;
        }
        var _model = 
        {
            name: _name,
            abbreviation: _shkurtesa,
            imageUrl: _imageUrl,
            cityId: 1
        };
        $.ajax({
            url: _baseUrl+'/parties/createParty', 
            type: 'POST',
            contentType: "application/json",
            dataType: "json", 
            data: JSON.stringify(_model),
            cache: false,
            success: function (result) {
                alert(result.message);
                window.location.href = "/partite.html";
            }
        });
    });
});