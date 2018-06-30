using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace e4_Boiler.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void starter_values()
        {
            Kettle kettle = new Kettle();

            Assert.AreEqual(false, kettle.KettelOn);
            Assert.AreEqual(15, kettle.Temperature);
            Assert.AreEqual(Color.Off, kettle.LED);
        }

        [TestMethod]
        public void kettle_turned_on()
        {
            Kettle kettle = new Kettle();
            Assert.AreEqual(false, kettle.KettelOn);

            PowerButton powerButton = new PowerButton();
            Assert.AreEqual(false, kettle.KettelOn);

            WarningLED warningLED = new WarningLED();
            Assert.AreEqual(false, kettle.KettelOn);

            powerButton.PressedPowerButton(warningLED, kettle);
            Assert.AreEqual(true, kettle.KettelOn);
        }

        [TestMethod]
        public void cannot_turn_on_a_turned_on_kettle()
        {
            Kettle kettle = new Kettle();
            PowerButton powerButton = new PowerButton();
            WarningLED warning = new WarningLED();

            powerButton.PressedPowerButton(warning, kettle);
            powerButton.PressedPowerButton(warning, kettle);

            Assert.AreNotEqual(true, kettle.KettelOn);
        }
        
        [TestMethod]
        public void Red_LED_kettle_On()
        {
            Kettle kettle = new Kettle();
            PowerButton powerButton = new PowerButton();
            WarningLED warning = new WarningLED();
            Assert.AreEqual(Color.Off, kettle.LED);

            powerButton.PressedPowerButton(warning, kettle);

            Assert.AreEqual(Color.Red, kettle.LED);
        }

        [TestMethod]
        public void temperature_cannot_rise_if_kettle_is_Off()
        {
            Kettle kettle = new Kettle();
            Assert.AreEqual(15, kettle.Temperature);

            LiquidButton liquidButton = new LiquidButton();
            WarningLED warning = new WarningLED();

            liquidButton.IncresedLiquidTemperature(warning, kettle);

            Assert.AreEqual(15, kettle.Temperature);
        }

        [TestMethod]
        public void temperature_rise_when_kettle_is_On()
        {
            Kettle kettle = new Kettle();
            PowerButton powerButton = new PowerButton();
            LiquidButton liquidButton = new LiquidButton();
            WarningLED warning = new WarningLED();

            powerButton.PressedPowerButton(warning, kettle);
            liquidButton.IncresedLiquidTemperature(warning, kettle);

            Assert.AreEqual(true, kettle.KettelOn);
            Assert.AreEqual(25, kettle.Temperature);

            liquidButton.IncresedLiquidTemperature(warning, kettle);

            Assert.AreEqual(35, kettle.Temperature);
        }

        [TestMethod]
        public void Green_LED_when_temperature_is_over_100()
        {
            Kettle kettle = new Kettle();
            PowerButton powerButton = new PowerButton();
            LiquidButton liquidButton = new LiquidButton();
            WarningLED warning = new WarningLED();

            powerButton.PressedPowerButton(warning, kettle);

            for (int i = 0; i < 9; i++)
                liquidButton.IncresedLiquidTemperature(warning, kettle);

            Assert.AreEqual(Color.Green, kettle.LED);
        }

        [TestMethod]
        public void turn_off_a_turned_on_kettle()
        {
            Kettle kettle = new Kettle();
            PowerButton powerButton = new PowerButton();
            WarningLED warning = new WarningLED();

            powerButton.PressedPowerButton(warning, kettle);
            powerButton.PressedPowerButton(warning, kettle);

            Assert.AreEqual(false, kettle.KettelOn);
        }

        [TestMethod]
        public void reset_values_when_turn_off()
        {
            Kettle kettle = new Kettle();
            PowerButton powerButton = new PowerButton();
            LiquidButton liquidButton = new LiquidButton();
            WarningLED warning = new WarningLED();

            powerButton.PressedPowerButton(warning, kettle);

            for (int i = 0; i < 9; i++)
                liquidButton.IncresedLiquidTemperature(warning, kettle);

            powerButton.PressedPowerButton(warning, kettle);

            Assert.AreEqual(false, kettle.KettelOn);
            Assert.AreEqual(Color.Off, kettle.LED);
            Assert.AreEqual(15, kettle.Temperature);
        }
    }
}
