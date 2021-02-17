using DTO.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
    public partial class TrainingDTO
    {
        [Required(ErrorMessage = "Id is required!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Swimmer Id is required!")]
        public int SwimmerId { get; set; }

        [Required(ErrorMessage = "SwimStyle Id is required!")]
        public int SwimStyleId { get; set; }

        [Required(ErrorMessage = "Training date is required!")]
        public DateTime TrainingDate { get; set; }

        [Required(ErrorMessage = "Distance is required!")]
        [DistanceValidation]
        public int Distance { get; set; }
        public virtual SwimStyleDTO SwimStyle { get; set; }
        public virtual SwimmerDTO Swimmer { get; set; }
    }
}
