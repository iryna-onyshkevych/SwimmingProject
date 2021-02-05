using System;
using System.Collections.Generic;
using System.Text;

namespace Swimming.Abstractions.Attributes
{
    public class AgeValidationAttribute : Attribute

    {
        public static bool IsValidSwimmerAge(int age)
        {
            if ((age > 6) && (age < 21))

                return true;

            else

                return false;

        }
    }
}
