$(document).ready(function () {
  getListPhongBan();
  chiTietPhongBan();
});

function chiTietPhongBan(value) {
  getPhongBan(value);
}

function getPhongBan(id) {
  var apiURL = "https://localhost:5001/api/phongban/chitiet/" + id;
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Chi tiet phong ban: ", res);
      var result = "";
      result += `
	  		<input id="example" value="${id}" type="hidden"/>
			  <input id="kt_length" value="${res.KienThuc.length}" type="hidden"/>
			  <input id="kn_length" value="${res.KiNang.length}" type="hidden"/>
		  <h3>Tên phòng ban</h3>
		  <p>${res.ThongTin[0].TEN_PB}</p>
		  <h3>Nội dung</h3>
		  <p>${res.ThongTin[0].MOTA}</p>`;
      $(`#department_detail`).empty();
      $(`#department_detail`).append(result);
      var knowledge = "";
      for (let i = 0; i < res.KienThuc.length; i++) {
        knowledge += `
		  <tr>
			  <td>${res.KienThuc[i].TEN_KT} 
				  <span onclick="getIdphongban_XoaKT(${res.KienThuc[i].MA_KT})" id="kt_icon${
          i + 1
        }" class="material-symbols-outlined">close</span>
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
				  <span onclick="getIdphongban_XoaKN(${res.KiNang[i].MA_KN})" id="kn_icon${
          i + 1
        }" class="material-symbols-outlined">close</span>
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

function getListPhongBan() {
  var apiURL = "https://localhost:5001/api/phongban";
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach phong ban: ", res);
      var result = "";
      for (let i = 0; i < res.length; i++) {
        result += `<tr id="${res[i].MA_PB}" class="department_element">
			<td>
				<a onclick="chiTietPhongBan('${res[i].MA_PB}')">${res[i].MA_PB}</a>
			</td>
			<td>${res[i].TEN_PB}</td>
		  </tr>`;
      }
      $(`#department_list`).append(result);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
}
