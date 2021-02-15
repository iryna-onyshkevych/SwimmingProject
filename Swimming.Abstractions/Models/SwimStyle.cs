using System.Collections.Generic;

namespace Swimming.Abstractions.Models
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
