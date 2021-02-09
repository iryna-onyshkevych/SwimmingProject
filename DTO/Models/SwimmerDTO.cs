using System.Collections.Generic;

#nullable disable

namespace DTO.Models
{
    public partial class SwimmerDTO
    {
        public SwimmerDTO()
        {
            training = new HashSet<TrainingDTO>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? CoachId { get; set; }

        public virtual CoachDTO Coach { get; set; }
        public virtual ICollection<TrainingDTO> training { get; set; }
    }
}
