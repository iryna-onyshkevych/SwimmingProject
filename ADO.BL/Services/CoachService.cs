using ADO.BL.Interfaces;
using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using SwimmingWebApp.ViewModels;
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
            Coach newCoach = new Coach { FirstName = coach.FirstName, LastName = coach.LastName, WorkExperience = Convert.ToInt32(coach.WorkExperience) };
            
            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ICoachManager<Coach> coachManager = new CoachRepository(swimContext);
                coachManager.Add(newCoach);
            }
        }

        public void DeleteCoach(int id)
        {
            using (SqlConnection swimdb = new SqlConnection(connectionString))
            {
                swimdb.Open();
                ICoachManager<Coach> coachManager = new CoachRepository(swimdb);
                coachManager.Delete(Convert.ToInt32(id));
            }
        }

        public IEnumerable<CoachDTO> SelectCoaches()
        {
            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ICoachManager<Coach> coachManager = new CoachRepository(swimContext);
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
            Coach updatedCoach = new Coach { FirstName = coach.FirstName, LastName = coach.LastName, WorkExperience = Convert.ToInt32(coach.WorkExperience) };
            
            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ICoachManager<Coach> coachManager = new CoachRepository(swimContext);
                coachManager.Update(Convert.ToInt32(coach.Id), updatedCoach);
            }
        }

        public IndexViewModel GetCoaches(int page = 1)
        {
                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ICoachManager<Coach> coachManager = new CoachRepository(swimContext);
                    IEnumerable<Coach> coaches = coachManager.GetList();
                    var count = coaches.Count();
                    int pageSize = 4;
                    var items = coaches.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                    List<CoachDTO> coachViewModel= new List<CoachDTO>();

                    foreach (Coach c in items)
                    {
                        coachViewModel.Add(new CoachDTO
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            WorkExperience = c.WorkExperience
                        });
                    }

                    PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                    IndexViewModel viewModel = new IndexViewModel
                    {
                        PageViewModel = pageViewModel,
                        Coaches = coachViewModel
                    };

                    return viewModel;
                }
        }
    }
}