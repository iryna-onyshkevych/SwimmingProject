﻿using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.ADO.DAL.Repositories;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using ADO.BL.Interfaces;
using SwimmingWebApp.ViewModels;
using Swimming.Abstractions.Models;

namespace ADO.BL.Services
{
    public class TrainingViewService: ITrainingViewService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public IEnumerable<TrainingsSwimmersSwimStyleDTO> SelectSwimmersTrainings()
        {
            using (SqlConnection swimContext = new SqlConnection(connectionString)) { 

                swimContext.Open();
                ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> tariningManager = new TrainingSwimmerSwimStyleRepository(swimContext);
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
        }

        public IndexViewModel GetTrainings(int page = 1)
        {
                using (SqlConnection swimContext = new SqlConnection(connectionString))
                {
                    swimContext.Open();
                    ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> tariningManager = new TrainingSwimmerSwimStyleRepository(swimContext);
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
        }
    }
}
