using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.ADO.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using ADO.BL.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories.Connection;
using System;

namespace ADO.BL.Services
{
    public class TrainingViewService: ITrainingViewService
    {
        private readonly IConnection _context;

        public TrainingViewService(IConnection context)
        {
            _context = context;
        }

        public IEnumerable<TrainingsSwimmersSwimStyleDTO> SelectSwimmersTrainings()
        {
            ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> tariningManager = new TrainingSwimmerSwimStyleRepository(_context);
            var trainings = tariningManager.GetView();

            var trainingList = trainings.Select(x => new TrainingsSwimmersSwimStyleDTO()
            {

                TrainingId = x.TrainingId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                TrainingDate = x.TrainingDate,
                Distance = x.Distance,
                Style = x.Style
            }).ToList();
            return trainingList;
        }

       
        public TrainingsSwimmersSwimStyleDTO GetViewTraining(int id)
        {
            ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> tariningManager = new TrainingSwimmerSwimStyleRepository(_context);
            var training = tariningManager.GetViewTraining(id);
            TrainingsSwimmersSwimStyleDTO selectedTraining = new TrainingsSwimmersSwimStyleDTO
            {
                TrainingId = Convert.ToInt32(training.TrainingId),
                FirstName = training.FirstName,
                LastName = training.LastName,
                Distance = Convert.ToInt32(training.Distance),
                TrainingDate = Convert.ToDateTime(training.TrainingDate),
                Style = training.Style
            };

            return selectedTraining;
        }
    }
}
