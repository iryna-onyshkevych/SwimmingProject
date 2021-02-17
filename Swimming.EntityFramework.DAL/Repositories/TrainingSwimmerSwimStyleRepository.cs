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
            return training;
        }
    }
}
