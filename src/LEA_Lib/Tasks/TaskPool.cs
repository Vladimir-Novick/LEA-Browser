using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEA.Lib.Tasks
{

    public static class TaskPool
    {
        /*
         * 
         Copyright (C) 2018 by Vladimir Novick http://www.linkedin.com/in/vladimirnovick , 

        vlad.novick@gmail.com , http://www.sgcombo.com , https://github.com/Vladimir-Novick	

         * 
        */
        private static ConcurrentDictionary<String, Task> threadPool = new ConcurrentDictionary<String, Task>();

        private static readonly Object locker = new Object();

        private static QueueByKey<Task> queueByKey = new QueueByKey<Task>();

        private static double getTimespan()
        {
            return (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
        }
        /// <summary>
        ///   Add asynchronous task without queue 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="task"></param>
        public static void Add(String key, Task task)
        {
            TaskPool.AddToQueue(key + getTimespan().ToString(), task);
        }
        /// <summary>
        ///   Add asynchronous task to queue by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="task"></param>
        public static void AddToQueue(String key, Task task)
        {

            task.ContinueWith(t =>
            {
                lock (locker)
                {
                    threadPool.TryRemove(key, out Task oldItem);

                    var item = queueByKey.Dequeue(key);
                    if (item != null)
                    {
                        bool ok = threadPool.TryAdd(key, task);
                        task.Start();
                    }
                }

            });

            lock (locker)
            {
                bool ok = threadPool.TryAdd(key, task);
                if (!ok)
                {
                    queueByKey.Enqueue(key, task);
                } else
                {
                    task.Start();
                }
            }
        }
    }
}
