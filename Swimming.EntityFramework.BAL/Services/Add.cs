using Swimming.Abstractions.Interfaces;
using Swimming.EntityFramework.DAL.Repositories;
using Swimming.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.EntityFramework.BAL.Services
{
    public class Add
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
        public void AddSwimmwer()
        {

            Console.Write("Enter Swimmer name:");
            string swimmerName = Console.ReadLine();
            while (!IsAllAlphabetic(swimmerName))
            {
                Console.WriteLine("Incorrect Name! Try again");
                swimmerName = Console.ReadLine();

            }
            Console.Write("Enter Swimmer surname:");
            string swimmerSurname = Console.ReadLine();
            while (!IsAllAlphabetic(swimmerSurname))
            {
                Console.WriteLine("Incorrect Surname! Try again");
                swimmerSurname = Console.ReadLine();

            }
            Console.Write("Enter Swimmer age:");


            string age = Console.ReadLine();
            int tryint;

            while (!int.TryParse(age, out tryint))
            {
                Console.WriteLine("Incorrect Age! Try again ");
                age = Console.ReadLine();
            }
            Console.Write("Enter Coach Id:");
            string swimmerCoachId = Console.ReadLine();
            while (!int.TryParse(swimmerCoachId, out tryint))
            {
                Console.WriteLine("Incorrect Id! Try again ");
                swimmerCoachId = Console.ReadLine();
            }
            try
            {
                Swimmer swimmer = new Swimmer { FirstName = swimmerName, LastName = swimmerSurname, Age = Convert.ToInt32(age), CoachId = Convert.ToInt32(swimmerCoachId) };
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(swimdb);

                    swimmerManager.Add(swimmer);
                    Console.WriteLine("Swimmer is added");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

            while (!int.TryParse(workExperience, out tryint))
            {
                Console.WriteLine("Incorrect Work Experience! Try again ");
                workExperience = Console.ReadLine();
            }
            try
            {
                Coach coach = new Coach { FirstName = name, LastName = surname, WorkExperience = Convert.ToInt32(workExperience) };
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ICoachManager<Coach> coachManager = new CoachRepository(swimdb);

                    coachManager.Add(coach);
                    Console.WriteLine("Coach is added");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
