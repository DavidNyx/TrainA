$(document).ready(function () {
  getListDuAn();
  chiTietDuAn();
});

function getListDuAn() {
  var apiURL = "https://localhost:5001/api/duan";
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach du an: ", res);
      var result = "";
      for (let i = 0; i < res.length; i++) {
        result += `<tr id="${res[i].MA_DA}" class="project_element">
			<td>
				<a onclick="chiTietDuAn('${res[i].MA_DA}')">${res[i].MA_DA}</a>
			</td>
			<td>${res[i].TEN_DA}</td>
		  <tr>`;
      }
      $(`#project_list`).append(result);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
}

function chiTietDuAn(id) {
  getDuAn(id);
}

function getDuAn(id) {
  var apiURL = "https://localhost:5001/api/duan/chitiet/" + id;
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Chi tiet du an: ", res);
      var result = "";
      result += `
	  	<input id="example" value="${id}" type="hidden"/>
		  <input id="kt_length" value="${res.KienThuc.length}" type="hidden"/>
		  <input id="kn_length" value="${res.KiNang.length}" type="hidden"/>
		<h3>Ngày bắt đầu</h3>
		<p>${res.ThongTin[0].NGAYBATDAU}</p>
		<h3>Ngày kết thúc</h3>
		<p>${res.ThongTin[0].NGAYKETTHUC}</p>
		<h3>Nội dung</h3>
		<p>${res.ThongTin[0].NOIDUNG}</p>`;
      $(`#project_detail`).empty();
      $(`#project_detail`).append(result);
      var knowledge = "";
      for (let i = 0; i < res.KienThuc.length; i++) {
        knowledge += `
		<tr>
			<td>${res.KienThuc[i].TEN_KT} 
				<span onclick="getIdDuAn_XoaKT(${res.KienThuc[i].MA_KT})" id="kt_icon${i}" class="material-symbols-outlined">close</span>
			</td>
		</tr>
		`;
        console.log("Danh sach kien thuc: ", res.KienThuc[i]);
      }
      $(`#knowledge_list`).empty();
      $(`#knowledge_list`).append(knowledge);
      var skill = "";
      for (let i = 0; i < res.KiNang.length; i++) {
        skill += `
		<tr>
			<td>${res.KiNang[i].TEN_KN} 
				<span onclick="getIdDuAn_XoaKN(${res.KiNang[i].MA_KN})" id="kn_icon${i}" class="material-symbols-outlined">close</span>
			</td>
		</tr>
		`;
        console.log("Danh sach ki nang: ", res.KiNang[i]);
      }
      $(`#skill_list`).empty();
      $(`#skill_list`).append(skill);
      var member = "";
      for (let i = 0; i < res.NhanVien.length; i++) {
        member += `
			<tr>
				<td>${res.NhanVien[i].MA_NV}</td>
				<td>${res.NhanVien[i].TEN_NV}</td>
			</tr>
		`;
        console.log("Danh sach nhan vien: ", res.NhanVien[i]);
      }
      $(`#member_list`).empty();
      $(`#member_list`).append(member);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
}
