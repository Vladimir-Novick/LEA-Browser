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

        private static List<TaskStackItem> stack = new List<TaskStackItem>();

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

                    var item = (from x in stack where x.taskKey == key select x)
                       ?.OrderBy(x => x.timestamp)?.FirstOrDefault();
                    if (item != null)
                    {
                        stack.Remove(item);
                        bool ok = threadPool.TryAdd(item.taskKey, item.task);
                        item.task.Start();
                    }
                }

            });

            lock (locker)
            {
                bool ok = threadPool.TryAdd(key, task);
                if (!ok)
                {
                    TaskStackItem item = new TaskStackItem()
                    {
                        task = task,
                        taskKey = key,
                        timestamp = getTimespan()
                    };
                    stack.Add(item);
                } else
                {
                    task.Start();
                }
            }
        }
    }
}
