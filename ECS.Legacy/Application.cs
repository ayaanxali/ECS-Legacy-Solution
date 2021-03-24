using System;

namespace ECS.Legacy
{
    public class Application
    {

        public static void Main(string[] args)
        {
            var TempSensor = new TempSensor();
            var ecs = new ECS(20, TempSensor, new Heater());

           
           
            TempSensor.setTemp(19);
            ecs.Regulate();
            TempSensor.setTemp(25);
            Console.ReadLine(); 
            //ecs.Handle;

            // ecs.Regulate();
        }
    }
}
