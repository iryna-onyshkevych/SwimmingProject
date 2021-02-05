using Swimming.Abstractions.Interfaces;
using Swimming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swimming.EntityFramework.DAL.Repositories
{
    public class SwimStyleRepository : ISwimStyleManager<SwimStyle>
    {
        private readonly swimmingContext _context;

        public SwimStyleRepository(swimmingContext context)
        {
            _context = context;
        }
        public SwimStyle Add(SwimStyle swimStyle)
        {
            SwimStyle newSwimStyle = new SwimStyle
            {
                StyleName = swimStyle.StyleName,

            };

            _context.SwimStyles.Add(newSwimStyle);
            _context.SaveChanges();
            return newSwimStyle;
        }

        public void Delete(int id)
        {
            var swimstyle = _context.SwimStyles.Single(x => x.Id == id);

            _context.SwimStyles.Remove(swimstyle);
            _context.SaveChanges();
        }

        public IEnumerable<SwimStyle> GetList()
        {
            IEnumerable<SwimStyle> listOfSwimStyles = _context.SwimStyles.ToList();
            return listOfSwimStyles;
        }

        public SwimStyle Update(int id, SwimStyle swimStyle)
        {
            var swimStyleToUpdate = _context.SwimStyles.Single(x => x.Id == id);

            swimStyleToUpdate.StyleName = swimStyle.StyleName;


            _context.SwimStyles.Update(swimStyleToUpdate);
            _context.SaveChanges();

            return swimStyleToUpdate;
        }
    }
}
