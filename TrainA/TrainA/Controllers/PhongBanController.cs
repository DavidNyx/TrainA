using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TrainA.Entities;

namespace TrainA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PhongBanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select * from
                            dbo.phongban
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost("themkinang/{id}")]
        public JsonResult PostThemKiNang(KiNang kiNang, int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            if (Utils.myValueExist("PhongBan", "MA_PB", id.ToString(), sqlDataSource))
            {
                if (Utils.myValueExist("KiNang", "MA_KN", kiNang.MaKN.ToString(), sqlDataSource))
                {
                    if (!Utils.myValueExist("CHITIET_PB_KN", "MA_KN", kiNang.MaKN.ToString(), sqlDataSource))
                    {
                        string query = @"
                           insert into dbo.CHITIET_PB_KN (MA_PB,MA_KN)
                           values (@MA_PB , @MA_KN)
                            ";

                        DataTable table = new DataTable();
                        SqlDataReader myReader;
                        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                        {
                            myCon.Open();
                            using (SqlCommand myCommand = new SqlCommand(query, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@MA_PB", id);
                                myCommand.Parameters.AddWithValue("@MA_KN", kiNang.MaKN);
                                myReader = myCommand.ExecuteReader();
                                table.Load(myReader);
                                myReader.Close();
                                myCon.Close();
                            }
                        }
                        return new JsonResult("Thêm thành công");
                    }
                    return new JsonResult("Đã tồn tại");
                }
            }
            return new JsonResult("Thêm thất bại");
        }

        [HttpPost("themkienthuc/{id}")]
        public JsonResult PostThemKienThuc(KienThuc kienThuc, int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            if (Utils.myValueExist("PhongBan", "MA_PB", id.ToString(), sqlDataSource))
            {
                if (Utils.myValueExist("KienThuc", "MA_KT", kienThuc.MaKT.ToString(), sqlDataSource))
                {
                    if (!Utils.myValueExist("CHITIET_PB_KT", "MA_KT", kienThuc.MaKT.ToString(), sqlDataSource))
                    {
                        string query = @"
                           insert into dbo.CHITIET_PB_KT (MA_PB,MA_KT)
                           values (@MA_PB , @MA_KT)
                            ";

                        DataTable table = new DataTable();
                        SqlDataReader myReader;
                        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                        {
                            myCon.Open();
                            using (SqlCommand myCommand = new SqlCommand(query, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@MA_PB", id);
                                myCommand.Parameters.AddWithValue("@MA_KT", kienThuc.MaKT);
                                myReader = myCommand.ExecuteReader();
                                table.Load(myReader);
                                myReader.Close();
                                myCon.Close();
                            }
                        }
                        return new JsonResult("Thêm thành công");
                    }
                    return new JsonResult("Đã tồn tại");
                }
            }
            return new JsonResult("Thêm thất bại");
        }

        [HttpGet("chitiet/{id}")]
        public JsonResult GetKienThucByDuAn(int id)
        {
            string query = @"
                            select TEN_KT, KIENTHUC.MA_KT
                            from
                            dbo.CHITIET_PB_KT left join dbo.KIENTHUC
                            on CHITIET_PB_KT.MA_KT = KIENTHUC.MA_KT
                            where MA_PB = @MA_PB
                            ";
            string query1 = @"
                            select TEN_KN, KINANG.MA_KN
                            from
                            dbo.CHITIET_PB_KN left join dbo.KINANG
                            on CHITIET_PB_KN.MA_KN = KINANG.MA_KN                          
                            where MA_PB = @MA_PB
                            ";
            string thongtinPhgBan = @"
                            select *
                            from
                            dbo.PHONGBAN
                            where MA_PB = @MA_PB
                            ";
            string queryNhanVien = @"select NHANVIEN.MA_NV, TEN_NV 
                            from 
                            dbo.PHONGBAN join dbo.NHANVIEN 
                            on PHONGBAN.MA_PB = NHANVIEN.MA_PHONGBAN
                            where MA_PB = @MA_PB"
                            ;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            SqlDataReader myReader;
            var dsKiNang = new DataTable();
            var dsKienThuc = new DataTable();
            var ttPhgBan = new DataTable();
            var dsNhanVien = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_PB", id);
                    myReader = myCommand.ExecuteReader();
                    dsKienThuc.Load(myReader);
                    
                    myReader.Close();
                }

                using (SqlCommand myCommand = new SqlCommand(thongtinPhgBan, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_PB", id);
                    myReader = myCommand.ExecuteReader();
                    ttPhgBan.Load(myReader);

                    myReader.Close();
                }
                using (SqlCommand myCommand = new SqlCommand(queryNhanVien, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_PB", id);
                    myReader = myCommand.ExecuteReader();
                    dsNhanVien.Load(myReader);

                    myReader.Close();
                }

                using (SqlCommand myCommand = new SqlCommand(query1, myCon))
                {

                    myCommand.Parameters.AddWithValue("@MA_PB", id);
                    myReader = myCommand.ExecuteReader();
                    dsKiNang.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            var result = new
            {
                ThongTin = ttPhgBan,
                NhanVien = dsNhanVien,
                KiNang = dsKiNang,
                KienThuc = dsKienThuc
            };
            return new JsonResult(result);
        }
    }
}
