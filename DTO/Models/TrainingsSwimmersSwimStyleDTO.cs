using System;

namespace DTO.Models
{
    public partial class TrainingsSwimmersSwimStyleDTO
    {
        public int TrainingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TrainingDate { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }
    }
}
