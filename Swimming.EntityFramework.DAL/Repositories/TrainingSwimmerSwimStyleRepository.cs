using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using System.Collections.Generic;
using System.Linq;

namespace Swimming.EntityFramework.DAL.Repositories
{
    public class TrainingSwimmerSwimStyleRepository : ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle>
    {
        private readonly swimmingContext _context;

        public TrainingSwimmerSwimStyleRepository(swimmingContext context)
        {
            _context = context;
        }

        public IEnumerable<TrainingsSwimmersSwimStyle> GetView()
        {
            IEnumerable<TrainingsSwimmersSwimStyle> listOfTrainings = _context.TrainingsSwimmersSwimStyles.ToList();
            return listOfTrainings;
        }
        public TrainingsSwimmersSwimStyle GetViewTraining(int id)
        {
            string sqlExpression = $"SELECT * FROM TrainingsSwimmersSwimStyles WHERE TrainingId = {id}";
            TrainingsSwimmersSwimStyle training = new TrainingsSwimmersSwimStyle();
            //SqlConnection sql = _context.CreateSqlConnection();
            //sql.Open();
            //SqlCommand command = new SqlCommand(sqlExpression, sql);
            //SqlDataReader reader = command.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        training = new TrainingsSwimmersSwimStyle
            //        {
            //            TrainingId = reader.GetInt32(0),
            //            FirstName = reader.GetString(1),
            //            LastName = reader.GetString(2),
            //            TrainingDate = reader.GetDateTime(3),
            //            Distance = reader.GetInt32(4),
            //            Style = reader.GetString(5)
            //        };
            //    }
            //}
            //sql.Close();
            return training;
        }
    }
}
