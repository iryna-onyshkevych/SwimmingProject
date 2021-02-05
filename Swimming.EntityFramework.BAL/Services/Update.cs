using Swimming.Abstractions.Attributes;
using Swimming.Abstractions.Interfaces;
using Swimming.EntityFramework.DAL.Repositories;
using Swimming.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.EntityFramework.BAL.Services
{
    public class Update
    {
        public bool IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }
        public void UpdateCoach()
        {
            Console.WriteLine("Enter Coach id:");
            string coachId = Console.ReadLine();
            int tryint;

            while (!int.TryParse(coachId, out tryint))
            {
                Console.WriteLine("Incorrect id! Try again ");
                coachId = Console.ReadLine();
            }
            Console.Write("Enter Coach name:");
            string newName = Console.ReadLine();
            while (!IsAllAlphabetic(newName))
            {
                Console.WriteLine("Incorrect Name! Try again");
                newName = Console.ReadLine();

            }
            Console.Write("Enter Coach surname:");
            string newSurname = Console.ReadLine();
            while (!IsAllAlphabetic(newSurname))
            {
                Console.WriteLine("Incorrect Surname! Try again");
                newSurname = Console.ReadLine();

            }
            Console.Write("Enter Coach work experience:");
            string newWorkExperience = Console.ReadLine();
            while (!int.TryParse(newWorkExperience, out tryint))
            {
                Console.WriteLine("Incorrect work experience! Try again ");
                newWorkExperience = Console.ReadLine();
            }
            try
            {
                Coach coach = new Coach { FirstName = newName, LastName = newSurname, WorkExperience = Convert.ToInt32(newWorkExperience) };
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ICoachManager<Coach> coachManager = new CoachRepository(swimdb);

                    coachManager.Update(Convert.ToInt32(coachId), coach);
                    Console.WriteLine("Coach is updated");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateDistance()
        {
            Console.WriteLine("Enter Training id:");
            string trainingId = Console.ReadLine();
            int tryint;

            while (!int.TryParse(trainingId, out tryint))
            {
                Console.WriteLine("Incorrect id! Try again ");
                trainingId = Console.ReadLine();
            }
            Console.Write("Enter new distance:");
            string newDistance = Console.ReadLine();
            while (!int.TryParse(newDistance, out tryint))
            {
                Console.WriteLine("Incorrect distance! Try again ");
                newDistance = Console.ReadLine();
            }
            while (!DistanceValidationAttribute.IsValidDistance(Convert.ToInt32(newDistance)))
            {
                Console.WriteLine("Incorrect distance! Try again ");
                newDistance = Console.ReadLine();
            }
            try
            {
                Training training = new Training { Distance = Convert.ToInt32(newDistance) };
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ITrainingManager<Training> trainingManager = new TrainingRepository(swimdb);

                    trainingManager.Update(Convert.ToInt32(trainingId), training);
                    Console.WriteLine("Distance is updated");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
