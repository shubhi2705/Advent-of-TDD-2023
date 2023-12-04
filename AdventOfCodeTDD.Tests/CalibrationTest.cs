using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    /// <summary>
    /// Test File
    /// </summary>
    [TestFixture]
    public class CalibrationTest
    {
        [Test]
        public void checkCalibration_When_first_and_last_digit_is_number()
        {
            var calibration = new Calibration();
            Assert.AreEqual(11, calibration.calculate_CalibrationValue("1wer1"));
        }

        [Test]
        public void checkCalibration_When_all_digits_are_numbers()
        {
            var calibration = new Calibration();
            Assert.AreEqual(15, calibration.calculate_CalibrationValue("143655"));
        }

        [Test]
        public void checkCalibration_When_all_digits_are_characters()
        {
            var calibration = new Calibration();
            Assert.AreEqual(0, calibration.calculate_CalibrationValue("absds"));
        }

        [Test]
        public void checkCalibration_When_string_contains_digits_and_characters()
        {
            var calibration = new Calibration();
            Assert.AreEqual(16, calibration.calculate_CalibrationValue("1rg5fh43hj6kfhd"));
        }

        [Test]
        public void checkCalibration_When_string_contains_single_digit()
        {
            var calibration = new Calibration();
            Assert.AreEqual(11, calibration.calculate_CalibrationValue("1rgjs"));
        }


        [Test]
        public void checkCalibration_When_string_contains_only_numeric_string()
        {
            var calibration = new Calibration();
            Assert.AreEqual(12, calibration.calculate_CalibrationValue("oneeighttwo"));
        }


        [Test]
        public void checkCalibration_When_string_contains_both_numeric_string_and_normal_number()
        {
            var calibration = new Calibration();
            Assert.AreEqual(18, calibration.calculate_CalibrationValue("one5eight7two8"));
        }

        [Test]
        public void checkCalibration_When_string_contains_random_string_and_normal_numbers()
        {
            var calibration = new Calibration();
            Assert.AreEqual(13, calibration.calculate_CalibrationValue("1uyy3ee"));
        }

        [Test]
        public void checkCalibration_When_string_contains_overlapping_string()
        {
            var calibration = new Calibration();
            Assert.AreEqual(11, calibration.calculate_CalibrationValue("oneeighttwone"));
        }

        [Test]
        public void checkCalibration_When_string_contains_overlapping_numeric_string()
        {
            var calibration = new Calibration();
            Assert.AreEqual(11, calibration.calculate_CalibrationValue("oneeighttwone"));
        }

        [Test]
        public void checkCalibration_When_string_contains_only_numbers()
        {
            var calibration = new Calibration();
            Assert.AreEqual(11, calibration.calculate_CalibrationValue("oneeighttwone"));
        }

        [Test]
        public void checkCalibration_When_string_contains_only_single_number_with_random_string()
        {
            var calibration = new Calibration();
            Assert.AreEqual(55, calibration.calculate_CalibrationValue("jfe5hrn"));
        }
       
    }
}