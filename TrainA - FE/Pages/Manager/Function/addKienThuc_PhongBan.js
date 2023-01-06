function getIdphongban_KT() {
  var phongban = $(`#example`).val();
  if (typeof phongban === "undefined") {
    alert("Vui lòng chọn dự án để thêm kiến thức");
  } else {
    var apiURL1 = "https://localhost:5001/api/phongban/themkienthuc/";
    console.log("Phong ban id: ", phongban);
    var e = document.getElementById("kien_thuc_form");
    var kienthuc = e.value;
    console.log("Kien thuc add: ", kienthuc);
    $.ajax({
      type: "POST",
      url: apiURL1 + phongban,
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      data: JSON.stringify({ MAKT: kienthuc }),
      success: function (res) {
        alert(res);
        console.log("Da thuc hien");
      },
    });
    var apiURL = "https://localhost:5001/api/phongban/chitiet/" + phongban;
    $.ajax({
      method: "GET",
      url: apiURL,
      success: function (res) {
        console.log("Reload chi tiet Phong ban: ", res);
        var knowledge = "";
        for (let i = 0; i < res.KienThuc.length; i++) {
          knowledge += `
					<tr>
						<td>${res.KienThuc[i].TEN_KT}
							<span id="icon${i + 1}" class="material-symbols-outlined">close</span>
						</td>
					</tr>
					`;
          console.log("Reaload danh sach kien thuc: ", res.KienThuc[i]);
        }
        $(`#knowledge_list`).empty();
        $(`#knowledge_list`).append(knowledge);
      },
      error: function (err) {
        console.log("error", err);
      },
    });
  }
}
