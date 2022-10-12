using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gui_Speed_4_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Speed_4_.Tests
{
    [TestClass()]
    public class SpeedTests
    {

        [TestMethod()]
        public void VerboseTest()
        {
            var speed = new Speed(38, MeasureType.ms);
            Assert.AreEqual("38 м/с", speed.Verbose());

            speed = new Speed(38, MeasureType.kmh);
            Assert.AreEqual("38 км/ч", speed.Verbose());

            speed = new Speed(38, MeasureType.M);
            Assert.AreEqual("38 Мах.", speed.Verbose());

            speed = new Speed(38, MeasureType.kn);
            Assert.AreEqual("38 Уз.", speed.Verbose());
        }
        [TestMethod()]
        public void AddNumberTest()
        {
            var speed = new Speed(1, MeasureType.ms);
            speed = speed + 4.25;
            Assert.AreEqual("5,25 м/с", speed.Verbose());
        }
        [TestMethod()]
        public void SubNumberTest()
        {
            var speed = new Speed(3, MeasureType.ms);
            speed = speed - 1.75;
            Assert.AreEqual("1,25 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()
        {
            var speed = new Speed(3, MeasureType.ms);
            speed = speed * 3;
            Assert.AreEqual("9 м/с", speed.Verbose());
        }
        [TestMethod()]
        public void MeterToAnyTest()
        {
            Speed speed;

            speed = new Speed(1, MeasureType.ms);
            Assert.AreEqual("3,6 км/ч", speed.To(MeasureType.kmh).Verbose());

            speed = new Speed(340, MeasureType.ms);
            Assert.AreEqual("1 Мах.", speed.To(MeasureType.M).Verbose());

            speed = new Speed(1, MeasureType.ms);
            Assert.AreEqual("1,94384 Уз.", speed.To(MeasureType.kn).Verbose());
        }
        [TestMethod()]
        public void AnyToMeterTest()
        {
            Speed speed;

            speed = new Speed(3.6, MeasureType.kmh);
            Assert.AreEqual("1 м/с", speed.To(MeasureType.ms).Verbose());

            speed = new Speed(1, MeasureType.M);
            Assert.AreEqual("340 м/с", speed.To(MeasureType.ms).Verbose());

            speed = new Speed(1.94384, MeasureType.kn);
            Assert.AreEqual("1 м/с", speed.To(MeasureType.ms).Verbose());
        }
        [TestMethod()]
        public void AddSubKmMetersTest()
        {
            var ms = new Speed(100, MeasureType.ms);
            var kmh = new Speed(1, MeasureType.kmh);

            Assert.AreEqual("100 м/с", (ms > kmh).Verbose());
            Assert.AreEqual("100 м/с", (kmh > ms).Verbose());

            Assert.AreEqual("1 км/ч", (kmh < ms).Verbose());
            Assert.AreEqual("1 км/ч", (ms < kmh).Verbose());
        }
    }
}