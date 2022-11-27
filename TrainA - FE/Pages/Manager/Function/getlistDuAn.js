$(document).ready(function () {
  var apiURL = "https://localhost:44398/api/duan";
  $.ajax({
    method: "GET",
    headers: {
      "Access-Control-Allow-Headers": "Content-Type",
      "Content-Type": "application/json",
    },
    crossDomain: true,
    dataType: "jsonp",
    url: apiURL,
    success: function (res) {
      console.log("hello", res);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
});
