using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO.BL
{
    public class db
    {
        SqlConnection cn = new SqlConnection("Server=.\\SQLExpress;Database=swimming;Trusted_Connection=True;");
        //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SwimmingModel GetSwimmer(int CurrentPage)
        {
            int maxRows = 8;
            SqlCommand com = new SqlCommand("Sp_Swimmers_Paging", cn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Pageindex", CurrentPage);
            com.Parameters.AddWithValue("@Pagesize", maxRows);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            SwimmingModel swimmingModel = new SwimmingModel();
            List<SwimmerDTO> list = new List<SwimmerDTO>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SwimmerDTO
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Age = Convert.ToInt32(dr["Age"]),
                    CoachId = Convert.ToInt32(dr["CoachId"])

                });
            }
            swimmingModel.Swimmers = list;
            swimmingModel.PageCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]) / maxRows;
            swimmingModel.CurrentIndex = CurrentPage;
            return swimmingModel;
        }
    }
}
