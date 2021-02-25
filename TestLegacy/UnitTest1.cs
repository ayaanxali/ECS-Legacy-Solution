using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using ECS.Legacy;

namespace TestLegacy
{
    public class Tests
    {
        private int _threshold;
        public ECS.Legacy.ECS uut;
      //  public ITempSensor tempSensor;
       // public IHeater heater;
        public FakeHeater FakeHeater;
        public FakeTempSensor FakeTempSensor;
        [SetUp]
        public void Setup()
        {
            FakeHeater = new FakeHeater();
            FakeTempSensor = new FakeTempSensor();
            uut = new ECS.Legacy.ECS(_threshold, FakeTempSensor, FakeHeater);
        }

        [Test]
        public void Regulate_LowTemp_HeaterIsTurnedOn()
        {
            FakeTempSensor.GenereateTemp = 20;
            uut.Regulate();
            Assert.That(FakeHeater.HeaterIsOn, Is.EqualTo(1));
        }
    }
    /// <summary>
    /// Dette er en én til én klasse med ECS hvor vi kan styre dependencies: _threshold og har skiftet TempSensor og Heater klassen ud med vores egne fakes. 
    /// </summary>
    //public class FakeECS : IECS
    //{
    //    private int _threshold;
    //    //private readonly TempSensor _tempSensor;
    //    //private readonly Heater _heater;
    //    private FakeTempSensor F_tempSensor;
    //    private FakeHeater F_heater;

    //    public FakeECS(int thr)
    //    {
    //        SetThreshold(thr);
    //       // _tempSensor = new TempSensor();
    //        //_heater = new Heater();
    //        F_tempSensor = new FakeTempSensor();
    //        F_heater = new FakeHeater();

    //    }

    //    public void Regulate()
    //    {
    //        var t = F_tempSensor.GetTemp();
    //        if (t < _threshold)
    //            F_heater.TurnOn();
    //        else
    //            F_heater.TurnOff();
    //    }
    //    public void SetThreshold(int thr)
    //    { _threshold = thr; }

    //    public int GetThreshold()
    //    {
    //        return _threshold;
    //    }

    //    public int GetCurTemp()
    //    {
    //        return F_tempSensor.GetTemp();
    //    }

    //    public bool RunSelfTest()
    //    {
    //        return F_tempSensor.RunSelfTest() && F_heater.RunSelfTest();
    //    }
    //}

    /// <summary>
    /// Denne klasse er en fakeklasse af TempSensor klassen. Heri kan vi styre TempGeneratorens værdi. 
    /// </summary>
    public class FakeTempSensor : ITempSensor
    {
        public bool IsActived { get; private set; }
        public int GenereateTemp { get; set; } = 0; 
        public int GetTemp()
        {
            IsActived = true;
            
            return GenereateTemp;
        }

        public bool RunSelfTest()
        {
            IsActived = true;

            return true; 
        }
    }

    /// <summary>
    /// Denne klasse er en fakeklasse af Heater klassen. 
    /// </summary>
    public class FakeHeater : IHeater
    {
        public int HeaterIsOn { get; set; } = 0;
        public int HeaterIsOff { get; set; } = 0;

        public void TurnOn()
        {
            ++HeaterIsOn;
        }

        public void TurnOff()
        {
            ++HeaterIsOff;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}