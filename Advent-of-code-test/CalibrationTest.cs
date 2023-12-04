using Advent_of_code;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code.Tests
{

    [TestFixture]
    public class TDD_Test
    {
        [Test]
        public void checkCalibration_When_first_and_last_digit_is_number()
        {
            var calibration = new Calibration();
            Assert.Equals(11, calibration.calculate_CalibrationValue("1wer1"));
        }

        [Test]
        public void checkCalibration_When_all_digits_are_numbers()
        {
            var calibration = new Calibration();
            Assert.Equals(15, calibration.calculate_CalibrationValue("143655"));
        }

        [Test]
        public void checkCalibration_When_all_digits_are_characters()
        {
            var calibration = new Calibration();
            Assert.Equals(0, calibration.calculate_CalibrationValue("absds"));
        }

        [Test]
        public void checkCalibration_When_string_contains_digits_and_characters()
        {
            var calibration = new Calibration();
            Assert.Equals(16, calibration.calculate_CalibrationValue("1rg5fh43hj6kfhd"));
        }

        [Test]
        public void checkCalibration_When_string_contains_single_digit()
        {
            var calibration = new Calibration();
            Assert.Equals(11, calibration.calculate_CalibrationValue("1rgjs"));
        }

    }
}
