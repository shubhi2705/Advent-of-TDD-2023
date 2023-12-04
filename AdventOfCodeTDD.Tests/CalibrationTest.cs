using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
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
    }
}