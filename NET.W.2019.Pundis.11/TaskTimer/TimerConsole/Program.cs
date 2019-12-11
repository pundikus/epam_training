using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;


namespace TimerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerClock timer = new TimerClock();

            AlarmClock alarm = new AlarmClock();
            alarm.Subscribe(timer);

            Phone phone = new Phone();
            phone.Subscribe(timer);

            timer.Start(10);

            Console.ReadKey();
        }
    }
}

