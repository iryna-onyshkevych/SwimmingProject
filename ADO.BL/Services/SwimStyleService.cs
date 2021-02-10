using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.ADO.DAL.Repositories;
namespace ADO.BL.Services
{
    public class SwimStyleService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public IEnumerable<SwimStyleDTO> SelectSwimStyles()
        {


            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ISwimStyleManager<Swimming.Abstractions.Models.SwimStyle> swimStyleManager = new SwimStyleRepository(swimContext);
                var swimStyles = swimStyleManager.GetList();
                var swimStylesList = swimStyles.Select(x => new SwimStyleDTO()
                {
                  Id = x.Id,
                  StyleName = x.StyleName

                }).ToList();
                return swimStylesList;

            }

        }
    }
}
