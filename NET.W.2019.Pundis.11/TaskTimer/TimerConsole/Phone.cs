using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;

namespace TimerConsole
{
    public class Phone
    {
        /// <summary>
        /// Subscribes the timer.
        /// </summary>
        /// <param name="timer">The clock.</param>
        public void Subscribe(TimerClock timer) => timer.TimeIsOver += OnTimeIsOver_Handler;

        /// <summary>
        /// Unsubscribes the timer.
        /// </summary>
        /// <param name="timer">The clock.</param>
        public void Unsubscribe(TimerClock timer) => timer.TimeIsOver -= OnTimeIsOver_Handler;

        /// <summary>
        /// Handler event end timer
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Information about event</param>
        public void OnTimeIsOver_Handler(object sender, TimeIsOverEventArgs e)
        {
            Console.WriteLine($"Phone rings. {e.Seconds} {e.Message}");
        }
    }
}