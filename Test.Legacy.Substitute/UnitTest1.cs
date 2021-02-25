using System.Security.Cryptography;
using ECS.Legacy;
using NUnit.Framework;
using NSubstitute;

namespace Test.Legacy.Substitute
{
    public class Tests
    {
        private int _threshold = 25;
        public ECS.Legacy.ECS uut;
        public ITempSensor tempSensor;
        public IHeater heater;
        //public FakeHeater FakeHeater;
        public FakeTempSensor fakeTempSensor;
        [SetUp]
        public void Setup()
        {
            heater = NSubstitute.Substitute.For<IHeater>();
            //tempSensor = NSubstitute.Substitute.For<ITempSensor>();
            fakeTempSensor = new FakeTempSensor();
            uut = new ECS.Legacy.ECS(_threshold, fakeTempSensor, heater);
        }

        [Test]
        public void Regulate_TempIsLow_HeaterIsOn()
        {
            //arrange
            fakeTempSensor.GenereateTemp = 20;

            //act
            uut.Regulate();

            //assert
            heater.Received(1).TurnOn();
        }

        [Test]
        public void Regulate_TempIsHigh_HeaterIsOff()
        {
            //arrange
            fakeTempSensor.GenereateTemp = 30;

            //act
            uut.Regulate();

            //assert
            heater.Received(1).TurnOff();

        }

        [TestCase(true,true,true)]
        [TestCase(false,true,false)]
        [TestCase(true,false,false)]
        [TestCase(false,false,false)]
        public void RunSelfTest_CombinationOfInput_CorrectOutput(bool tempResult, bool heaterResult, bool expectedResult)
        {
            //arrange
            fakeTempSensor.SelfTestResult = tempResult;

            //act/arrange
            heater.RunSelfTest().Returns(heaterResult);

            //assert
            Assert.That(uut.RunSelfTest(),Is.EqualTo(expectedResult));

        }

        /// <summary>
        /// Denne klasse er en fakeklasse af TempSensor klassen. Heri kan vi styre TempGeneratorens værdi. 
        /// </summary>
        public class FakeTempSensor : ITempSensor
        {
            public bool IsActived { get; private set; }
            public int GenereateTemp { get; set; }
            public bool SelfTestResult { get; set; }
            public int GetTemp()
            {
                IsActived = true;

                return GenereateTemp;
            }

            public bool RunSelfTest()
            {
                IsActived = true;

                return SelfTestResult;
            }
        }
    }
}