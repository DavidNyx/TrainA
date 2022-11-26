using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TrainA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KienThucController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public KienThucController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("phongban/{id}")]
        public JsonResult GetKienThucByPhongBan(int id)
        {
            string query = @"
                            select TEN_KT
                            from
                            dbo.CHITIET_PB_KT left join dbo.KIENTHUC
                            on CHITIET_PB_KT.MA_KT = KIENTHUC.MA_KT
                            where MA_PB = @MA_PHG
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_PHG", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("duan/{id}")]
        public JsonResult GetKienThucByDuAn(int id)
        {
            string query = @"
                            select TEN_KT
                            from
                            dbo.CHITIET_DA_KT left join dbo.DUAN
                            on CHITIET_DA_KT.MA_KT = DUAN.MA_KT
                            where MA_DA = @MA_DA
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_DA", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("vitri/{id}")]
        public JsonResult GetKienThucByViTri(int id)
        {
            string query = @"
                            select TEN_KT
                            from
                            dbo.CHITIET_VT_KT left join dbo.VITRI
                            on CHITIET_VT_KT.MA_KT = VITRI.MA_KT
                            where MA_VT = @MA_VT
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KDongConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_VT", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
