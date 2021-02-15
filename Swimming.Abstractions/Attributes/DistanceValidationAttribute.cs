using System;

namespace Swimming.Abstractions.Attributes
{
    public class DistanceValidationAttribute : Attribute
    {
        public static bool IsValidDistance(int distance)
        { 
            return  ((distance >= 200) && (distance <= 1400)) ? true : false;
        }
    }
}
