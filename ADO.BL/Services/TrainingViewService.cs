using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.ADO.DAL.Repositories;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using ADO.BL.Interfaces;
using SwimmingWebApp.ViewModels;
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
                    Style  = x.Style
                }).ToList();
                return trainingList;
            
        }

        public IndexViewModel GetTrainings(int page = 1)
        {
                
                    ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> tariningManager = new TrainingSwimmerSwimStyleRepository(_context);
                    IEnumerable<TrainingsSwimmersSwimStyle> trainings = tariningManager.GetView();
                    var count = trainings.Count();
                    int pageSize = 4;
                    var items = trainings.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                    List<TrainingsSwimmersSwimStyleDTO> trainingViewModel = new List<TrainingsSwimmersSwimStyleDTO>();

                    foreach (TrainingsSwimmersSwimStyle c in items)
                    {
                        trainingViewModel.Add(new TrainingsSwimmersSwimStyleDTO
                        {
                            TrainingId = c.TrainingId,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                             TrainingDate = c.TrainingDate,
                             Style = c.Style,
                             Distance = c.Distance
                        });
                    }

                    PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                    IndexViewModel viewModel = new IndexViewModel
                    {
                        PageViewModel = pageViewModel,
                        Trainings = trainingViewModel
                    };

                    return viewModel;

                
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
