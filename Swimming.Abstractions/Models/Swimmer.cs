using Swimming.Abstractions.Attributes;
using System;
using System.Collections.Generic;

#nullable disable

namespace Swimming.Abstractions.Models
{
    public partial class Swimmer
    {
        public Swimmer()
        {
            training = new HashSet<Training>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [AgeValidation]
        public int Age { get; set; }
        public int? CoachId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual ICollection<Training> training { get; set; }
    }
}
