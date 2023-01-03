$(document).ready(function () {
  filterKyNang();
  filterKienThuc();
});

async function getListDuAn_KyNang(kynang) {
  var apiURL = "https://localhost:5001/api/duan";
  var temp_id = [];
  var duan_id = [];
  const resolve = await $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach du an: ", res);
      //get chi tiet tung du an
      for (let i = 0; i < res.length; i++) {
        temp_id.push(res[i].MA_DA);
      }
    },
  });
  for (let h = 0; h < temp_id.length; h++) {
    var apiURL = "https://localhost:5001/api/duan/chitiet/" + temp_id[h];
    const resolve = await $.ajax({
      method: "GET",
      url: apiURL,
      success: function (res_kynang) {
        //get danh sach ky nang
        for (let j = 0; j < res_kynang.KiNang.length; j++) {
          //tong hop cac du an id chung ky nang
          if (res_kynang.KiNang[j].MA_KN == kynang) {
            duan_id.push(h);
          }
        }
      },
    });
  }
  return duan_id;
}

function filterKyNang() {
  $(`#ds_kynang`).change(async function (e) {
    // retrieve the dropdown selected value
    var kynang = e.target.value;
    console.log("ky nang: ", kynang);
    var table = $(`#project_list`);
    if (kynang != "Empty") {
      const duan_id_123 = await getListDuAn_KyNang(kynang);
      console.log("So luong du an: ", duan_id_123);
      table.find(".project_element").hide();
      for (let h = 0; h < duan_id_123.length; h++) {
        var index = duan_id_123[h] + 1;
        table.find("tr[id=" + index + "]").show();
      }
    } else {
      table.find("tr").show();
    }
  });
}

async function getListDuAn_KienThuc(kienthuc) {
  var apiURL = "https://localhost:5001/api/duan";
  var temp_id = [];
  var duan_id = [];
  const resolve = await $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach du an: ", res);
      //get chi tiet tung du an
      for (let i = 0; i < res.length; i++) {
        temp_id.push(res[i].MA_DA);
      }
    },
  });
  for (let h = 0; h < temp_id.length; h++) {
    var apiURL = "https://localhost:5001/api/duan/chitiet/" + temp_id[h];
    const resolve = await $.ajax({
      method: "GET",
      url: apiURL,
      success: function (res_kienthuc) {
        //get danh sach ky nang
        for (let j = 0; j < res_kienthuc.KienThuc.length; j++) {
          //tong hop cac du an id chung ky nang
          if (res_kienthuc.KienThuc[j].MA_KT == kienthuc) {
            duan_id.push(h);
          }
        }
      },
    });
  }
  return duan_id;
}

function filterKienThuc() {
  $(`#ds_kienthuc`).change(async function (e) {
    // retrieve the dropdown selected value
    var kienthuc = e.target.value;
    console.log("kien thuc: ", kienthuc);
    var table = $(`#project_list`);
    if (kienthuc != "Empty") {
      const duan_id_123 = await getListDuAn_KienThuc(kienthuc);
      console.log("So luong du an: ", duan_id_123);
      table.find(".project_element").hide();
      for (let h = 0; h < duan_id_123.length; h++) {
        var index = duan_id_123[h] + 1;
        table.find("tr[id=" + index + "]").show();
      }
    } else {
      table.find("tr").show();
    }
  });
}
