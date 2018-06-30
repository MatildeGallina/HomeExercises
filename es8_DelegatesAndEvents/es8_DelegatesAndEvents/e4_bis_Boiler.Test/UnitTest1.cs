using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace e4_bis_Boiler.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void starter_values()
        {
            Kettle kettle = new Kettle();

            Assert.AreEqual(false, kettle.KettelOn);
            Assert.AreEqual(Color.Off, kettle.LED);
        }

        [TestMethod]
        public void differents_liquids_can_have_different_temperatures()
        {
            LiquidButton liquid1 = new LiquidButton(15);
            LiquidButton liquid2 = new LiquidButton(30);

            Assert.AreNotEqual(liquid1.Temperature, liquid2.Temperature);
        }

        [TestMethod]
        public void one_kettle_can_have_only_one_liquid()
        {
            Kettle kettle = new Kettle();
            LiquidButton liquid1 = new LiquidButton(15);
            LiquidButton liquid2 = new LiquidButton(30);

            kettle.Liquid = liquid1;
            Assert.AreEqual(liquid1, kettle.Liquid);

            kettle.Liquid = liquid2;
            Assert.AreNotSame(liquid1, liquid2);
            Assert.AreEqual(liquid2, kettle.Liquid);
            Assert.AreNotEqual(liquid1, kettle.Liquid);
        }

        [TestMethod]
        public void kettle_turned_on()
        {
            Kettle kettle = new Kettle();
            PowerButton power = new PowerButton();
            WarningLED warning = new WarningLED();

            power.PressedPowerButton(kettle, warning);

            Assert.AreEqual(true, kettle.KettelOn);
        }

        [TestMethod]
        public void Red_LED_kettle_On()
        {
            Kettle kettle = new Kettle();
            PowerButton power = new PowerButton();
            WarningLED warning = new WarningLED();

            power.PressedPowerButton(kettle, warning);

            Assert.AreEqual(Color.Red, kettle.LED);
        }

        [TestMethod]
        public void cannot_turn_on_a_turned_on_kettle()
        {
            Kettle kettle = new Kettle();
            PowerButton power = new PowerButton();
            WarningLED warning = new WarningLED();

            power.PressedPowerButton(kettle, warning);
            power.PressedPowerButton(kettle, warning);

            Assert.AreNotEqual(true, kettle.KettelOn);
        }
                
        [TestMethod]
        public void temperature_cannot_rise_if_kettle_is_Off()
        {
            Kettle kettle = new Kettle();
            kettle.Liquid = new LiquidButton(87);
            WarningLED warning = new WarningLED();

            kettle.Liquid.IncresedLiquidTemperature(kettle, warning);
            Assert.AreEqual(false, kettle.KettelOn);
            Assert.AreEqual(87, kettle.Liquid.Temperature);

        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void temperature_cannot_rise_if_there_is_no_liquid_in_the_kettle()
        {
            Kettle kettle = new Kettle();
            PowerButton power = new PowerButton();
            kettle.Liquid = null;
            LiquidButton liquid = new LiquidButton(85);
            WarningLED warning = new WarningLED();


            power.PressedPowerButton(kettle, warning);
            kettle.Liquid.IncresedLiquidTemperature(kettle, warning);
        }

        [TestMethod]
        public void temperature_rise_when_kettle_is_On()
        {
            Kettle kettle = new Kettle();
            PowerButton power = new PowerButton();
            kettle.Liquid = new LiquidButton(87);
            WarningLED warning = new WarningLED();

            power.PressedPowerButton(kettle, warning);
            kettle.Liquid.IncresedLiquidTemperature(kettle, warning);
            Assert.AreEqual(true, kettle.KettelOn);
            Assert.AreEqual(97, kettle.Liquid.Temperature);
        }

        [TestMethod]
        public void Green_LED_when_temperature_is_over_100()
        {
            Kettle kettle = new Kettle();
            PowerButton power = new PowerButton();
            kettle.Liquid = new LiquidButton(87);
            WarningLED warning = new WarningLED();

            power.PressedPowerButton(kettle, warning);
            kettle.Liquid.IncresedLiquidTemperature(kettle, warning);
            kettle.Liquid.IncresedLiquidTemperature(kettle, warning);
            Assert.AreEqual(true, kettle.KettelOn);
            Assert.AreEqual(107, kettle.Liquid.Temperature);
            Assert.AreEqual(Color.Green, kettle.LED);
        }

        [TestMethod]
        public void turn_off_a_turned_on_kettle()
        {
            Kettle kettle = new Kettle();
            PowerButton power = new PowerButton();
            WarningLED warning = new WarningLED();

            power.PressedPowerButton(kettle, warning);
            power.PressedPowerButton(kettle, warning);

            Assert.AreEqual(false, kettle.KettelOn);
        }

        [TestMethod]
        public void reset_values_when_turn_off()
        {
            Kettle kettle = new Kettle();
            PowerButton power = new PowerButton();
            WarningLED warning = new WarningLED();

            power.PressedPowerButton(kettle, warning);
            power.PressedPowerButton(kettle, warning);

            Assert.AreEqual(false, kettle.KettelOn);
            Assert.AreEqual(Color.Off, kettle.LED);
            Assert.AreEqual(null, kettle.Liquid);
        }
    }
}
