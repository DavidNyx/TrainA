function getIdphongban_XoaKN(kinang) {
  var phongban = $(`#example`).val();
  if (typeof phongban === "undefined") {
    alert("Phòng ban bị lỗi, vui lòng chọn lại phòng ban");
  } else {
    var apiURL1 = "https://localhost:5001/api/phongban/xoakinang/";
    console.log("Du an id: ", phongban);
    // var e = document.getElementById("kien_thuc_form");
    // var kinang = e.value;
    console.log("Kien thuc xoa: ", kinang);
    $.ajax({
      type: "DELETE",
      url: apiURL1 + phongban,
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
    // var apiURL = "https://localhost:5001/api/phongban/chitiet/" + phongban;
    // const resolve1 = await $.ajax({
    //   method: "GET",
    //   url: apiURL,
    //   success: function (res) {
    //     console.log("Reload chi tiet du an: ", res);
    //     var knowledge = "";
    //     for (let i = 0; i < res.KiNang.length; i++) {
    //       knowledge += `
    // 				  <tr>
    // 					  <td>${res.KiNang[i].TEN_KN}
    // 						  <span id="icon${i + 1}" class="material-symbols-outlined">close</span>
    // 					  </td>
    // 				  </tr>
    // 				  `;
    //       console.log("Reaload danh sach kien thuc: ", res.KiNang[i]);
    //     }
    //     $(`#knowledge_list`).empty();
    //     $(`#knowledge_list`).append(knowledge);
    //   },
    //   error: function (err) {
    //     console.log("error", err);
    //   },
    // });
  }
}
