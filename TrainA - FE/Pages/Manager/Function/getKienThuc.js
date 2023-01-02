$(document).ready(function () {
  getListKienThuc();
});

function getListKienThuc() {
  var apiURL = "https://localhost:5001/api/kienthuc";
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach kien thuc: ", res);
      var result = "";
      for (let i = 0; i < res.DSKienThuc.length; i++) {
        result += `
				<option value="${res.DSKienThuc[i].MA_KT}">${res.DSKienThuc[i].TEN_KT}</option>
			`;
      }
      $(`#ds_kienthuc`).append(result);
      $(`#kien_thuc_form`).append(result);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
}
