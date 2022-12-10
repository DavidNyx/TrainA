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

namespace TrainA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Microsoft.AspNetCore.Cors.EnableCors(origins: '*', headers: '*', HttpMethods:'*')]
    public class DuAnController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DuAnController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select MA_DA, TEN_DA
                            from dbo.duan
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
            //Console.WriteLine(new JsonResult(table));
            return new JsonResult(table);
        }

        [HttpGet("chitiet/{id}")]
        public JsonResult GetKienThucByDuAn(int id)
        {
            string query = @"
                            select TEN_KT
                            from
                            dbo.CHITIET_DA_KT left join dbo.KIENTHUC
                            on CHITIET_DA_KT.MA_KT = KIENTHUC.MA_KT
                            where MA_DA = @MA_DA
                            ";
            string query1 = @"
                            select TEN_KN
                            from
                            dbo.CHITIET_DA_KN left join dbo.KINANG
                            on CHITIET_DA_KN.MA_KN = KINANG.MA_KN                          
                            where MA_DA = @MA_DA
                            ";
            string thongtinDuAn = @"
                            select NGAYBATDAU,NGAYKETTHUC,NOIDUNG
                            from
                            dbo.DUAN
                            where MA_DA = @MA_DA
                            ";
            string queryNhanVien = @"select NHANVIEN.MA_NV, TEN_NV 
                            from 
                            dbo.CHITIET_DA_NV join dbo.NHANVIEN 
                            on CHITIET_DA_NV.MA_NV = NHANVIEN.MA_NV
                            where MA_DA = @MA_DA"
                            ;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            SqlDataReader myReader;
            ArrayList dsKiNang = new ArrayList();
            ArrayList dsKienThuc = new ArrayList();
            var ttDuAn = new DataTable();
            var dsNhanVien= new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_DA", id);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dsKienThuc.Add(myReader[0]);
                    }
                    myReader.Close();
                }

                using (SqlCommand myCommand = new SqlCommand(thongtinDuAn, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_DA", id);
                    myReader = myCommand.ExecuteReader();
                    ttDuAn.Load(myReader);

                    myReader.Close();
                }
                using (SqlCommand myCommand = new SqlCommand(queryNhanVien, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_DA", id);
                    myReader = myCommand.ExecuteReader();
                    dsNhanVien.Load(myReader);

                    myReader.Close();
                }

                using (SqlCommand myCommand = new SqlCommand(query1, myCon))
                {

                    myCommand.Parameters.AddWithValue("@MA_DA", id);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read()) {
                        dsKiNang.Add(myReader[0]);
                    }
                    myReader.Close();
                    myCon.Close();
                }
            }
            var result = new
            {
                ThongTin = ttDuAn,
                NhanVien = dsNhanVien,
                KiNang = dsKiNang,
                KienThuc = dsKienThuc
            };
            return new JsonResult(result);
        }
    }
}
