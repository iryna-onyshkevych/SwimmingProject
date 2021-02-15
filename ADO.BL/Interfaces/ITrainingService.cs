using DTO.Models;

namespace ADO.BL.Interfaces
{
    public interface ITrainingService
    {
        void AddTraining(TrainingDTO training);
        void DeleteTraining(int id);
        void UpdateTraining(TrainingDTO training);
        TrainingDTO GetTraining(int id);
    }
}
