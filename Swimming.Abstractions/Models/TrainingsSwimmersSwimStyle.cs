using Swimming.Abstractions.Attributes;
using System;
using System.Collections.Generic;
#nullable disable

namespace Swimming.Abstractions.Models
{
    public partial class TrainingsSwimmersSwimStyle
    {
        public int TrainingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TrainingDate { get; set; }

        [DistanceValidation]

        public int Distance { get; set; }
        public string Style { get; set; }
    }
}
