$(document).ready(function () {
  getListViTri();
  chiTietViTri();
});

function getListViTri() {
  var apiURL = "https://localhost:5001/api/vitri";
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach phong ban: ", res);
      var result = "";
      for (let i = 0; i < res.length; i++) {
        result += `<tr id="${res[i].MA_VT}" class="job_element">
				<td>
					<a onclick="chiTietViTri('${res[i].MA_VT}')">${res[i].MA_VT}</a>
				</td>
				<td>${res[i].TEN_VT}</td>
			  </tr>`;
      }
      $(`#job_list`).append(result);
    },
    error: function (err) {
      console.log("error", err);
    },
  });
}

function chiTietViTri(value) {
  getViTri(value);
}

function getViTri(id) {
  var apiURL = "https://localhost:5001/api/vitri/chitiet/" + id;
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Chi tiet vi tri: ", res);
      var result = "";
      result += `
	  <input id="example" value="${id}" type="hidden"/>
	  <input id="kt_length" value="${res.KienThuc.length}" type="hidden"/>
	  <input id="kn_length" value="${res.KiNang.length}" type="hidden"/>
		  <h3>Tên vị trí</h3>
		  <p>${res.ThongTin[0].TEN_VT}</p>
		  <h3>Mô tả</h3>
		  <p>${res.ThongTin[0].MOTA}</p>`;
      $(`#job_detail`).empty();
      $(`#job_detail`).append(result);
      var knowledge = "";
      for (let i = 0; i < res.KienThuc.length; i++) {
        knowledge += `
		  <tr>
			  <td>${res.KienThuc[i].TEN_KT} 
				  <span onclick="getIdvitri_XoaKT(${res.KienThuc[i].MA_KT} )" id="icon${
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
				  <span onclick="getIdvitri_XoaKN(${res.KiNang[i].MA_KN})" id="icon${
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
