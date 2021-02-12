using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwimmingWebApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<CoachDTO> Coaches { get; set; }
        public IEnumerable<SwimmerDTO> Swimmers { get; set; }
        public IEnumerable<TrainingsSwimmersSwimStyleDTO> Trainings { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
