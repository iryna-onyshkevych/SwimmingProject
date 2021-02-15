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
        private readonly IConnection _context;
        public TrainingService(IConnection context)
        {
            _context = context;
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

           
                ITrainingManager<Training> trainingManager = new TrainingRepository(_context);
                trainingManager.Add(newTraining);
            
        }

        public IEnumerable<TrainingDTO> SelectTrainings()
        {
           
                ITrainingManager<Training> trainingManager = new TrainingRepository(_context);
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

        public void DeleteTraining(int id)
        {
            
                ITrainingManager<Training> trainingManager = new TrainingRepository(_context);
                trainingManager.Delete(Convert.ToInt32(id));
            
        }

        public void UpdateTraining(TrainingDTO training)
        {
            Training updatedTraining = new Training {  Id = Convert.ToInt32(training.Id), SwimmerId = Convert.ToInt32(training.SwimmerId), SwimStyleId = Convert.ToInt32(training.SwimStyleId), 
             Distance = Convert.ToInt32(training.Distance),  TrainingDate = Convert.ToDateTime(training.TrainingDate)};

            
                ITrainingManager<Training> trainingManager = new TrainingRepository(_context);
                trainingManager.Update(Convert.ToInt32(training.Id), updatedTraining);
            
        }
    }
}
