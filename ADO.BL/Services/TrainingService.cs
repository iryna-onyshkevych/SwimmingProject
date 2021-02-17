using ADO.BL.Interfaces;
using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ADO.BL.Services
{
    public class TrainingService: ITrainingService
    {
        private readonly ITrainingManager<Training> _trainingManager;

        public TrainingService(ITrainingManager<Training> trainingManager)
        {
            _trainingManager = trainingManager;
        }

        public void AddTraining(TrainingDTO training)
        {
            Training newTraining = new Training
            {
                SwimmerId = Convert.ToInt32(training.SwimmerId),
                SwimStyleId = Convert.ToInt32(training.SwimStyleId),
                TrainingDate = Convert.ToDateTime(training.TrainingDate),
                Distance = Convert.ToInt32(training.Distance)
            };

            _trainingManager.Add(newTraining);
        }

        public IEnumerable<TrainingDTO> SelectTrainings()
        {
            var trainings = _trainingManager.GetList();

            var trainingList = trainings.Select(x => new TrainingDTO()
            {
                SwimmerId = x.SwimmerId,
                SwimStyleId = x.SwimStyleId,
                TrainingDate = x.TrainingDate,
                Distance = x.Distance

            }).ToList();
            return trainingList;
        }

        public void DeleteTraining(int id)
        {
            _trainingManager.Delete(Convert.ToInt32(id));
        }

        public void UpdateTraining(TrainingDTO training)
        {
            Training updatedTraining = new Training {  Id = Convert.ToInt32(training.Id), SwimmerId = Convert.ToInt32(training.SwimmerId), SwimStyleId = Convert.ToInt32(training.SwimStyleId), 
            Distance = Convert.ToInt32(training.Distance),  TrainingDate = Convert.ToDateTime(training.TrainingDate)};
            _trainingManager.Update(Convert.ToInt32(training.Id), updatedTraining);
        }

        public TrainingDTO GetTraining(int id)
        {
            var training = _trainingManager.GetTraining(id);
            TrainingDTO selectedTraining = new TrainingDTO
            {
                Id = Convert.ToInt32(training.Id),
                SwimmerId = Convert.ToInt32(training.SwimmerId),
                SwimStyleId = Convert.ToInt32(training.SwimStyleId),
                Distance = Convert.ToInt32(training.Distance),
                TrainingDate = Convert.ToDateTime(training.TrainingDate)
            };

            return selectedTraining;
        }
    }
}
