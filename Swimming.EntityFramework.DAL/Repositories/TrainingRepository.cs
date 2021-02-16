using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swimming.EntityFramework.DAL.Repositories
{
    public class TrainingRepository : ITrainingManager<Training>
    {
        private readonly swimmingContext _context;

        public TrainingRepository(swimmingContext context)
        {
            _context = context;
        }

        public Training Add(Training training)
        {
            Training newTraining = new Training
            {
                SwimmerId = training.SwimmerId,
                SwimStyleId = training.SwimStyleId,
                TrainingDate = training.TrainingDate,
                Distance = training.Distance

            };
            _context.Trainings.Add(newTraining);
            _context.SaveChanges();
            return newTraining;
        }

        public void Delete(int id)
        {
            var training = _context.Trainings.Single(x => x.Id == id);
            _context.Trainings.Remove(training);
            _context.SaveChanges();
        }

        public IEnumerable<Training> GetList()
        {
            IEnumerable<Training> listOfTrainings = _context.Trainings.ToList();
            return listOfTrainings;
        }

        public Training Update(int id, Training training)
        {
            var trainingToUpdate = _context.Trainings.Single(x => x.Id == id);
            trainingToUpdate.Distance = training.Distance;
            _context.Trainings.Update(trainingToUpdate);
            _context.SaveChanges();
            return trainingToUpdate;
        }
        public Training GetTraining(int id)
        {
            string sqlExpression = $"SELECT * FROM Trainings WHERE Id = {id}";
            Training training = new Training();
            //SqlConnection sql = _context.CreateSqlConnection();
            //sql.Open();
            //SqlCommand command = new SqlCommand(sqlExpression, sql);
            //SqlDataReader reader = command.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        training = new Training
            //        {
            //            Id = reader.GetInt32(0),
            //            SwimmerId = reader.GetInt32(1),
            //            SwimStyleId = reader.GetInt32(2),
            //            TrainingDate = reader.GetDateTime(3),
            //            Distance = reader.GetInt32(4)
            //        };
            //    }
            //}
            //sql.Close();
            return training;
        }
    }
}
