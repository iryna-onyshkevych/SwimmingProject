using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swimming.EntityFramework.DAL.Repositories
{
    public class CoachRepository : ICoachManager<Coach>
    {
        private readonly swimmingContext _context;

        public CoachRepository(swimmingContext context)
        {
            _context = context;
        }

        public Coach Add(Coach coach)
        {
            Coach newCoach = new Coach
            {
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                WorkExperience = coach.WorkExperience,
            };

            _context.Coaches.Add(newCoach);
            _context.SaveChanges();
            return newCoach;
        }

        public void Delete(int id)
        {
            var customer = _context.Coaches.Single(x => x.Id == id);
            _context.Coaches.Remove(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Coach> GetList()
        {
            IEnumerable<Coach> listOfCustomers = _context.Coaches.ToList();
            return listOfCustomers;
        }

        public Coach Update(int id, Coach coach)
        {
            var coachToUpdate = _context.Coaches.Single(x => x.Id == id);
            coachToUpdate.FirstName = coach.FirstName;
            coachToUpdate.LastName = coach.LastName;
            coachToUpdate.WorkExperience = coach.WorkExperience;
            _context.Coaches.Update(coachToUpdate);
            _context.SaveChanges();
            return coachToUpdate;
        }
    }
}
