using DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.BL.Interfaces
{
    public interface ITrainingViewService
    {
        IEnumerable<TrainingsSwimmersSwimStyleDTO> SelectSwimmersTrainings();
    }
}
