using DTO.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
    public partial class SwimmerDTO
    {
        public SwimmerDTO()
        {
            training = new HashSet<TrainingDTO>();
        }

        [Required(ErrorMessage = "Id is invalid!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is invalid!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is invalid!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is invalid!")]
        [AgeValidation]
        public int Age { get; set; }

        [Required(ErrorMessage = "CoachId is invalid!")]
        public int? CoachId { get; set; }
        public virtual CoachDTO Coach { get; set; }
        public virtual ICollection<TrainingDTO> training { get; set; }
    }
}
