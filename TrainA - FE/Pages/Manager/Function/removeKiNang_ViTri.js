function getIdvitri_XoaKN(kinang) {
  var vitri = $(`#example`).val();
  if (typeof vitri === "undefined") {
    alert("Vị trí bị lỗi, vui lòng chọn lại vị trí");
  } else {
    var apiURL1 = "https://localhost:5001/api/vitri/xoakinang/";
    console.log("Du an id: ", vitri);
    // var e = document.getElementById("kien_thuc_form");
    // var kinang = e.value;
    console.log("Kien thuc xoa: ", kinang);
    $.ajax({
      type: "DELETE",
      url: apiURL1 + vitri,
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
    // var apiURL = "https://localhost:5001/api/vitri/chitiet/" + vitri;
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
