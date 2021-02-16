using DTO.Models;
using System.Collections.Generic;

namespace ADO.BL.Interfaces
{
    public interface ITrainingViewService
    {
        IEnumerable<TrainingsSwimmersSwimStyleDTO> SelectSwimmersTrainings();
        TrainingsSwimmersSwimStyleDTO GetViewTraining(int id);
    }
}
