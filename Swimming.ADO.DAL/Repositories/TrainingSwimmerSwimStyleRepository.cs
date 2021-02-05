using Swimming.Abstractions.Interfaces;
using Swimming.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Swimming.ADO.DAL.Repositories
{
    public class TrainingSwimmerSwimStyleRepository : ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle>
    {
        private readonly SqlConnection _context;

        public TrainingSwimmerSwimStyleRepository(SqlConnection context)
        {
            _context = context;
        }

        public IEnumerable<TrainingsSwimmersSwimStyle> GetList()
        {

            string sqlExpression4 = "SELECT * FROM TrainingsSwimmersSwimStyles";

            SqlCommand command = new SqlCommand(sqlExpression4, _context);
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
            IEnumerable<TrainingsSwimmersSwimStyle> listOfTrainings = trainings;
            return listOfTrainings;
        }
    }
}
