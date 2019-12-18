using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueLogic
{
    /// <summary>
    /// Represents a first-in, first-out collection of objects.
    /// </summary>
    /// <typeparam name="T">  Specifies the type of elements in the queue. </typeparam>
    public sealed class Queue<T> : IEnumerable<T>, IEnumerable
    {
        #region Private fields

        private T[] _array;

        private int _head;

        private int _tail;

        #endregion


        #region Properties

        /// <summary>
        /// Gets the number of elements contained in <see cref="Queue{T}"/>.
        /// </summary>
        /// <returns> The number of elements contained in <see cref="Queue{T}"/>. </returns>
        public int Count { get; private set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="Queue{T}"/>
        /// that is empty and has the default initial capacity(8).
        /// </summary>
        public Queue() : this(8) { }

        /// <summary>   
        /// Initializes a new instance of <see cref="Queue{T}"/>
        /// that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">
        /// The initial number of elements that the <see cref="Queue{T}"/> can contain.
        /// </param>
        public Queue(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("Capacity can't be less than 1.");
            }

            _head = 0;
            _tail = 0;
            Count = 0;
            _array = new T[capacity];
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Queue{T}"/> that contains 
        /// elements copied from the specified collection and has sufficient capacity
        /// to accommodate the number of elements copied.
        /// </summary>
        /// <param name="array"> 
        /// The collection whose elements are copied to the new <see cref="Queue{T}"/> 
        /// </param>
        public Queue(IEnumerable<T> array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            _array = new T[array.Count()];

            foreach (var elem in array)
            {
                this.Enqueue(elem);
            }
        }

        #endregion


        #region Queue logic methods

        /// <summary>
        /// Adds an object to the end of the <see cref="Queue{T}"/>.
        /// </summary>
        /// <param name="elem"> 
        /// The object to add to the <see cref="Queue{T}"/>. The value can't be
        /// null for reference types. 
        /// </param>
        public void Enqueue(T elem)
        {
            if (elem == null)
            {
                throw new ArgumentNullException(nameof(elem));
            }

            if (this.Count == _array.Length)
            {
                T[] objArray = new T[Count + 8];
                Array.Copy(_array, objArray, Count);

                _array = objArray;
            }

            _array[Count] = elem;
            _tail++;
            Count++;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="Queue{T}"/>.
        /// </summary>
        /// <returns>
        /// The object that is removed from the beginning of the <see cref="Queue{T}"/>.
        /// </returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new QueueIsEmptyException();
            }

            T obj = _array[0];

            _head++;
            Count--;

            return obj;
        }

        /// <summary>
        /// Returns the object at the beginning of the <see cref="Queue{T}"/>
        /// without removing it.
        /// </summary>
        /// <returns>
        /// The object at the beginning of the <see cref="Queue{T}"/>.
        /// </returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new QueueIsEmptyException();
            }

            return _array[_head];
        }

        /// <summary>
        /// Removes all objects from the <see cref="Queue{T}"/>.
        /// </summary>
        public void Clear()
        {
            _array = new T[_array.Length];

            _head = _tail = 0;
            Count = 0;
        }

        #endregion


        #region IEnumerable, IEnumerable<T> implementations

        /// <summary>
        /// Iterator.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion


        #region Custom iterator

        private struct CustomIterator : IEnumerator<T>
        {
            internal CustomIterator(Queue<T> container)
            {
                this.container = container;
                currentIndex = container._head - 1;
            }

            public bool MoveNext()
            {
                currentIndex = (currentIndex + 1);

                return currentIndex != container._tail;
            }

            public void Reset()
            {
                currentIndex = container._head - 1;
            }

            object IEnumerator.Current => Current;

            public T Current
            {
                get
                {
                    if (currentIndex < 0 ||
                        currentIndex >= container._tail)
                    {
                        throw new InvalidOperationException();
                    }
                    return container._array[currentIndex];
                }
            }

            public void Dispose() { }

            private readonly Queue<T> container;
            private int currentIndex;
        }

        #endregion
    }
}