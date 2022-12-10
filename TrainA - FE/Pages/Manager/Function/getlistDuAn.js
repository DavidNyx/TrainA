$(document).ready(function () {
  getListDuAn();
  chiTietDuAn();
});

function chiTietDuAn() {
  $("body").on("click", "a", function () {
    var self = $(this); //this la the "a"
    var value = self.text();
    console.log(value);
    getDuAn(value);
  });
}

function getDuAn(id) {
  var apiURL = "https://localhost:44398/api/duan/chitiet/" + id;
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("hello", res);
      var result = "";
      result += `
		<h3>Ngày bắt đầu</h3>
		<p>${res.ThongTin[0].NGAYBATDAU}</p>
		<h3>Ngày kết thúc</h3>
		<p>${res.ThongTin[0].NGAYKETTHUC}</p>
		<h3>Nội dung</h3>
		<p>${res.ThongTin[0].NOIDUNG}</p>`;
      $(`#project_detail`).empty();
      $(`#project_detail`).append(result);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
}

function getListDuAn() {
  var apiURL = "https://localhost:44398/api/duan";
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("hello", res);
      var result = "";
      for (let i = 0; i < res.length; i++) {
        result += `<tr>
          <td>
		  	<a>${res[i].MA_DA}</a>
		  </td>
          <td>${res[i].TEN_DA}</td>
        </tr>`;
      }
      $(`#project_list`).append(result);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
}
