using ADO.BL.Interfaces;
using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;
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
        private readonly IConnection _context;
        public SwimmerService(IConnection context)
        {
            _context = context;
        }

        public IEnumerable<SwimmerDTO> SelectSwimmers()
        {
            
                ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(_context);
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

        public void AddSwimmer(SwimmerDTO swimmer)
        {
            Swimmer newSwimmer = new Swimmer { FirstName = swimmer.FirstName, LastName = swimmer.LastName, Age = Convert.ToInt32(swimmer.Age), CoachId = Convert.ToInt32(swimmer.CoachId) };
                
            
                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(_context);
                    swimmerManager.Add(newSwimmer);
            
        }

        public void DeleteSwimmer(int id)
        {
            
                ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(_context);
                swimmerManager.Delete(Convert.ToInt32(id));
            
        }

        public IndexViewModel GetSwimmers(int page = 1)
        {
             
                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(_context);
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

        public void UpdateSwimmer(SwimmerDTO swimmer)
        {
            Swimmer updatedSwimmer = new Swimmer { FirstName = swimmer.FirstName, LastName = swimmer.LastName, Age = Convert.ToInt32(swimmer.Age), CoachId = Convert.ToInt32(swimmer.CoachId) };

                ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(_context);
                swimmerManager.Update(Convert.ToInt32(swimmer.Id), updatedSwimmer);
            
        }
        public SwimmerDTO GetSwimmer(int id)
        {

            ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(_context);
            var swimmer = swimmerManager.GetSwimmer(id);
            SwimmerDTO selectedSwimmer = new SwimmerDTO { Id = swimmer.Id, FirstName = swimmer.FirstName, LastName = swimmer.LastName, Age = Convert.ToInt32(swimmer.Age), CoachId = Convert.ToInt32(swimmer.CoachId) };

            return selectedSwimmer;

        }
    }
}
