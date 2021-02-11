using DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.BL.Interfaces
{
    public interface ISwimmerService
    {
        IEnumerable<SwimmerDTO> SelectSwimmers();
        void AddSwimmer(SwimmerDTO swimmer);
    
        void DeleteSwimmer(int id);
    }
}
