using Swimming.Abstractions.Interfaces;
using Swimming.EntityFramework.DAL.Repositories;
using Swimming.Models;
using System;

namespace Swimming.EntityFramework.BAL.Services
{
    public class Delete
    {
        public void DeleteSwimmer()
        {
            try
            {
                Console.WriteLine("Enter Swimmer id:");
                string id = Console.ReadLine();
                int tryint;

                while (!int.TryParse(id, out tryint))
                {
                    Console.WriteLine("Incorrect id! Try again ");
                    id = Console.ReadLine();
                }
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(swimdb);

                    swimmerManager.Delete(Convert.ToInt32(id));
                    Console.WriteLine("Swimmer is deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteCoach()
        {
            try
            {
                Console.WriteLine("Enter Coach id:");
                string id = Console.ReadLine();
                int tryint;

                while (!int.TryParse(id, out tryint))
                {
                    Console.WriteLine("Incorrect id! Try again ");
                    id = Console.ReadLine();
                }
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ICoachManager<Coach> coachManager = new CoachRepository(swimdb);

                    coachManager.Delete(Convert.ToInt32(id));
                    Console.WriteLine("Coach is deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
