using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;
using System;

namespace Swimming.ADO.BL.Services
{
    public class TrainingSwimmerSwimStyleService
    {
        private readonly ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> _swimmersTrainingManager;

        public TrainingSwimmerSwimStyleService(ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> swimmersTrainingManager)
        {
            _swimmersTrainingManager = swimmersTrainingManager;
        }

        public void SelectTraining()
        {
            try
            {
                Console.WriteLine("TrainingId\tName\t\tSurname\t\tDate\t\t\tDistance\t\tStyle\n");
                var trainings = _swimmersTrainingManager.GetView();
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
