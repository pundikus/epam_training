using System;
using QueueLogic;

namespace QueueTask
{
    class Program
    {
        static void Main(string[] args)
        {
            #region The first queue 

            Queue<int> queue0 = new Queue<int>();
            queue0.Enqueue(4);
            queue0.Enqueue(5);
            queue0.Enqueue(6);
            ShowQueue(queue0);

            queue0.Dequeue();
            ShowQueue(queue0);

            Console.WriteLine("First element is " + queue0.Peek());
            Console.WriteLine("Count of elements: " + queue0.Count);

            queue0.Clear();
            ShowQueue(queue0);

            #endregion


            #region The second queue

            Queue<int> queue1 = new Queue<int>(new int[] { 1, 4, 2, 1, 4, 5 });
            queue1.Enqueue(12);
            ShowQueue(queue1);

            queue1.Enqueue(-121);
            ShowQueue(queue1);

            #endregion


            #region The third queue

            Queue<int> queue2 = new Queue<int>(5);
            queue2.Enqueue(12);
            queue2.Enqueue(13);
            ShowQueue(queue2);

            #endregion
            Console.ReadLine();
        }

        static void ShowQueue<T>(Queue<T> queue)
        {
            Console.WriteLine("\nNow in queue: ");

            foreach (T q in queue)
            {
                Console.WriteLine(q + " ");
            }
        }
    }
}
