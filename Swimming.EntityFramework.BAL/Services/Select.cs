using Swimming.Abstractions.Interfaces;
using Swimming.EntityFramework.DAL.Repositories;
using Swimming.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.EntityFramework.BAL.Services
{
    public class Select
    {
        public void SelectSwimmers()
        {
            try
            {
                Console.Write("Swimmers:\n");

                Console.WriteLine("\t\tId \tFirstName \tSecondName\t\tAge");
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(swimdb);

                    var swimmers = swimmerManager.GetList();

                    foreach (Swimmer c in swimmers)
                    {
                        Console.WriteLine($"{c.Id,15}{c.FirstName,15} {c.LastName,17} {c.Age,15}");
                    }

                }

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
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ICoachManager<Coach> coachManager = new CoachRepository(swimdb);

                    var coaches = coachManager.GetList();

                    foreach (Coach c in coaches)
                    {
                        Console.WriteLine($"{c.Id,15}{c.FirstName,15} {c.LastName,17} {c.WorkExperience,15}");
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SelectSwimStyles()
        {
            try
            {
                Console.Write("Swimming Styles:\n");

                Console.WriteLine("\tId \tStyle Name ");
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ISwimStyleManager<SwimStyle> swimStyleManager = new SwimStyleRepository(swimdb);

                    var swimStyles = swimStyleManager.GetList();

                    foreach (SwimStyle c in swimStyles)
                    {
                        Console.WriteLine($"{c.Id,10} {c.StyleName,15}");
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SelectTraining()
        {
            try
            {

                using (swimmingContext db = new swimmingContext())
                {
                    ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> swimStyleManager = new TrainingSwimmerSwimStyleRepository(db);

                    var traininings = swimStyleManager.GetView();
                    Console.WriteLine("TrainingId\tName\t\tSurname\t\tDate\t\t\tDistance\t\tStyle");
                    foreach (var t in traininings)
                        Console.WriteLine("{0,10} {1,15} {2,15} {3,20} {4,15} {5,15}", t.TrainingId, t.FirstName, t.LastName, t.TrainingDate, t.Style, t.Distance);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public void SelectSwimmersByAge()
        {
            Console.WriteLine("Enter age\n");
            string age = Console.ReadLine();
            int tryint;

            while (!int.TryParse(age, out tryint))
            {
                Console.WriteLine("Incorrect age! Try again ");
                age = Console.ReadLine();
            }
            try
            {
                Console.Write("Swimmers:\n");

                Console.WriteLine("\t\tId \tFirstName \tSecondName\t\tAge");
                using (swimmingContext swimdb = new swimmingContext())
                {
                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(swimdb);

                    var swimmers = swimmerManager.GetListByAge(Convert.ToInt32(age));

                    foreach (Swimmer c in swimmers)
                    {
                        Console.WriteLine($"{c.Id,15}{c.FirstName,15} {c.LastName,17} {c.Age,15}");
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
