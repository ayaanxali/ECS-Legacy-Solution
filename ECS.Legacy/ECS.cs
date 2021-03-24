using System;

namespace ECS.Legacy
{
    public class ECS 
    {
        private int _threshold;
        //private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        public int CurrentTemperature;

        //public ECS(int thr, ITempSensor tempSensor, IHeater heater)
        //{
        //    //SetThreshold(thr);
        //    _tempSensor = tempSensor;
        //    _heater = heater;

        //}
        public ECS(int threshold, ITempSensor tempSensor, IHeater heater)
        {
            tempSensor.TempChangedEvent += HandleTempChangedEvent;
            _threshold = threshold;
            _heater = heater;
        }

        private void HandleTempChangedEvent(object sender, TempChangedEventArgs e)
        {
            Console.WriteLine("Im in Event");
            CurrentTemperature = e.Temp;
            Regulate();
        }
        //public void Regulate()
        //{
        //    var t = _tempSensor.GetTemp();
        //    if (t < _threshold)
        //        _heater.TurnOn();
        //    else
        //        _heater.TurnOff();

        //}
        public void Regulate()
        {
            Console.WriteLine("Im in regulate");
            if (CurrentTemperature < _threshold)
            {
                _heater.TurnOn();
            }
            else
            {
                _heater.TurnOff();
            }
        }

        //public void SetThreshold(int thr)
        //{
        //    _threshold = thr;
        //}

        //public int GetThreshold()
        //{
        //    return _threshold;
        //}

        //public int GetCurTemp()
        //{
        //    return _tempSensor.GetTemp();
        //}

        //public bool RunSelfTest()
        //{
        //    return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        //}
    }
}
