using DTO.Models;
using System.Collections.Generic;

namespace ADO.BL.Interfaces
{
    public interface ICoachService
    {
        void AddCoach(CoachDTO coach);
        void DeleteCoach(int id);
        IEnumerable<CoachDTO> SelectCoaches();
        void UpdateCoach(CoachDTO coach);
        CoachDTO GetCoach(int id);
    }
}
