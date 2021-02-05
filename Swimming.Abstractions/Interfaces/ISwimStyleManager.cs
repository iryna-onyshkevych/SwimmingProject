using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.Abstractions.Interfaces
{
    public interface ISwimStyleManager<SwimStyle>
    {
        SwimStyle Add(SwimStyle entity);
        void Delete(int id);
        IEnumerable<SwimStyle> GetList();
        SwimStyle Update(int id, SwimStyle entity);
    }
}
