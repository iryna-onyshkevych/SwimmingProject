using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.Abstractions.Interfaces
{
    public interface ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle>
    {
        IEnumerable<TrainingsSwimmersSwimStyle> GetList();

    }
}
