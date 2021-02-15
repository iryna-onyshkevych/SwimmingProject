using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Swimming.ADO.BL.Services
{
    public class TrainingSwimmerSwimStyleService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void SelectTraining()
        {
            try
            {
                Console.WriteLine("TrainingId\tName\t\tSurname\t\tDate\t\t\tDistance\t\tStyle\n");

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
    }
}
