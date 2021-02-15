using System.Collections.Generic;

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
