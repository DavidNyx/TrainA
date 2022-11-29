$(document).ready(function () {
  var apiURL = "https://localhost:44398/api/duan";
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("hello", res);
      var result = "";
      for (let i = 0; i < res.length; i++) {
        result += `<tr>
          <td>${res[i].MA_DA}</td>
          <td>${res[i].TEN_DA}</td>
		  <td>${res[i].NGAYBATDAU}</td>
		  <td>${res[i].NGAYKETTHUC}</td>
		  <td>${res[i].NOIDUNG}</td>
        </tr>`;
      }
      $(`#project_list`).append(result);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
});
