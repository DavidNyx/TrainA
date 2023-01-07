function getIdDuAn_XoaKT(kienthuc) {
  var duan = $(`#example`).val();
  if (typeof duan === "undefined") {
    alert("Dự án bị lỗi, vui lòng chọn lại dự án");
  } else {
    var apiURL1 = "https://localhost:5001/api/duan/xoakienthuc/";
    console.log("Du an id: ", duan);
    // var e = document.getElementById("kien_thuc_form");
    // var kienthuc = e.value;
    console.log("Kien thuc xoa: ", kienthuc);
    $.ajax({
      type: "DELETE",
      url: apiURL1 + duan,
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
    // var apiURL = "https://localhost:5001/api/duan/chitiet/" + duan;
    // const resolve1 = await $.ajax({
    //   method: "GET",
    //   url: apiURL,
    //   success: function (res) {
    //     console.log("Reload chi tiet du an: ", res);
    //     var knowledge = "";
    //     for (let i = 0; i < res.KienThuc.length; i++) {
    //       knowledge += `
    // 				  <tr>
    // 					  <td>${res.KienThuc[i].TEN_KT}
    // 						  <span id="icon${i + 1}" class="material-symbols-outlined">close</span>
    // 					  </td>
    // 				  </tr>
    // 				  `;
    //       console.log("Reaload danh sach kien thuc: ", res.KienThuc[i]);
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
