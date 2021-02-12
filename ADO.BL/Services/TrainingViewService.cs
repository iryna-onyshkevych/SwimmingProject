using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.ADO.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using ADO.BL.Interfaces;

namespace ADO.BL.Services
{
    public class TrainingViewService: ITrainingViewService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public IEnumerable<TrainingsSwimmersSwimStyleDTO> SelectSwimmersTrainings()
        {
            using (SqlConnection swimContext = new SqlConnection(connectionString)) { 
            
                swimContext.Open();
                ITrainingsSwimmersSwimStyleManager<Swimming.Abstractions.Models.TrainingsSwimmersSwimStyle> tariningManager = new TrainingSwimmerSwimStyleRepository(swimContext);
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
    }
}
