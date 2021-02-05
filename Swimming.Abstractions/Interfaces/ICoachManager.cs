using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.Abstractions.Interfaces
{
    public interface ICoachManager<Coach>
    {
        Coach Add(Coach entity);
        void Delete(int id);
        IEnumerable<Coach> GetList();
        Coach Update(int id, Coach entity);
    }
}
