using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Swimming.ADO.BL.Services
{
    public class TrainingSwimmerSwimStyleService
    {
        private readonly IConnection _context;
        public TrainingSwimmerSwimStyleService(IConnection context)
        {
            _context = context;
        }
        public void SelectTraining()
        {
            try
            {
                Console.WriteLine("TrainingId\tName\t\tSurname\t\tDate\t\t\tDistance\t\tStyle\n");

               
                    ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> trainingManager = new TrainingSwimmerSwimStyleRepository(_context);
                    var trainings = trainingManager.GetView();
                    foreach (TrainingsSwimmersSwimStyle c in trainings)
                    {
                        Console.WriteLine($"{c.TrainingId,10} {c.FirstName,15}{c.LastName,15}{c.TrainingDate,20}{c.Distance,15}{c.Style,15}");
                    }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
