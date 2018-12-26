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
    public class TaskPool<TTask> : IDisposable where TTask : Task

    {

        private ConcurrentDictionary<String, TTask> threadPool = new ConcurrentDictionary<String, TTask>();

        private readonly Object locker = new Object();

        public QueueByKey<String, TTask> queueByKey = new QueueByKey<String, TTask>();

        private double getTimespan()
        {
            return (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
        }
        /// <summary>
        ///   Add asynchronous task without queue 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="task"></param>
        public void Push(String key, TTask task)
        {
            PushToQueue(key.ToString() + getTimespan().ToString(), task);
        }
        /// <summary>
        ///   Add asynchronous task to queue by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="task"></param>
        public void PushToQueue(String key, TTask task)
        {
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                lock (locker)
                {
                    ExtractAndRunTask(key);
                }

            });

            lock (locker)
            {
                queueByKey.Enqueue(key, task);
                ExtractAndRunTask(key);
            }
        }

        private void ExtractAndRunTask(string key)
        {
            threadPool.TryRemove(key, out TTask oldItem);

            oldItem?.Dispose();

            var item = queueByKey.Dequeue(key);
            if (item != null)
            {
                try
                {
                    if (!(item.IsCompleted || item.IsCanceled || item.IsFaulted))
                    {
                        item.Start();
                        bool ok = threadPool.TryAdd(key, item);
                    }
                    else
                    {
                        ExtractAndRunTask(key);
                    }
                }
                catch (Exception ex)
                {
                    ExtractAndRunTask(key);
                }

            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    lock (locker)
                    {
                        queueByKey.Clear();
                    }
                        foreach (var item in threadPool)
                    {
                        try
                        {
                            item.Value.Dispose();
                        }
                        catch (Exception) { }
                    }
                }


                threadPool = null;

                disposedValue = true;
            }
        }

        ~TaskPool()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
