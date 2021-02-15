using DTO.Models;
using System.Collections.Generic;

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
