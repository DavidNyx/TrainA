﻿using Microsoft.AspNetCore.Http;
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


        [HttpGet("chitiet/{id}")]
        public JsonResult GetKienThucByDuAn(int id)
        {
            string query = @"
                            select TEN_KT
                            from
                            dbo.CHITIET_PB_KT left join dbo.KIENTHUC
                            on CHITIET_PB_KT.MA_KT = KIENTHUC.MA_KT
                            where MA_PB = @MA_PB
                            ";
            string query1 = @"
                            select TEN_KN
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
            ArrayList dsKiNang = new ArrayList();
            ArrayList dsKienThuc = new ArrayList();
            var ttPhgBan = new DataTable();
            var dsNhanVien = new DataTable();
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@MA_PB", id);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dsKienThuc.Add(myReader[0]);
                    }
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
                    while (myReader.Read())
                    {
                        dsKiNang.Add(myReader[0]);
                    }
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
