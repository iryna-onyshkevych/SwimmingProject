using System;
using System.Collections.Generic;

#nullable disable

namespace Swimming.Models
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
        public int Age { get; set; }
        public int? CoachId { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual ICollection<Training> training { get; set; }
    }
}
