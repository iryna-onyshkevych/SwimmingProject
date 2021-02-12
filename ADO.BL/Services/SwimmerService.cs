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
                
            }
        }
        public IndexViewModel GetSwimmers(int page = 1)
        {
             using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();

                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(swimContext);

                    IEnumerable<Swimmer> swimmers = swimmerManager.GetList();

                    var count = swimmers.Count();

                    int pageSize = 4;

                    var items = swimmers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                    List<SwimmerDTO> cswimmersViewModel = new List<SwimmerDTO>();
                    foreach (Swimmer c in items)
                    {
                    cswimmersViewModel.Add(new SwimmerDTO
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Age = c.Age,
                            CoachId = c.CoachId,
                        });
                    }

                    PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                    IndexViewModel viewModel = new IndexViewModel
                    {
                        PageViewModel = pageViewModel,
                        Swimmers = cswimmersViewModel
                    };

                    return viewModel;
                
            }
           
        }
    }
}
