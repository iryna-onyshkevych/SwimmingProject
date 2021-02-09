using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Swimming.ADO.BL.Services
{
    public class SwimStyleService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void SelectSwimStyles()
        {
            try
            {
                Console.Write("Swimming Styles:\n");

                Console.WriteLine("\tId \tStyle Name ");
                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ISwimStyleManager<SwimStyle> coachManager = new SwimStyleRepository(swimContext);
                    var coaches = coachManager.GetList();

                    foreach (SwimStyle c in coaches)
                    {
                        Console.WriteLine($"{c.Id,10} {c.StyleName,15}");
                    }

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
