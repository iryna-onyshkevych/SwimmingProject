using System;


namespace Swimming.Abstractions.Attributes
{
    public class AgeValidationAttribute : Attribute

    {
        public static bool IsValidSwimmerAge(int age)
        {
          
            return ((age > 6) && (age < 21)) ? true : false;
        }
    }
}
