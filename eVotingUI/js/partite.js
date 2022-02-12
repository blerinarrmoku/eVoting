let _baseUrl = "https://localhost:44314/api";

$(document).ready(function () {
    let emailSignedIn = window.localStorage.getItem("email");
    $("#emailSpace").html(emailSignedIn);

    $.ajax({
        url: _baseUrl+'/parties/allParties/', 
        type: 'GET',
        contentType: "application/json",
        dataType: "json",
        cache: false,
        async: false,
        success: function (result) {
            let lista = result.data.parties;
            let tableRows = "";
            for(var i = 0;i < lista.length;i++){
                tableRows += 
                `
                    <tr>
                        <td><img src="${lista[i].imageUrl}" style="width: 80px;" /></td>
                        <td>${lista[i].name}</td>
                        <td>${lista[i].abbreviation}</td>
                        <td>
                            <button type="button" class="btn btn-sm btn-danger btnDelete" value="${lista[i].id}">
                                Fshij
                            </button>
                        </td>
                    </tr>
                `
            }
            $("#tableBody").html("")
            $("#tableBody").html(tableRows);
        }
    });

    $(".btnDelete").on("click",function(){
        var id = $(this).attr("value");
        alert(id);
        $.ajax({
            url: _baseUrl+'/parties/deleteParty?id='+id, 
            type: 'GET',
            contentType: "application/json",
            dataType: "json",
            cache: false,
            async: false,
            success: function (result) {
                window.location.href = "/partite.html";
            }
        });
    });

    $("#tableData").DataTable({
        "order": [],
        "bInfo": false,
        "responsive": true,
        "language": {
            "lengthMenu": "Show _MENU_",
        },
        "dom":
            "<'row'" +
            "<'col-sm-6 d-flex align-items-center justify-conten-start'l>" +
            "<'col-sm-6 d-flex align-items-center justify-content-end'f>" +
            ">" +

            "<'table-responsive'tr>" +

            "<'row'" +
            "<'col-sm-12 col-md-5 d-flex align-items-center justify-content-center justify-content-md-start'i>" +
            "<'col-sm-12 col-md-7 d-flex align-items-center justify-content-center justify-content-md-end'p>" +
            ">"
    });
});