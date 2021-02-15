using Swimming.Abstractions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swimming.Abstractions.Models
{
    public partial class Swimmer
    {
        public Swimmer()
        {
            training = new HashSet<Training>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [AgeValidation]
        public int Age { get; set; }

        [Required]
        public int? CoachId { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual ICollection<Training> training { get; set; }
    }
}
