using System;

namespace ECS.Legacy
{
    internal class TempSensor: ITempSensor
    {
        //private Random gen = new Random();
        public event EventHandler<TempChangedEventArgs> TempChangedEvent;

        private int _oldTemp;
        //public int GetTemp()
        //{
        //    return gen.Next(-5, 45);
        //}

        //public bool RunSelfTest()
        //{
        //    return true;
        //}
        public void setTemp(int newTemp)
        {
            if (newTemp != _oldTemp)
            {
                OnTempChanged(new TempChangedEventArgs {Temp = newTemp});
                _oldTemp = newTemp;
            }
        }

        protected virtual void OnTempChanged(TempChangedEventArgs e)
        {
            TempChangedEvent?.Invoke(this,e);
        }
    }
}