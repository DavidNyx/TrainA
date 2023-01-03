$(document).ready(function () {
  filterKyNang();
  filterKienThuc();
});

async function getListphongban_KyNang(kynang) {
  var apiURL = "https://localhost:5001/api/phongban";
  var temp_id = [];
  var phongban_id = [];
  const resolve = await $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach phong ban: ", res);
      //get chi tiet tung phong ban
      for (let i = 0; i < res.length; i++) {
        temp_id.push(res[i].MA_PB);
      }
    },
  });
  for (let h = 0; h < temp_id.length; h++) {
    var apiURL = "https://localhost:5001/api/phongban/chitiet/" + temp_id[h];
    const resolve = await $.ajax({
      method: "GET",
      url: apiURL,
      success: function (res_kynang) {
        //get PBnh sach ky nang
        for (let j = 0; j < res_kynang.KiNang.length; j++) {
          //tong hop cac phong ban id chung ky nang
          if (res_kynang.KiNang[j].MA_KN == kynang) {
            phongban_id.push(h);
          }
        }
      },
    });
  }
  return phongban_id;
}

function filterKyNang() {
  $(`#ds_kynang`).change(async function (e) {
    // retrieve the dropdown selected value
    var kynang = e.target.value;
    console.log("ky nang: ", kynang);
    var table = $(`#department_list`);
    if (kynang != "Empty") {
      const phongban_id_123 = await getListphongban_KyNang(kynang);
      console.log("So luong phong ban: ", phongban_id_123);
      table.find(".department_element").hide();
      for (let h = 0; h < phongban_id_123.length; h++) {
        var index = phongban_id_123[h] + 1;
        table.find("tr[id=" + index + "]").show();
      }
    } else {
      table.find("tr").show();
    }
  });
}

async function getListphongban_KienThuc(kienthuc) {
  var apiURL = "https://localhost:5001/api/phongban";
  var temp_id = [];
  var phongban_id = [];
  const resolve = await $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("PBnh sach phong ban: ", res);
      //get chi tiet tung phong ban
      for (let i = 0; i < res.length; i++) {
        temp_id.push(res[i].MA_PB);
      }
    },
  });
  for (let h = 0; h < temp_id.length; h++) {
    var apiURL = "https://localhost:5001/api/phongban/chitiet/" + temp_id[h];
    const resolve = await $.ajax({
      method: "GET",
      url: apiURL,
      success: function (res_kienthuc) {
        //get PBnh sach ky nang
        for (let j = 0; j < res_kienthuc.KienThuc.length; j++) {
          //tong hop cac phong ban id chung ky nang
          if (res_kienthuc.KienThuc[j].MA_KT == kienthuc) {
            phongban_id.push(h);
          }
        }
      },
    });
  }
  return phongban_id;
}

function filterKienThuc() {
  $(`#ds_kienthuc`).change(async function (e) {
    // retrieve the dropdown selected value
    var kienthuc = e.target.value;
    console.log("kien thuc: ", kienthuc);
    var table = $(`#department_list`);
    if (kienthuc != "Empty") {
      const phongban_id_123 = await getListphongban_KienThuc(kienthuc);
      console.log("So luong phong ban: ", phongban_id_123);
      table.find(".department_element").hide();
      for (let h = 0; h < phongban_id_123.length; h++) {
        var index = phongban_id_123[h] + 1;
        table.find("tr[id=" + index + "]").show();
      }
    } else {
      table.find("tr").show();
    }
  });
}
