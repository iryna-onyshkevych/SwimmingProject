using System;

#nullable disable

namespace DTO.Models
{
    public partial class TrainingDTO
    {
        public int Id { get; set; }
        public int SwimmerId { get; set; }
        public int SwimStyleId { get; set; }
        public DateTime TrainingDate { get; set; }


        public int Distance { get; set; }

        public virtual SwimStyleDTO SwimStyle { get; set; }
        public virtual SwimmerDTO Swimmer { get; set; }
    }
}
