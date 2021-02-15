using DTO.Models;
using SwimmingWebApp.ViewModels;
using System.Collections.Generic;

namespace ADO.BL.Interfaces
{
    public interface ITrainingViewService
    {
        IEnumerable<TrainingsSwimmersSwimStyleDTO> SelectSwimmersTrainings();
        IndexViewModel GetTrainings(int page = 1);
        TrainingsSwimmersSwimStyleDTO GetViewTraining(int id);

    }
}
