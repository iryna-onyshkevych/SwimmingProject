using DTO.Models;
using System.Collections.Generic;

namespace ADO.BL.Interfaces
{
    public interface ISwimStyleService
    {
        IEnumerable<SwimStyleDTO> SelectSwimStyles();
        void AddSwimStyle(SwimStyleDTO swimStyle);
        void DeleteSwimStyle (int id);
        void UpdateSwimStyle(SwimStyleDTO swimStyle);
        SwimStyleDTO GetSwimStyle(int id);

    }
}
