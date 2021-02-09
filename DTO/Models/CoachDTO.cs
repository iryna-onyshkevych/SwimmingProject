using System.Collections.Generic;

#nullable disable

namespace DTO.Models
{
    public partial class CoachDTO
    {
        public CoachDTO()
        {
            Swimmers = new HashSet<SwimmerDTO>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int WorkExperience { get; set; }

        public virtual ICollection<SwimmerDTO> Swimmers { get; set; }
    }
}
