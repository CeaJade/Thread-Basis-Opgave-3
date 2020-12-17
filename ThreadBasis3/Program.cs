using System;
using System.Threading;

namespace ThreadBasis3
{
    class Program
    {
        static Random random = new Random();
        static int temperature;

        static void Main(string[] args)
        {
            Thread temp = new Thread(SetTemperature);
            temp.Start();

            bool isAlive = true;
            while (isAlive)
            {
                Thread.Sleep(10000);
                if (!temp.IsAlive)
                {
                    Console.WriteLine("Alarm-tråd termineret!");
                    isAlive = false;
                }
            }

            Console.ReadKey();
        }

        static void SetTemperature()
        {
            int strike = 0;
            while (strike != 3)
            {
                temperature = random.Next(-20, 120);

                if (temperature < 0 || temperature > 100)
                {
                    Console.WriteLine("!CRITICAL!");
                    strike++;
                }
                else
                {
                    Console.WriteLine("It's {0} degrees", temperature);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
