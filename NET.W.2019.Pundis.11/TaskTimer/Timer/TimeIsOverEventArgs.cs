using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class TimeIsOverEventArgs : EventArgs
    {
        private readonly int seconds;
        private readonly string message;

        public TimeIsOverEventArgs(int seconds, string message)
        {
            this.seconds = seconds;
            this.message = message;
        }

        public int Seconds => seconds;
        public string Message => message;
    }
}