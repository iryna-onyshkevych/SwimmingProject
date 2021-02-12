using System;


namespace DTO.Attributes
{
    public class WorkExperienceValidationAttribute : Attribute
    {
        public static bool IsValidCoachExperience(int workExperience)
        {
            
            return ((workExperience >= 0) && (workExperience < 80)) ? true : false;
        }
    }
}
