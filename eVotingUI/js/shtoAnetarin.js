let _baseUrl = "https://localhost:44314/api";

$(document).ready(function () {

    $("#datePicker").flatpickr({
        dateFormat: "Y-m-d",
    });

    $("#shtoAnetarinForm").submit(function( event ) {
        event.preventDefault();
        var _name = $("#memberName").val();
        var _partyId = $("#memberParty").val();
        var _imageUrl = $("#memberFoto").val();
        var _birthDate = $("#datePicker").val();
        var _birthPlace = $("#memberBirthPlace").val();
        var _isCandidate = false;
        if ($('#isCandidate').is(":checked"))
        {
            _isCandidate = true;
        }

        if(_name == "" || _partyId == "" || _imageUrl == "" || _birthDate == "" || _birthPlace == ""){
            alert("Fill all the boxes");
            return;
        }
        var _model = 
        {
            name: _name,
            partyId: _partyId,
            imageUrl: _imageUrl,
            birthDate: _birthDate,
            birthPlace: _birthPlace,
            isCandidate: _isCandidate
        };
        $.ajax({
            url: _baseUrl+'/members/createMember', 
            type: 'POST',
            contentType: "application/json",
            dataType: "json", 
            data: JSON.stringify(_model),
            cache: false,
            success: function (result) {
                alert(result.message);
                window.location.href = "/Dashboard.html";
            }
        });
    });
});