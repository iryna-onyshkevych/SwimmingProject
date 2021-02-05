using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.Abstractions.Interfaces
{
    public interface ISwimmerManager<Swimmer>
    {
        Swimmer Add(Swimmer entity);
        void Delete(int id);
        IEnumerable<Swimmer> GetList();
        Swimmer Update(int id, Swimmer entity);
        IEnumerable<Swimmer> GetListByAge(int mimimalAge);

    }
}
