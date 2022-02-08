let _baseUrl = "https://localhost:44314/api";

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
            url: _baseUrl+'/account/signin', 
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

    $("#signUpForm").submit(function( event ) {
        event.preventDefault();
        var _email = $("#emailSignUp").val();
        var _password = $("#passwordSignUp").val();
        var _confirmPassword = $("#confirmPasswordSignUp").val();
        if(_email == "" || _password == "" || _confirmPassword == ""){
            alert("Fill all the boxes");
            return;
        }
        var _model = 
        {
            email: _email,
            password: _password,
            confirmPassword: _confirmPassword
        };
        $.ajax({
            url: _baseUrl+'/account/register', 
            type: 'POST',
            contentType: "application/json",
            dataType: "json", 
            data: JSON.stringify(_model),
            cache: false,
            success: function (result) {
               alert(result.message);
            }
        });
    });

});