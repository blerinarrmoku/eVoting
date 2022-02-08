let _baseUrl = "https://localhost:44314/api";

$(document).ready(function () {

    $(".candidateBox").on("click",function(){
        $(".candidateBox").removeClass("selectedCandidate");
        $(this).addClass("selectedCandidate");
    });

    $(".candidateParty").on("click",function(){
        $(".candidateParty").removeClass("selectedParty");
        $(this).addClass("selectedParty");
    });

    $(".checkboxCandidate").change(function() {
        if(this.checked) {
            var check = $('#candidateCheckboxes').find('input[type=checkbox]:checked').length;
            if(check == 6){
                $(this).prop("checked",false);
            }
        }
    });

    $("#btnVote").on("click",function(){
        var _candidateId = $(".selectedCandidate").attr("value");
        var _partyId = $(".selectedParty").attr("value");
        var checked = $('#candidateCheckboxes').find('input[type=checkbox]:checked');
        var array = [];
        for(var i = 0;i < checked.length;i++){
            array.push(checked[i].value);
        }
        var _data = {
            candidateId: _candidateId,
            partyId: _partyId,
            checkedCandidates: array
        }
        $.ajax({
            url: _baseUrl+'/votes/vote', 
            type: 'POST',
            contentType: "application/json",
            dataType: "json", 
            data: JSON.stringify(_data),
            cache: false,
            success: function (result) {
                console.log(result);
            }
        });
    });
});