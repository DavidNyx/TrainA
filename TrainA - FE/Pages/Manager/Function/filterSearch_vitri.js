$(document).ready(function () {
  filterKyNang();
  filterKienThuc();
});

async function getListvitri_KyNang(kynang) {
  var apiURL = "https://localhost:5001/api/vitri";
  var temp_id = [];
  var vitri_id = [];
  const resolve = await $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach vi tri cong viec: ", res);
      //get chi tiet tung vi tri cong viec
      for (let i = 0; i < res.length; i++) {
        temp_id.push(res[i].MA_VT);
      }
    },
  });
  for (let h = 0; h < temp_id.length; h++) {
    var apiURL = "https://localhost:5001/api/vitri/chitiet/" + temp_id[h];
    const resolve = await $.ajax({
      method: "GET",
      url: apiURL,
      success: function (res_kynang) {
        //get danh sach ky nang
        for (let j = 0; j < res_kynang.KiNang.length; j++) {
          //tong hop cac vi tri cong viec id chung ky nang
          if (res_kynang.KiNang[j].MA_KN == kynang) {
            vitri_id.push(h);
          }
        }
      },
    });
  }
  return vitri_id;
}

function filterKyNang() {
  $(`#ds_kynang`).change(async function (e) {
    // retrieve the dropdown selected value
    var kynang = e.target.value;
    console.log("ky nang: ", kynang);
    var table = $(`#job_list`);
    if (kynang != "Empty") {
      const vitri_id_123 = await getListvitri_KyNang(kynang);
      console.log("So luong vi tri cong viec: ", vitri_id_123);
      table.find(".job_element").hide();
      for (let h = 0; h < vitri_id_123.length; h++) {
        var index = vitri_id_123[h] + 1;
        table.find("tr[id=" + index + "]").show();
      }
    } else {
      table.find("tr").show();
    }
  });
}

async function getListvitri_KienThuc(kienthuc) {
  var apiURL = "https://localhost:5001/api/vitri";
  var temp_id = [];
  var vitri_id = [];
  const resolve = await $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach vi tri cong viec: ", res);
      //get chi tiet tung vi tri cong viec
      for (let i = 0; i < res.length; i++) {
        temp_id.push(res[i].MA_VT);
      }
    },
  });
  for (let h = 0; h < temp_id.length; h++) {
    var apiURL = "https://localhost:5001/api/vitri/chitiet/" + temp_id[h];
    const resolve = await $.ajax({
      method: "GET",
      url: apiURL,
      success: function (res_kienthuc) {
        //get danh sach ky nang
        for (let j = 0; j < res_kienthuc.KienThuc.length; j++) {
          //tong hop cac vi tri cong viec id chung ky nang
          if (res_kienthuc.KienThuc[j].MA_KT == kienthuc) {
            vitri_id.push(h);
          }
        }
      },
    });
  }
  return vitri_id;
}

function filterKienThuc() {
  $(`#ds_kienthuc`).change(async function (e) {
    // retrieve the dropdown selected value
    var kienthuc = e.target.value;
    console.log("kien thuc: ", kienthuc);
    var table = $(`#job_list`);
    if (kienthuc != "Empty") {
      const vitri_id_123 = await getListvitri_KienThuc(kienthuc);
      console.log("So luong vi tri cong viec: ", vitri_id_123);
      table.find(".job_element").hide();
      for (let h = 0; h < vitri_id_123.length; h++) {
        var index = vitri_id_123[h] + 1;
        table.find("tr[id=" + index + "]").show();
      }
    } else {
      table.find("tr").show();
    }
  });
}
