function getIdDuAn_KN() {
  var duan = $(`#example`).val();
  if (typeof duan === "undefined") {
    alert("Vui lòng chọn dự án để thêm kỹ năng");
  } else {
    var apiURL1 = "https://localhost:5001/api/duan/themkinang/";
    console.log("Du an id: ", duan);
    var e = document.getElementById("ky_nang_form");
    var kinang = e.value;
    console.log("Ky nang add: ", kinang);
    $.ajax({
      type: "POST",
      url: apiURL1 + duan,
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      data: JSON.stringify({ MAKN: kinang }),
      success: function (res) {
        alert(res);
        console.log("Da thuc hien");
      },
    });
    // var apiURL = "https://localhost:5001/api/duan/chitiet/" + duan;
    // const resolve1 = await $.ajax({
    //   method: "GET",
    //   url: apiURL,
    //   success: function (res) {
    //     console.log("Reload chi tiet du an: ", res);
    //     var knowledge = "";
    //     for (let i = 0; i < res.KiNang.length; i++) {
    //       skill += `
	// 				<tr>
	// 					<td>${res.KiNang[i].TEN_KN}
	// 						<span id="icon${i + 1}" class="material-symbols-outlined">close</span>
	// 					</td>
	// 				</tr>
	// 				`;
    //       console.log("Reaload danh sach Ky nang: ", res.KiNang[i]);
    //     }
    //     $(`#skill_list`).empty();
    //     $(`#skill_list`).append(knowledge);
    //   },
    //   error: function (err) {
    //     console.log("error", err);
    //   },
    // });
  }
}
