using DTO.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestSwimming.AttributeTests
{
    public class AttributeTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        [TestCase(30)]
        [TestCase(5)]
        public void Attribute_AgeValidation_IsValid(int age)
        {
            var result = AgeValidationAttribute.IsValidSwimmerAge(age);

            Assert.AreEqual(result, false);
        }

        [Test]
        [TestCase(250)]
        [TestCase(400)]
        public void Attribute_DistanceValidation_IsValid(int distance)
        {
            var result = DistanceValidationAttribute.IsValidDistance(distance);

            Assert.AreEqual(result, true);
        }

        [Test]
        [TestCase(150)]
        [TestCase(100)]
        public void Attribute_WorkExperienceValidation_IsValid(int value)
        {
            bool result = WorkExperienceValidationAttribute.IsValidCoachExperience(value);

            Assert.AreEqual(result, false);
        }
    }
}
