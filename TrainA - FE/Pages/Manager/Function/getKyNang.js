$(document).ready(function () {
  getListKyNang();
});

function getListKyNang() {
  var apiURL = "https://localhost:5001/api/kinang";
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach ky nang: ", res);
      var result = "";
      for (let i = 0; i < res.DSKiNang.length; i++) {
        result += `
				<option value="${res.DSKiNang[i].MA_KN}">${res.DSKiNang[i].TEN_KN}</option>
			`;
      }
      $(`#ds_kynang`).append(result);
      $(`#ky_nang_form`).append(result);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
}
