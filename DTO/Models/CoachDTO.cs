using DTO.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
    public partial class CoachDTO
    {
        public CoachDTO()
        {
            Swimmers = new HashSet<SwimmerDTO>();
        }

        [Required(ErrorMessage = "Id is invalid!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is invalid!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is invalid!")]
        public string LastName { get; set; }

        [WorkExperienceValidation]
        [Required(ErrorMessage = "Work experience is invalid!")]
        public int WorkExperience { get; set; }
        public virtual ICollection<SwimmerDTO> Swimmers { get; set; }
    }
}
