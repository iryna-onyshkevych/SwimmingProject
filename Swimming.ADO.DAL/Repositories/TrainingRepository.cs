using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories
{
    public class TrainingRepository : ITrainingManager<Training>
    {
        private readonly SqlConnection _context;

        public TrainingRepository(SqlConnection context)
        {
            _context = context;
        }
        public void Delete(int id)
        {

            string sqlExpression3 = ($"DELETE FROM Trainings WHERE Id = {id}");

            SqlCommand command = new SqlCommand(sqlExpression3, _context);
            command.ExecuteNonQuery();


        }
        public Training Add(Training training)
        {

            string sqlExpression1 = ($"INSERT INTO Trainings (SwimmerId,SwimStyleId,TrainingDate,Distance) VALUES ({ training.SwimmerId},  " +
                $"{training.SwimStyleId},'{training.TrainingDate}',{training.Distance})");


            SqlCommand command = new SqlCommand(sqlExpression1, _context);
            command.ExecuteNonQuery();

            return training;
        }

        public IEnumerable<Training> GetList()
        {

            string sqlExpression4 = "SELECT * FROM Trainings";

            SqlCommand command = new SqlCommand(sqlExpression4, _context);
            SqlDataReader reader = command.ExecuteReader();
            List<Training> trainings = new List<Training>();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Training training = new Training()
                    {

                        Id = reader.GetInt32(0),
                        SwimmerId = reader.GetInt32(1),
                        SwimStyleId = reader.GetInt32(2),
                        TrainingDate = reader.GetDateTime(3),
                        Distance = reader.GetInt32(4)

                    };
                    trainings.Add(training);
                }

                reader.Close();



            }
            IEnumerable<Training> listOfTrainings = trainings;
            return listOfTrainings;
        }

        public Training Update(int id, Training training)
        {
            string sqlExpression2 = ($"UPDATE Trainings SET Distance = {training.Distance} WHERE Id={id}");

            SqlCommand command = new SqlCommand(sqlExpression2, _context);
            command.ExecuteNonQuery();

            return training;
        }

    }
}
