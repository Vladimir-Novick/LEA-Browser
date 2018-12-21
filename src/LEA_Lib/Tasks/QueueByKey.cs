using System;
using System.Collections.Generic;
using System.Linq;

namespace LEA.Lib.Tasks
{
    /// <summary>
    ///   Represents a first-in, first-out collection of objects by specify key
    ///   Support multitheading operation
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class QueueByKey<TKey,TValue> where TKey : IEquatable<TKey>
    {

        private Object lockObject = new Object();

        private class QueueItem<T_Key,T_Value>
        {
            internal T_Key key { get; set; }
            internal double timestamp { get; set; }
            internal T_Value item { get; set; }
        }

        private static List<QueueItem<TKey,TValue>> queueItems = new List<QueueItem<TKey,TValue>>();

        private double getTimespan()
        {
            return (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
        }

        /// <summary>
        ///   Adds an object to the end of the Queue<T> by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Enqueue(TKey key,TValue obj){
            lock (lockObject)
            {
                QueueItem<TKey,TValue> itemValue = new QueueItem<TKey,TValue>()
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
        public TValue Dequeue(TKey key)
        {
            lock (lockObject)
            {
                var topItem = (from x in queueItems where x.key.Equals(key) select x)
                          ?.OrderBy(x => x.timestamp)?.FirstOrDefault();
                if (topItem != null)
                {
                    queueItems.Remove(topItem);
                    return topItem.item;
                }
            }
            return  default(TValue); 
        }

        public bool isExist(TKey key)
        {
            lock (lockObject)
            {
                var item = (from x in queueItems where x.key.Equals(key) select x)
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
