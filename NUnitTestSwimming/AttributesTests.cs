using DTO.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestSwimming
{
    public class AttributesTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Attribute_AgeValidation_IsValid()
        {
            int age = 5;

            var result = AgeValidationAttribute.IsValidSwimmerAge(age);

            Assert.AreEqual(result, false);
        }
        [Test]
        public void Attribute_DistanceValidation_IsValid()
        {
            int distance = 250;

            var result = DistanceValidationAttribute.IsValidDistance(distance);

            Assert.AreEqual(result, true);
        }
        [Test]
        public void Attribute_WorkExperienceValidation_IsValid()
        {
            int workExperience = 150;

            var result = WorkExperienceValidationAttribute.IsValidCoachExperience(workExperience);

            Assert.AreEqual(result, false);
        }
    }
}
