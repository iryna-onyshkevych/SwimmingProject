using ADO.BL.Interfaces;
using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADO.BL.Services
{
    public class SwimmerService : ISwimmerService
    {
        private readonly ISwimmerManager<Swimmer> _swimmerManager;

        public SwimmerService(ISwimmerManager<Swimmer> swimmerManager)
        {
            _swimmerManager = swimmerManager;
        }

        public IEnumerable<SwimmerDTO> SelectSwimmers()
        {
            var swimmers = _swimmerManager.GetList();
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
            _swimmerManager.Add(newSwimmer);
        }

        public void DeleteSwimmer(int id)
        {
            _swimmerManager.Delete(Convert.ToInt32(id));
        }

        
        public void UpdateSwimmer(SwimmerDTO swimmer)
        {
            Swimmer updatedSwimmer = new Swimmer { FirstName = swimmer.FirstName, LastName = swimmer.LastName, Age = Convert.ToInt32(swimmer.Age), CoachId = Convert.ToInt32(swimmer.CoachId) };
            _swimmerManager.Update(Convert.ToInt32(swimmer.Id), updatedSwimmer);
        }

        public SwimmerDTO GetSwimmer(int id)
        {
            var swimmer = _swimmerManager.GetSwimmer(id);
            SwimmerDTO selectedSwimmer = new SwimmerDTO { Id = swimmer.Id, FirstName = swimmer.FirstName, LastName = swimmer.LastName, Age = Convert.ToInt32(swimmer.Age), CoachId = Convert.ToInt32(swimmer.CoachId) };
            return selectedSwimmer;
        }
    }
}
