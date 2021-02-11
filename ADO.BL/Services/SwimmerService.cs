using ADO.BL.Interfaces;
using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.ADO.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ADO.BL.Services
{
    public class SwimmerService : ISwimmerService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<SwimmerDTO> SelectSwimmers()
        {

            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ISwimmerManager<Swimming.Abstractions.Models.Swimmer> swimmerManager = new SwimmerRepository(swimContext);
                var swimmers = swimmerManager.GetList();

               
                var swimmerList = swimmers.Select(x => new SwimmerDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    CoachId = x.CoachId
                }).ToList();
                return swimmerList;
            }
            
        }
        public void AddSwimmer(SwimmerDTO swimmer)
        {
            Swimming.Abstractions.Models.Swimmer newSwimmer = new Swimming.Abstractions.Models.Swimmer { FirstName = swimmer.FirstName, LastName = swimmer.LastName, Age = Convert.ToInt32(swimmer.Age), CoachId = Convert.ToInt32(swimmer.CoachId) };
                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ISwimmerManager<Swimming.Abstractions.Models.Swimmer> swimmerManager = new SwimmerRepository(swimContext);

                    swimmerManager.Add(newSwimmer);

                }

        }
        public void DeleteSwimmer(int id)
        {

            using (SqlConnection swimdb = new SqlConnection(connectionString))
            {
                swimdb.Open();
               
                ISwimmerManager<Swimming.Abstractions.Models.Swimmer> swimmerManager = new SwimmerRepository(swimdb);
                swimmerManager.Delete(Convert.ToInt32(id));
                ICoachManager<Swimming.Abstractions.Models.Coach> coachManager = new CoachRepository(swimdb);
                coachManager.Delete(Convert.ToInt32(id));
            }
        }
    }
}
