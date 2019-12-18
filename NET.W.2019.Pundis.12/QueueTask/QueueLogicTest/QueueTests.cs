using System;
using NUnit.Framework;

namespace QueueLogic.Tests
{
    [TestFixture]
    public class QueueTests
    {
        #region Constructors tests

        [Test]
        public void CtorWithIEnumerable_NullRef_ThrowsArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                Queue<int> queue = new Queue<int>(null);
            });
        }

        [Test]
        public void CtorWithCapacity_NegativeNumber_ThrowsArgumentException()
        {
            Assert.Catch<ArgumentException>(() =>
            {
                Queue<int> queue = new Queue<int>(-5);
            });
        }

        #endregion


        #region Methods tests

        [Test]
        public void Enqueue_NullRef_ThrowsArgumentNullException()
        {
            Queue<string> queue = new Queue<string>();
            Assert.Catch<ArgumentNullException>(() => queue.Enqueue(null));
        }

        [Test]
        public void Dequeue_EmptyEqueue_ThrowsQuequeIsEmptyException()
        {
            Queue<int> queue = new Queue<int>();
            Assert.Catch<QueueIsEmptyException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_EmptyEqueue_ThrowsQuequeIsEmptyException()
        {
            Queue<int> queue = new Queue<int>();
            Assert.Catch<QueueIsEmptyException>(() => queue.Peek());
        }

        #endregion
    }
}