using System;

namespace QueueLogic
{
    /// <summary>
    /// Represents errors when queue is empty. 
    /// </summary>
    public sealed class QueueIsEmptyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="QueueIsEmptyException"/> .
        /// </summary>
        public QueueIsEmptyException() : base("Queue is empty.") { }

        /// <summary>
        /// Initializes a new instance of <see cref="QueueIsEmptyException"/> 
        /// class with message string.
        /// </summary>
        /// <param name="message"> The message about exception. </param>
        public QueueIsEmptyException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of <see cref="QueueIsEmptyException"/> 
        /// class with message string and inner exception.
        /// </summary>
        /// <param name="message"> The message about exception. </param>
        /// <param name="innerException"> The inner exception. </param>
        public QueueIsEmptyException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}