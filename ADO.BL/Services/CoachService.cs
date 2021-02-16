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
    public class CoachService: ICoachService
    {


        private ICoachManager<Coach> _coachManager;

        public CoachService(ICoachManager<Coach> salonManager)
        {
            _coachManager = salonManager;
        }
      
        public void AddCoach(CoachDTO coach)
        {
            Coach newCoach = new Coach { FirstName = coach.FirstName, LastName = coach.LastName, WorkExperience = Convert.ToInt32(coach.WorkExperience) };
            _coachManager.Add(newCoach);
        }

        public void DeleteCoach(int id)
        {
            _coachManager.Delete(Convert.ToInt32(id));
        }

        public IEnumerable<CoachDTO> SelectCoaches()
        {
             var coaches = _coachManager.GetList();

             var coachList = coaches.Select(x => new CoachDTO()
             {
                 Id = x.Id,
                 FirstName = x.FirstName,
                 LastName = x.LastName,
                 WorkExperience = x.WorkExperience
             }).ToList();

             return coachList;     
        }

        public void UpdateCoach(CoachDTO coach)
        {
            Coach updatedCoach = new Coach { FirstName = coach.FirstName, LastName = coach.LastName, WorkExperience = Convert.ToInt32(coach.WorkExperience) };
            _coachManager.Update(Convert.ToInt32(coach.Id), updatedCoach);
        }
        
        public CoachDTO GetCoach(int id)
        {
            var coach = _coachManager.GetCoach(id);
            CoachDTO selectedCoach = new CoachDTO { Id = Convert.ToInt32(coach.Id), FirstName = coach.FirstName, LastName = coach.LastName, WorkExperience = Convert.ToInt32(coach.WorkExperience) };
            return selectedCoach;
        }
    }
}