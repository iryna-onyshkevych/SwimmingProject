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
    public class CoachService: ICoachService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void AddCoach(CoachDTO coach)
        {
            Swimming.Abstractions.Models.Coach newCoach = new Swimming.Abstractions.Models.Coach { FirstName = coach.FirstName, LastName = coach.LastName, WorkExperience = Convert.ToInt32(coach.WorkExperience) };
            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ICoachManager<Swimming.Abstractions.Models.Coach> coachManager = new CoachRepository(swimContext);
                coachManager.Add(newCoach);

            }

        }
        public void DeleteCoach(int id)
        {
            using (SqlConnection swimdb = new SqlConnection(connectionString))
            {
                swimdb.Open();
                ICoachManager<Swimming.Abstractions.Models.Coach> coachManager = new CoachRepository(swimdb);
                coachManager.Delete(Convert.ToInt32(id));

            }
        }
        public IEnumerable<CoachDTO> SelectCoaches()
        {
            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ICoachManager<Swimming.Abstractions.Models.Coach> coachManager = new CoachRepository(swimContext);
                var coaches = coachManager.GetList();
                var coachList = coaches.Select(x => new CoachDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    WorkExperience = x.WorkExperience
                }).ToList();
                

                    return coachList;
                
            }

        }
       
        public void UpdateCoach(CoachDTO coach)
        {
            Swimming.Abstractions.Models.Coach updatedCoach = new Swimming.Abstractions.Models.Coach { FirstName = coach.FirstName, LastName = coach.LastName, WorkExperience = Convert.ToInt32(coach.WorkExperience) };
            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ICoachManager<Swimming.Abstractions.Models.Coach> coachManager = new CoachRepository(swimContext);

                coachManager.Update(Convert.ToInt32(coach.Id), updatedCoach);
            }
        }
    }
}