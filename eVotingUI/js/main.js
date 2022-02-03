const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

signUpButton.addEventListener('click', () => {
	container.classList.add("right-panel-active");
});

signInButton.addEventListener('click', () => {
	container.classList.remove("right-panel-active");
});

$(document).ready(function () {
    // $.ajax({
    //     type: 'GET',
    //     url: 'https://localhost:44314/WeatherForecast',
    //     data: null,
    //     cache: false,
    //     success: function (result) {
    //         console.log(result);
    //     }
    // });

    $("#signInForm").submit(function( event ) {
        event.preventDefault();
        var _email = $("#emailSignIn").val();
        var _password = $("#passwordSignIn").val();
        if(_email == "" || _password == ""){
            alert("Fill all the boxes");
            return;
        }
        var _model = 
        {
            email: _email,
            password: _password
        };
        $.ajax({
            url: 'https://localhost:44314/api/account/signin', 
            type: 'POST',
            contentType: "application/json",
            dataType: "json", 
            data: JSON.stringify(_model),
            cache: false,
            success: function (result) {
                if(result){
                    alert("Successfully Signed In");
                } else {
                    alert("Email or Password incorrect");
                }
                $("#passwordSignIn").val("");
            }
        });
      });
});