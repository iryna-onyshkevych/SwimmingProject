using System;
using System.Collections.Generic;
using System.Linq;
using ADO.BL.Interfaces;
using DTO.Models;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;

namespace ADO.BL.Services
{
    public class SwimStyleService: ISwimStyleService
    {
        private readonly ISwimStyleManager<SwimStyle> _swimStyleManager;

        public SwimStyleService(ISwimStyleManager<SwimStyle> swimStyleManager)
        {
            _swimStyleManager = swimStyleManager;
        }

        public IEnumerable<SwimStyleDTO> SelectSwimStyles()
        {
            var swimStyles = _swimStyleManager.GetList();
            var swimStylesList = swimStyles.Select(x => new SwimStyleDTO()
            {
                Id = x.Id,
                StyleName = x.StyleName

            }).ToList();
            return swimStylesList;
        }

        public void AddSwimStyle(SwimStyleDTO swimStyle)
        {
            SwimStyle newSwimStyle = new SwimStyle { Id = Convert.ToInt32(swimStyle.Id), StyleName = swimStyle.StyleName };
            _swimStyleManager.Add(newSwimStyle);
        }

        public void DeleteSwimStyle(int id)
        {
            _swimStyleManager.Delete(Convert.ToInt32(id));
        }

        public void UpdateSwimStyle(SwimStyleDTO swimStyle)
        {
            SwimStyle updatedSwimStyle = new SwimStyle { StyleName = swimStyle.StyleName };
            _swimStyleManager.Update(Convert.ToInt32(swimStyle.Id), updatedSwimStyle);
        }

        public SwimStyleDTO GetSwimStyle(int id)
        {
            var swimStyle = _swimStyleManager.GetSwimStyle(id);
            SwimStyleDTO selectedSwimStyle = new SwimStyleDTO { Id = Convert.ToInt32(swimStyle.Id), StyleName = swimStyle.StyleName };
            return selectedSwimStyle;
        }
    }
}
