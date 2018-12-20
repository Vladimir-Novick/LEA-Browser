using System;
using System.Collections.Generic;
using System.Linq;

namespace LEA.Lib.Tasks
{
    /// <summary>
    ///   Represents a first-in, first-out collection of objects by specify key
    ///   Support multitheading operation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueByKey<T> 
    {

        private Object lockObject = new Object();

        private class QueueItem<T_Object>
        {
            internal String key { get; set; }
            internal double timestamp { get; set; }
            internal T_Object item { get; set; }
        }

        private static List<QueueItem<T>> queueItems = new List<QueueItem<T>>();

        private double getTimespan()
        {
            return (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
        }

        /// <summary>
        ///   Adds an object to the end of the Queue<T> by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Enqueue(String key,T obj){
            lock (lockObject)
            {
                QueueItem<T> itemValue = new QueueItem<T>()
                {
                    key = key,
                    timestamp = getTimespan(),
                    item = obj
                };
                queueItems.Add(itemValue);
            }
        }



        /// <summary>
        ///   Removes and returns the object at the beginning of the Queue<T> by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Dequeue(String key)
        {
            lock (lockObject)
            {
                var topItem = (from x in queueItems where x.key == key select x)
                          ?.OrderBy(x => x.timestamp)?.FirstOrDefault();
                if (topItem != null)
                {
                    queueItems.Remove(topItem);
                    return topItem.item;
                }
            }
            return  default(T); 
        }

        public bool isExist(String key)
        {
            lock (lockObject)
            {
                var item = (from x in queueItems where x.key == key select x)
                  ?.OrderBy(x => x.timestamp)?.FirstOrDefault();

                if (item == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
