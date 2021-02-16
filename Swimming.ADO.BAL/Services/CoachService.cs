using Swimming.Abstractions.Attributes;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;
using System;

namespace Swimming.ADO.BL.Services
{
    public class CoachService
    {
        private readonly ICoachManager<Coach> _context;

        public CoachService(ICoachManager<Coach> coachManager)
        {
            _context = coachManager;
        }

        public bool IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        public void AddCoach()
        {
            Console.Write("Enter Coach name:");
            string name = Console.ReadLine();

            while (!IsAllAlphabetic(name))
            {
                Console.WriteLine("Incorrect Name! Try again");
                name = Console.ReadLine();
            }

            Console.Write("Enter Coach surname:");
            string surname = Console.ReadLine();

            while (!IsAllAlphabetic(surname))
            {
                Console.WriteLine("Incorrect Surname! Try again");
                surname = Console.ReadLine();
            }

            Console.Write("Enter Coach work experience:");
            string workExperience = Console.ReadLine();
            int tryint;

            while ((!int.TryParse(workExperience, out tryint)) || (!WorkExperienceValidationAttribute.IsValidCoachExperience(Convert.ToInt32(workExperience))))
            {
                Console.WriteLine("Incorrect Work Experience! Try again ");
                workExperience = Console.ReadLine();
            }

            try
            {
                Coach coach = new Coach { FirstName = name, LastName = surname, WorkExperience = Convert.ToInt32(workExperience) };
                _context.Add(coach);
                Console.WriteLine("Coach is added");
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
                _context.Delete(Convert.ToInt32(id));
                Console.WriteLine("Coach is deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SelectCoaches()
        {
            try
            {
                Console.Write("Coaches:\n");
                Console.WriteLine("\tCoach Id \tFirstName \tSecondName\tWorkExperience");
                var coaches = _context.GetList();
                foreach (Coach c in coaches)
                {
                    Console.WriteLine($"{c.Id,15}{c.FirstName,15} {c.LastName,17} {c.WorkExperience,15}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

            while ((!int.TryParse(newWorkExperience, out tryint)) || (!WorkExperienceValidationAttribute.IsValidCoachExperience(Convert.ToInt32(newWorkExperience))))
            {
                Console.WriteLine("Incorrect Work Experience! Try again ");
                newWorkExperience = Console.ReadLine();
            }

            try
            {
                Coach coach = new Coach { FirstName = newName, LastName = newSurname, WorkExperience = Convert.ToInt32(newWorkExperience) };
                _context.Update(Convert.ToInt32(coachId), coach);
                Console.WriteLine("Coach is updated"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
