let _baseUrl = "https://localhost:44314/api";

$(document).ready(function () {

    $.ajax({
        url: _baseUrl+'/votes/GetVotingList', 
        type: 'GET',
        contentType: "application/json",
        dataType: "json",
        cache: false,
        async: false,
        success: function (result) {
            let candidates = result.candidates;
            let parties = result.parties;
            let candidateRow = "";
            let partiesRow = "";
            for(var i = 0;i < candidates.length;i++){
                candidateRow += 
                `
                    <div class="col-lg-2 col-6 p-0">
                        <div class="d-flex flex-column align-items-center p-3 candidateBox" value="${candidates[i].id}">
                            <div style="width: 120px;">
                                <img style="border-radius: 100%;" src="${candidates[i].imageUrl}" alt="" class="img-fluid">
                            </div>
                            <div>
                                <h6>${candidates[i].name}</h6>
                            </div>
                        </div>
                    </div>
                `
            }
            for(var i = 0;i < candidates.length;i++){
                partiesRow += 
                `
                    <div class="col-lg-12 col-6">
                        <div class="d-flex flex-column align-items-center candidateParty p-3" value="${parties[i].id}">
                            <div>
                                <img style="width: 200px;" class="img-fluid" src="${parties[i].imageUrl}" alt="Vetevendosje">
                            </div>
                            <div>
                                <h6 class="text-center">${parties[i].name}</h6>
                            </div>
                        </div>
                    </div>
                `
            }
            $("#candidatesRow").html(candidateRow);
            $("#partiesRow").html(partiesRow);
        }
    });

    $(".candidateBox").on("click",function(){
        $(".candidateBox").removeClass("selectedCandidate");
        $(this).addClass("selectedCandidate");
    });

    $(".candidateParty").on("click",function(){
        $(".candidateParty").removeClass("selectedParty");
        $(this).addClass("selectedParty");
        var partyId = $(this).attr("value");
        $.ajax({
            url: _baseUrl+'/votes/GetPartiesMembers?partyId='+partyId, 
            type: 'GET',
            contentType: "application/json",
            dataType: "json",
            cache: false,
            async: false,
            success: function (result) {
                let members = "";
                for(var i = 0;i < result.length;i++){
                    members += 
                    `
                        <div class="col-lg-3 col-6">
                            <div class="d-flex flex-column align-items-center p-3">
                                <div>
                                    ${result[i].name}
                                </div>
                                <div>
                                    <input type="checkbox" class="checkboxCandidate" value="${result[i].id}">
                                </div>
                            </div>
                        </div>
                    `
                }
                $("#candidateCheckboxes").html("");
                $("#candidateCheckboxes").html(members);
            }
        });

        $(".checkboxCandidate").change(function() {
            if(this.checked) {
                var check = $('#candidateCheckboxes').find('input[type=checkbox]:checked').length;
                if(check == 6){
                    $(this).prop("checked",false);
                }
            }
        });
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