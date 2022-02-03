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
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44314/WeatherForecast',
        data: null,
        cache: false,
        success: function (result) {
            console.log(result);
        }
    });
});