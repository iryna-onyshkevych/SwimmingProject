using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories.Connection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories
{
    public class TrainingRepository : ITrainingManager<Training>
    {
        private readonly IConnection _context;

        public TrainingRepository(IConnection context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression3 = ($"DELETE FROM Trainings WHERE Id = {id}");
            SqlCommand command = new SqlCommand(sqlExpression3, sql);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public Training Add(Training training)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression1 = ($"INSERT INTO Trainings (SwimmerId,SwimStyleId,TrainingDate,Distance) VALUES ({ training.SwimmerId},  " +
                $"{training.SwimStyleId},'{training.TrainingDate}',{training.Distance})");
            SqlCommand command = new SqlCommand(sqlExpression1, sql);
            command.ExecuteNonQuery();
            sql.Close();
            return training;
        }

        public IEnumerable<Training> GetList()
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression4 = "SELECT * FROM Trainings";
            SqlCommand command = new SqlCommand(sqlExpression4, sql);
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
            sql.Close();
            IEnumerable<Training> listOfTrainings = trainings;
            return listOfTrainings;
        }

        public Training Update(int id, Training training)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression2 = ($"UPDATE Trainings SET SwimmerId = {training.SwimmerId}," +
                $" SwimStyleId = {training.SwimStyleId}, TrainingDate = '{training.TrainingDate}', Distance = {training.Distance}  WHERE Id={id}");
            SqlCommand command = new SqlCommand(sqlExpression2, sql);
            command.ExecuteNonQuery();
            sql.Close();
            return training;
        }

        public Training GetTraining(int id)
        {
            string sqlExpression = $"SELECT * FROM Trainings WHERE Id = {id}";
            Training training = new Training();
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            SqlCommand command = new SqlCommand(sqlExpression, sql);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    training = new Training
                    {
                        Id = reader.GetInt32(0),
                        SwimmerId = reader.GetInt32(1),
                        SwimStyleId = reader.GetInt32(2),
                        TrainingDate = reader.GetDateTime(3),
                        Distance = reader.GetInt32(4)
                    };
                }
            }
            sql.Close();
            return training;
        }
    }
}
