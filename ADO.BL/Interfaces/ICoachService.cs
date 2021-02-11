using DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.BL.Interfaces
{
    public interface ICoachService
    {
        void AddCoach(CoachDTO coach);
        void DeleteCoach(int id);
        IEnumerable<CoachDTO> SelectCoaches();
        void UpdateCoach(CoachDTO coach);
    }
}
