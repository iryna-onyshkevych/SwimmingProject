using DTO.Models;
using SwimmingWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.BL.Interfaces
{
    public interface ITrainingViewService
    {
        IEnumerable<TrainingsSwimmersSwimStyleDTO> SelectSwimmersTrainings();
        IndexViewModel GetTrainings(int page = 1);
    }
}
