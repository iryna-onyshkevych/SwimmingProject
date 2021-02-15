using System;
using Swimming.Abstractions.Attributes;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using System.Configuration;
using System.Data.SqlClient;
using Swimming.ADO.DAL.Repositories.Connection;

namespace Swimming.ADO.BL.Services
{
    public class TrainingService
    {
        private readonly IConnection _context;
        public TrainingService(IConnection context)
        {
            _context = context;
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

        public void AddTraining()
        {
            int tryint;
            Console.Write("Enter Swimmer Id:");
            string swimmertrainingId = Console.ReadLine();

            while (!int.TryParse(swimmertrainingId, out tryint))
            {
                Console.WriteLine("Incorrect Id! Try again ");
                swimmertrainingId = Console.ReadLine();
            }

            Console.Write("Enter Swim Style Id:");
            string swimStyleId = Console.ReadLine();

            while (!int.TryParse(swimStyleId, out tryint))
            {
                Console.WriteLine("Incorrect Id! Try again ");
                swimStyleId = Console.ReadLine();
            }

            string trainingDate = Console.ReadLine();
            DateTime temp;

            while (!DateTime.TryParse(trainingDate, out temp))
            {
                Console.WriteLine("Incorrect Date! Try again ");
                trainingDate = Console.ReadLine();
            }

            string distance = Console.ReadLine();

            while (!int.TryParse(distance, out tryint))
            {
                Console.WriteLine("Incorrect Distance! Try again ");
                distance = Console.ReadLine();
            }

            try
            {
                Training training = new Training
                {
                    SwimmerId = Convert.ToInt32(swimmertrainingId),
                    SwimStyleId = Convert.ToInt32(swimStyleId),
                    TrainingDate = Convert.ToDateTime(trainingDate),
                    Distance = Convert.ToInt32(distance)
                };

                
                    ITrainingManager<Training> trainingManager = new TrainingRepository(_context);
                    trainingManager.Add(training);
                    Console.WriteLine("Training is added");
                
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

            while ((!int.TryParse(newDistance, out tryint)) || (!DistanceValidationAttribute.IsValidDistance(Convert.ToInt32(newDistance))))
            {
                Console.WriteLine("Incorrect distance! Try again ");
                newDistance = Console.ReadLine();
            }

            try
            {
                Training training = new Training { Distance = Convert.ToInt32(newDistance) };

               
                    ITrainingManager<Training> trainingManager = new TrainingRepository(_context);
                    trainingManager.Update(Convert.ToInt32(trainingId), training);
                    Console.WriteLine("Distance is updated");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
