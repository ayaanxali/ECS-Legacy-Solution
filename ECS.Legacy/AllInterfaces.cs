using System;

namespace ECS.Legacy
{
    public interface IECS
    {
        void Regulate();
        void SetThreshold(int thr);
        int GetThreshold();
        int GetCurTemp();
        bool RunSelfTest();
    }

    public interface IHeater
    {
        void TurnOn();
        void TurnOff();
        bool RunSelfTest(); 
    }

    public interface ITempSensor
    {
       // int GetTemp();
       // bool RunSelfTest();
        event EventHandler<TempChangedEventArgs> TempChangedEvent;
    }

    public class TempChangedEventArgs : EventArgs
    {
        public int Temp { get; set; }
    }
}