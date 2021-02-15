using DTO.Models;
using SwimmingWebApp.ViewModels;
using System.Collections.Generic;

namespace ADO.BL.Interfaces
{
    public interface ISwimmerService
    {
        IEnumerable<SwimmerDTO> SelectSwimmers();
        void AddSwimmer(SwimmerDTO swimmer);
        void UpdateSwimmer(SwimmerDTO coach);

        void DeleteSwimmer(int id);
        IndexViewModel GetSwimmers(int page = 1);
    }
}
