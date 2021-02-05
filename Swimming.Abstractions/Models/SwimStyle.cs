using System;
using System.Collections.Generic;

#nullable disable

namespace Swimming.Models
{
    public partial class SwimStyle
    {
        public SwimStyle()
        {
            training = new HashSet<Training>();
        }

        public int Id { get; set; }
        public string StyleName { get; set; }

        public virtual ICollection<Training> training { get; set; }
    }
}
