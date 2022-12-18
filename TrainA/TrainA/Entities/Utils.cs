using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TrainA.Entities
{
    public sealed class Utils
    {
        public static bool myValueExist(string myTable, string myField, string myValue, string dataSrc)
        {
            int result = 0;
            string query = @"select COUNT(*) from " + myTable + " where " + myField + "=@myValue";
            using (SqlConnection myCon = new SqlConnection(dataSrc))
            {
                myCon.Open();
                using (SqlCommand cmd = new SqlCommand(query, myCon))
                {
                    cmd.Parameters.AddWithValue("@myValue", myValue);
                    result = (int)cmd.ExecuteScalar();
                    Console.WriteLine("Res: "+result);
                    myCon.Close();
                    if (result == 0) return false;
                    else return true;
                }
            }


        }
    }
}
