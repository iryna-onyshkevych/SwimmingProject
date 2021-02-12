using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public class SwimmingModel
    {
        public List<SwimmerDTO> Swimmers { get; set; }
        public int CurrentIndex { get; set; }
        public int PageCount { get; set; }
    }
}
