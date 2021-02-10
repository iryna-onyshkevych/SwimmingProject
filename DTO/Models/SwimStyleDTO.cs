using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DTO.Models
{
    public partial class SwimStyleDTO
    {
        public SwimStyleDTO()
        {
            training = new HashSet<TrainingDTO>();
        }
        [Required(ErrorMessage = "Id is invalid!")]

        public int Id { get; set; }
        public string StyleName { get; set; }

        public virtual ICollection<TrainingDTO> training { get; set; }
    }
}
