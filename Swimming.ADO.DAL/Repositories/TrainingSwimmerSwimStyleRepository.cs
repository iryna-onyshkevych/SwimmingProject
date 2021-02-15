using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories.Connection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories
{
    public class TrainingSwimmerSwimStyleRepository : ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle>
    {
        private readonly IConnection _context;
        public TrainingSwimmerSwimStyleRepository(IConnection context)
        {
            _context = context;
        }

        public IEnumerable<TrainingsSwimmersSwimStyle> GetView()
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression4 = "SELECT * FROM TrainingsSwimmersSwimStyles";
            SqlCommand command = new SqlCommand(sqlExpression4, sql);
            SqlDataReader reader = command.ExecuteReader();
            List<TrainingsSwimmersSwimStyle> trainings = new List<TrainingsSwimmersSwimStyle>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TrainingsSwimmersSwimStyle training = new TrainingsSwimmersSwimStyle()
                    {

                        TrainingId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        TrainingDate = reader.GetDateTime(3),
                        Distance = reader.GetInt32(4),
                        Style = reader.GetString(5)
                    };

                    trainings.Add(training);
                }

                reader.Close();
            }
            sql.Close();
            IEnumerable<TrainingsSwimmersSwimStyle> listOfTrainings = trainings;
            return listOfTrainings;
        }
        public TrainingsSwimmersSwimStyle GetViewTraining(int id)
        {
            string sqlExpression = $"SELECT * FROM TrainingsSwimmersSwimStyles WHERE TrainingId = {id}";

            TrainingsSwimmersSwimStyle training = new TrainingsSwimmersSwimStyle();

            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();

            SqlCommand command = new SqlCommand(sqlExpression, sql);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    training = new TrainingsSwimmersSwimStyle
                    {
                        TrainingId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        TrainingDate = reader.GetDateTime(3),
                        Distance = reader.GetInt32(4),
                        Style = reader.GetString(5)
                    };
                }
            }

            sql.Close();
            return training;
        }
    }
}
