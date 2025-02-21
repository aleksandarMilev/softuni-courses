namespace Television.Tests
{
    using NUnit.Framework;
    using System;
    public class TelevisionTests
    {
        private TelevisionDevice televisionDevice;

        [SetUp]
        public void Setup()
        {
            televisionDevice = new("LG", 1_000.50, 75, 50);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            string expectedBrand = "LG";
            double expectedPrice = 1_000.50;
            int expectedScreenWidth = 75;
            int expectedScreenHeight = 50;

            Assert.AreEqual(expectedBrand, televisionDevice.Brand);
            Assert.AreEqual(expectedPrice, televisionDevice.Price);
            Assert.AreEqual(expectedScreenWidth, televisionDevice.ScreenWidth);
            Assert.AreEqual(expectedScreenHeight, televisionDevice.ScreenHeigth);
        }

        [Test]
        public void BrandGetterShouldReturnCorrectValue()
        {
            string expectedResult = "LG";

            Assert.AreEqual(expectedResult, televisionDevice.Brand);
        }

        [Test]
        public void PriceGetterShouldReturnCorrectValue()
        {
            double expectedPrice = 1_000.50;

            Assert.AreEqual(expectedPrice, televisionDevice.Price);
        }

        [Test]
        public void ScreenWidthGetterShouldReturnCorrectValue()
        {
            int expectedScreenWidth = 75;

            Assert.AreEqual(expectedScreenWidth, televisionDevice.ScreenWidth);
        }

        [Test]
        public void ScreenHeightGetterShouldReturnCorrectValue()
        {
            int expectedScreenHeight = 50;

            Assert.AreEqual(expectedScreenHeight, televisionDevice.ScreenHeigth);
        }

        [Test]
        public void SwitchOnMethodReturnCorrectStringIfIsMutedIsTrue()
        {
            televisionDevice.MuteDevice();

            string expectedResult
                = $"Cahnnel 0 - Volume 13 - Sound Off";

            Assert.AreEqual(expectedResult, televisionDevice.SwitchOn());
        }

        [Test]
        public void SwitchOnMethodReturnCorrectStringIfIsMutedIsFalse()
        {
            string expectedResult
                = $"Cahnnel 0 - Volume 13 - Sound On";

            Assert.AreEqual(expectedResult, televisionDevice.SwitchOn());
        }

        [Test]
        public void ChangeChannelMethodShouldReturnTheCorrectChanel()
        {
            int exceptedResult = 5;
            int actualResult = televisionDevice.ChangeChannel(5);

            Assert.AreEqual(exceptedResult, actualResult);
        }

        [Test]
        public void ChangeChannelMethodShouldThrowExceptionIfParameterIsNegative()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => televisionDevice.ChangeChannel(-1));

            Assert.AreEqual("Invalid key!", exception.Message);
        }

        [Test]
        public void VolumeChangeMethodShouldIncreaseVolumeIfDirectionIsUp()
        {
            string expectedResult = "Volume: 23";

            string actualResult = televisionDevice.VolumeChange("UP", 10);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void VolumeChangeMethodShouldDecreaseVolumeIfDirectionIsUp()
        {
            string expectedResult = "Volume: 3";

            string actualResult = televisionDevice.VolumeChange("DOWN", 10);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void VolumeChangeMethodShouldSetTheVolumeTo100IfTheSumIsGreater()
        {
            string expectedResult = "Volume: 100";

            string actualResult = televisionDevice.VolumeChange("UP", 100);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void VolumeChangeMethodShouldSetTheVolumeTo0IfTheSumIsLower()
        {
            string expectedResult = "Volume: 0";

            string actualResult = televisionDevice.VolumeChange("DOWN", 14);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MuteDeviceMethodShouldMuteUnmutedDevice()
        {
            televisionDevice.MuteDevice();

            bool isMuted = televisionDevice.MuteDevice();

            Assert.IsFalse(isMuted);
        }

        [Test]
        public void MuteDeviceMethodShouldUnmuteMutedDevice()
        {
            bool isMuted = televisionDevice.MuteDevice();

            Assert.IsTrue(isMuted);
        }

        [Test]
        public void ToStringOverrideShouldReturnTheCorrectValue()
        {
            string expectedResult = $"TV Device: {televisionDevice.Brand}, Screen Resolution: {televisionDevice.ScreenWidth}x{televisionDevice.ScreenHeigth}, Price {televisionDevice.Price}$";

            string actualResult = televisionDevice.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}