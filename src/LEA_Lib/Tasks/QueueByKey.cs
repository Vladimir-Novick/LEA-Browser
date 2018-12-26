using System;
using System.Collections.Generic;
using System.Linq;

namespace LEA.Lib.Tasks
{

    /*
    * 
    *  Copyright (C) 2018 by Vladimir Novick http://www.linkedin.com/in/vladimirnovick , 
    *
    * vlad.novick@gmail.com , http://www.sgcombo.com , https://github.com/Vladimir-Novick	
    *
    * 
    */


    /// <summary>
    ///   Represents a first-in, first-out collection of objects by specify key
    ///   Support multitheading operation
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class QueueByKey<TKey, TValue> where TKey : IEquatable<TKey>
    {

        private Object lockObject = new Object();

        private class QueueItem<T_Key, T_Value>
        {
            internal T_Key key { get; set; }
            internal double timestamp { get; set; }
            internal T_Value item { get; set; }
        }

        private List<QueueItem<TKey, TValue>> queueItems = new List<QueueItem<TKey, TValue>>();
        /// <summary>
        ///  get keys 
        /// </summary>
        public List<TKey> Keys
        {
            get
            {
                List<TKey> rez;

                lock (lockObject)
                {
                    rez = (from p in queueItems select p.key).Distinct().ToList();
                }
                return rez;
            }
        }
        /// <summary>
        ///   Clear all
        /// </summary>
        public void Clear()
        {
            lock (lockObject)
            {
                queueItems.Clear();
            }
        }

        /// <summary>
        ///   Clear all items by key
        /// </summary>
        /// <param name="key"></param>
        public void Clear(TKey key)
        {
            lock (lockObject)
            {
                var rez = from p in queueItems where p.key.Equals(key) select p;
                foreach (var item in rez)
                {
                    queueItems.Remove(item);
                }
            }
        }

        /// <summary>
        ///   Returns the object at the beginning by TKye of the Queue without removing it.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue Peek(TKey key)
        {
            lock (lockObject)
            {
                var topItem = (from x in queueItems
                               where x.key.Equals(key)
                               orderby x.timestamp
                               select x)
                         ?.FirstOrDefault();
                if (topItem != null)
                {
                    return topItem.item;
                }
            }
            return default(TValue);
        }


        private double getTimespan()
        {
            return (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
        }

        /// <summary>
        ///   Adds an object to the end of the Queue<T> by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Enqueue(TKey key, TValue obj)
        {
            lock (lockObject)
            {
                QueueItem<TKey, TValue> itemValue = new QueueItem<TKey, TValue>()
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
                var topItem = (from x in queueItems
                               where x.key.Equals(key)
                               orderby x.timestamp
                               select x)
                          ?.FirstOrDefault();
                if (topItem != null)
                {
                    queueItems.Remove(topItem);
                    return topItem.item;
                }
            }
            return default(TValue);
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
