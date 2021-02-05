using System;
using System.Collections.Generic;

#nullable disable

namespace Swimming.Models
{
    public partial class Training
    {
        public int Id { get; set; }
        public int SwimmerId { get; set; }
        public int SwimStyleId { get; set; }
        public DateTime TrainingDate { get; set; }
        public int Distance { get; set; }

        public virtual SwimStyle SwimStyle { get; set; }
        public virtual Swimmer Swimmer { get; set; }
    }
}
