using DTO.Models;
using SwimmingWebApp.ViewModels;
using System.Collections.Generic;

namespace ADO.BL.Interfaces
{
    public interface ICoachService
    {
        void AddCoach(CoachDTO coach);
        void DeleteCoach(int id);
        IEnumerable<CoachDTO> SelectCoaches();
        void UpdateCoach(CoachDTO coach);
        IndexViewModel GetCoaches(int page = 1);
        CoachDTO GetCoach(int id);

    }
}
