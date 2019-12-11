using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public sealed class TimerClock
    {
        /// <summary>
        /// Event than time is over.
        /// </summary>
        public event EventHandler<TimeIsOverEventArgs> TimeIsOver = delegate { };

        /// <summary>
        /// Startas counting and send message after the end.
        /// </summary>
        public void Start(int seconds)
        {
            if (seconds < 0)
            {
                throw new ArgumentException($"{ nameof(seconds)} must be greater than 0.");
            }
            Console.WriteLine("Start.");

            Thread.Sleep(seconds * 1000);
            OnTimeIsOver(this, new TimeIsOverEventArgs(seconds, "seconds is over!"));
        }

        /// <summary>
        /// When time is over.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">Containing the event data.</param>
        private void OnTimeIsOver(object sender, TimeIsOverEventArgs e) => TimeIsOver?.Invoke(sender, e);
    }
}