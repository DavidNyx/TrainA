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
    public class ViTriController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ViTriController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select * from
                            dbo.VITRI
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


        [HttpGet("chitiet/{id}")]
        public JsonResult GetKienThucByDuAn(int id)
        {
            string query = @"
                            select TEN_KT, KIENTHUC.MA_KT
                            from
                            dbo.CHITIET_VT_KT left join dbo.KIENTHUC
                            on CHITIET_VT_KT.MA_KT = KIENTHUC.MA_KT
                            where MA_VT = @MA_VT
                            ";
            string query1 = @"
                            select TEN_KN, KINANG.MA_KN
                            from
                            dbo.CHITIET_VT_KN left join dbo.KINANG
                            on CHITIET_VT_KN.MA_KN = KINANG.MA_KN
                            where MA_VT = @MA_VT
                            ";
            string thongtinViTri = @"
                            select *
                            from
                            dbo.VITRI
                            where MA_VT = @MA_VT
                            ";
            string queryNhanVien = @"select NHANVIEN.MA_NV, TEN_NV 
                            from
                            dbo.VITRI join dbo.NHANVIEN 
                            on VITRI.MA_VT = NHANVIEN.MA_VITRI
                            where MA_VT = @MA_VT"
                            ;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            SqlDataReader myReader;
            var dsKiNang = new DataTable();
            var dsKienThuc = new DataTable();
            var ttViTri = new DataTable();
            var dsNhanVien = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_VT", id);
                    myReader = myCommand.ExecuteReader();
                    dsKienThuc.Load(myReader);
                    myReader.Close();
                }

                using (SqlCommand myCommand = new SqlCommand(thongtinViTri, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_VT", id);
                    myReader = myCommand.ExecuteReader();
                    ttViTri.Load(myReader);

                    myReader.Close();
                }
                using (SqlCommand myCommand = new SqlCommand(queryNhanVien, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_VT", id);
                    myReader = myCommand.ExecuteReader();
                    dsNhanVien.Load(myReader);

                    myReader.Close();
                }

                using (SqlCommand myCommand = new SqlCommand(query1, myCon))
                {

                    myCommand.Parameters.AddWithValue("@MA_VT", id);
                    myReader = myCommand.ExecuteReader();
                    dsKiNang.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            var result = new
            {
                ThongTin = ttViTri,
                NhanVien = dsNhanVien,
                KiNang = dsKiNang,
                KienThuc = dsKienThuc
            };
            return new JsonResult(result);
        }



        [HttpPost("themkinang/{id}")]
        public JsonResult PostThemKiNang(KiNang kiNang, int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            if (Utils.myValueExist("ViTri", "MA_VT", id.ToString(), sqlDataSource))
            {
                if (Utils.myValueExist("KiNang", "MA_KN", kiNang.MaKN.ToString(), sqlDataSource))
                {
                    if (!Utils.myValueExist("CHITIET_VT_KN", "Ma_VT =" + id.ToString() + " and MA_KN", kiNang.MaKN.ToString(), sqlDataSource))
                    {
                        string query = @"
                           insert into dbo.CHITIET_VT_KN (MA_VT,MA_KN)
                           values (@MA_VT , @MA_KN)
                            ";

                        DataTable table = new DataTable();
                        SqlDataReader myReader;
                        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                        {
                            myCon.Open();
                            using (SqlCommand myCommand = new SqlCommand(query, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@MA_VT", id);
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
            if (Utils.myValueExist("VITRI", "MA_VT", id.ToString(), sqlDataSource))
            {
                if (Utils.myValueExist("KienThuc", "MA_KT", kienThuc.MaKT.ToString(), sqlDataSource))
                {
                    if (!Utils.myValueExist("CHITIET_VT_KT", "Ma_VT =" + id.ToString() + " and MA_KT", kienThuc.MaKT.ToString(), sqlDataSource))
                    {
                        string query = @"
                           insert into dbo.CHITIET_VT_KT (MA_VT,MA_KT)
                           values (@MA_VT , @MA_KT)
                            ";

                        DataTable table = new DataTable();
                        SqlDataReader myReader;
                        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                        {
                            myCon.Open();
                            using (SqlCommand myCommand = new SqlCommand(query, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@MA_VT", id);
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

        [HttpDelete("xoakinang/{id}")]
        public JsonResult XoaKiNang(KiNang kiNang, int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            if (Utils.myValueExist("ViTri", "MA_VT", id.ToString(), sqlDataSource))
            {
                if (Utils.myValueExist("KiNang", "MA_KN", kiNang.MaKN.ToString(), sqlDataSource))
                {
                    if (Utils.myValueExist("CHITIET_VT_KN", "Ma_VT =" + id.ToString() + " and MA_KN", kiNang.MaKN.ToString(), sqlDataSource))
                    {
                        string query = @"
                          delete CHITIET_VT_KN
                          where MA_VT = @MA_VT and MA_KN = @MA_KN
                            ";

                        DataTable table = new DataTable();
                        SqlDataReader myReader;
                        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                        {
                            myCon.Open();
                            using (SqlCommand myCommand = new SqlCommand(query, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@MA_VT", id);
                                myCommand.Parameters.AddWithValue("@MA_KN", kiNang.MaKN);
                                myReader = myCommand.ExecuteReader();
                                table.Load(myReader);
                                myReader.Close();
                                myCon.Close();
                            }
                        }
                        return new JsonResult("Xoá thành công");
                    }
                    return new JsonResult("Không tồn tại");
                }
            }
            return new JsonResult("Xoá thất bại");
        }

        [HttpDelete("xoakienthuc/{id}")]
        public JsonResult XoaKienThuc(KiNang kiNang, int id)
        {
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            if (Utils.myValueExist("ViTri", "MA_VT", id.ToString(), sqlDataSource))
            {
                if (Utils.myValueExist("KienThuc", "MA_KT", kiNang.MaKN.ToString(), sqlDataSource))
                {
                    if (Utils.myValueExist("CHITIET_VT_KT", "Ma_VT =" + id.ToString() + " and MA_KT", kiNang.MaKN.ToString(), sqlDataSource))
                    {
                        string query = @"
                          delete CHITIET_VT_KT
                          where MA_VT = @MA_VT and MA_KT = @MA_KT
                            ";

                        DataTable table = new DataTable();
                        SqlDataReader myReader;
                        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                        {
                            myCon.Open();
                            using (SqlCommand myCommand = new SqlCommand(query, myCon))
                            {
                                myCommand.Parameters.AddWithValue("@MA_VT", id);
                                myCommand.Parameters.AddWithValue("@MA_KT", kiNang.MaKN);
                                myReader = myCommand.ExecuteReader();
                                table.Load(myReader);
                                myReader.Close();
                                myCon.Close();
                            }
                        }
                        return new JsonResult("Xoá thành công");
                    }
                    return new JsonResult("Không tồn tại");
                }
            }
            return new JsonResult("Xoá thất bại");
        }
    }
}
