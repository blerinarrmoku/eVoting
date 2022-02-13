let _baseUrl = "https://localhost:44314/api";

let emailSignedIn = window.localStorage.getItem("email");
$("#emailSpace").html(emailSignedIn);

var votes = [];
var names = [];

$.ajax({
    url: _baseUrl+'/votes/GetCountedVotes', 
    type: 'GET',
    data: {isCandidate: true},
    contentType: "application/json",
    dataType: "json",
    cache: false,
    async: false,
    success: function (result) {
        votes = result.data.candidateVotes;
        names = result.data.candidateNames;
    }
});

var options = {
    series: [{
      name: "Votes",
      data: votes
  }],
    chart: {
    type: 'bar',
    height: 350
  },
  plotOptions: {
    bar: {
      borderRadius: 4,
      horizontal: true,
    }
  },
  dataLabels: {
    enabled: false
  },
  xaxis: {
    categories: names,
  }
  };

  var chart = new ApexCharts(document.querySelector("#chart"), options);
  chart.render();