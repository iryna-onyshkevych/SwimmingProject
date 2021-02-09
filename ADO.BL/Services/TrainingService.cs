using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.ADO.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ADO.BL.Services
{
    public class TrainingService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void AddTraining(TrainingDTO training)
        {
            Swimming.Abstractions.Models.Training newTraining = new Swimming.Abstractions.Models.Training
            {
                SwimmerId =
                Convert.ToInt32(training.SwimmerId),
                SwimStyleId = Convert.ToInt32(training.SwimStyleId),
                TrainingDate = Convert.ToDateTime(training.TrainingDate),
                Distance = Convert.ToInt32(training.Distance)
            };
            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ITrainingManager<Swimming.Abstractions.Models.Training> trainingManager = new TrainingRepository(swimContext);

                trainingManager.Add(newTraining);

            }

        }
        public IEnumerable<TrainingDTO> SelectTrainings()
        {


            using (SqlConnection swimContext = new SqlConnection(connectionString))
            {
                swimContext.Open();
                ITrainingManager<Swimming.Abstractions.Models.Training> trainingManager = new TrainingRepository(swimContext);
                var trainings = trainingManager.GetList();
                var trainingList = trainings.Select(x => new TrainingDTO()
                {
                    SwimmerId = x.SwimmerId,
                    SwimStyleId = x.SwimStyleId,
                    TrainingDate = x.TrainingDate,
                    Distance = x.Distance

                }).ToList();
                return trainingList;

            }

        }
    }
}
