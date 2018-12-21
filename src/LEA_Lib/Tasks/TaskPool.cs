using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LEA.Lib.Tasks
{
    /*
     * 
     Copyright (C) 2018 by Vladimir Novick http://www.linkedin.com/in/vladimirnovick , 

     vlad.novick@gmail.com , http://www.sgcombo.com , https://github.com/Vladimir-Novick	

     * 
    */
    public class TaskPool<TTask> where TTask : Task 
                                            
    {

        private  ConcurrentDictionary<String, TTask> threadPool = new ConcurrentDictionary<String, TTask>();

        private readonly Object locker = new Object();

        private  QueueByKey<String, TTask> queueByKey = new QueueByKey<String, TTask>();

        private  double getTimespan()
        {
            return (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
        }
        /// <summary>
        ///   Add asynchronous task without queue 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="task"></param>
        public  void Push(String key, TTask task)
        {
            PushToQueue(key.ToString() + getTimespan().ToString(), task);
        }
        /// <summary>
        ///   Add asynchronous task to queue by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="task"></param>
        public  void PushToQueue(String key, TTask task)
        {

            task.ContinueWith(t =>
            {
                lock (locker)
                {
                    threadPool.TryRemove(key, out TTask oldItem);

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
