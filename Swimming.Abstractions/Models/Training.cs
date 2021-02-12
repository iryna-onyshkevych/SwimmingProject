using Swimming.Abstractions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Swimming.Abstractions.Models
{
    public partial class Training
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SwimmerId { get; set; }
        [Required]
        public int SwimStyleId { get; set; }
        [Required]
        public DateTime TrainingDate { get; set; }
        [Required]
        [DistanceValidation]

        public int Distance { get; set; }

        public virtual SwimStyle SwimStyle { get; set; }
        public virtual Swimmer Swimmer { get; set; }
    }
}
