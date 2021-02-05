using Swimming.Abstractions.Interfaces;
using Swimming.ADO.DAL.Repositories;
using Swimming.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Swimming.ADO.BAL.Services
{
    public class Select
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void SelectSwimmers()
        {
            try
            {
                Console.Write("Swimmers:\n");

                Console.WriteLine("\t\tId \tFirstName \tSecondName\t\tAge");
                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(swimContext);
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

                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ICoachManager<Coach> coachManager = new CoachRepository(swimContext);
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
                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ISwimStyleManager<SwimStyle> coachManager = new SwimStyleRepository(swimContext);
                    var coaches = coachManager.GetList();

                    foreach (SwimStyle c in coaches)
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

                Console.WriteLine("TrainingId\tName\t\tSurname\t\tDate\t\t\\tDistance\t\tStyle\n");
                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> trainingManager = new TrainingSwimmerSwimStyleRepository(swimContext);
                    var trainings = trainingManager.GetView();

                    foreach (TrainingsSwimmersSwimStyle c in trainings)
                    {
                        Console.WriteLine($"{c.TrainingId,10} {c.FirstName,15}{c.LastName,15}{c.TrainingDate,20}{c.Distance,15}{c.Style,15}");
                    }

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
                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ISwimmerManager<Swimmer> swimmerManager = new SwimmerRepository(swimContext);
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
