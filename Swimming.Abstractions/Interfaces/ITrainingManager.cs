using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.Abstractions.Interfaces
{
    public interface ITrainingManager<Training>
    {
        Training Add(Training entity);
        void Delete(int id);
        IEnumerable<Training> GetList();
        Training Update(int id, Training entity);
    }
}
