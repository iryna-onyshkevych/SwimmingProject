using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using ADO.BL.Interfaces;
using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;

namespace ADO.BL.Services
{
    public class SwimStyleService: ISwimStyleService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public IEnumerable<SwimStyleDTO> SelectSwimStyles()
        {
            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ISwimStyleManager<SwimStyle> swimStyleManager = new SwimStyleRepository(swimContext);
                var swimStyles = swimStyleManager.GetList();

                var swimStylesList = swimStyles.Select(x => new SwimStyleDTO()
                {
                  Id = x.Id,
                  StyleName = x.StyleName

                }).ToList();
                return swimStylesList;

            }
        }

        public void AddSwimStyle(SwimStyleDTO swimStyle)
        {
            SwimStyle newSwimStyle = new SwimStyle { Id = Convert.ToInt32(swimStyle.Id), StyleName = swimStyle.StyleName };

            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ISwimStyleManager<SwimStyle> swimStyleManager = new SwimStyleRepository(swimContext);
                swimStyleManager.Add(newSwimStyle);
            }
        }

        public void DeleteSwimStyle(int id)
        {
            using (SqlConnection swimdb = new SqlConnection(connectionString))
            {
                swimdb.Open();
                ISwimStyleManager<SwimStyle> swimStyleManager = new SwimStyleRepository(swimdb);
                swimStyleManager.Delete(Convert.ToInt32(id));
            }
        }

        public void UpdateSwimStyle(SwimStyleDTO swimStyle)
        {
            SwimStyle updatedSwimStyle = new SwimStyle { StyleName = swimStyle.StyleName };

            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ISwimStyleManager<SwimStyle> swimStyleManager = new SwimStyleRepository(swimContext);
                swimStyleManager.Update(Convert.ToInt32(swimStyle.Id), updatedSwimStyle);
            }
        }
    }
}
