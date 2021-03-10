using System;

namespace ECS.Legacy
{
    public class Application
    {
        public static void Main(string[] args)
        {
            var ecs = new ECS(20, new TempSensor(), new Heater());

            var TempSensor = new TempSensor();
           
            TempSensor.setTemp(19);
            ecs.Regulate();
            TempSensor.setTemp(25);
            Console.ReadLine(); 
            //ecs.Handle;

            // ecs.Regulate();
        }
    }
}
