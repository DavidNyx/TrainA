$(document).ready(function () {
  getListViTri();
  chiTietViTri();
});

function chiTietViTri() {
  $("body").on("click", "a", function () {
    var self = $(this); //this la the "a"
    var value = self.text();
    console.log(value);
    getViTri(value);
  });
}

function getViTri(id) {
  var apiURL = "https://localhost:44398/api/vitri/chitiet/" + id;
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Chi tiet vi tri: ", res);
      var result = "";
      result += `
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
			  <td>${res.KienThuc[i]} 
				  <span id="icon${i + 1}" class="material-symbols-outlined">close</span>
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
			  <td>${res.KiNang[i]} 
				  <span id="icon${i + 1}" class="material-symbols-outlined">close</span>
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

function getListViTri() {
  var apiURL = "https://localhost:44398/api/vitri";
  $.ajax({
    method: "GET",
    url: apiURL,
    success: function (res) {
      console.log("Danh sach phong ban: ", res);
      var result = "";
      for (let i = 0; i < res.length; i++) {
        result += `<tr>
			  <td>
				  <a>${res[i].MA_VT}</a>
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
