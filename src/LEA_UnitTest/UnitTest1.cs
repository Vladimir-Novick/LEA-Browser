using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LEA.Lib.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LEA_UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestQueueByKeyAsync()
        {
            const int countIterator = 5;
            const int threadCount = 5;

            List<Task> listTask = new List<Task>();
            Random random = new Random();

            QueueByKey<String, string> queueByKey = new QueueByKey<String, string>();
            for (int tk = 0; tk < threadCount; tk++)
            {
                int threadID = tk;
                var t = Task.Run(() =>
                {
                  
                    Thread.Sleep(random.Next(100, 2000));
                    for (int i = 0; i < countIterator; i++)
                    {
                        int iElement = 0;
                        var items = new List<int>();
                        string key = i.ToString();
                        while (items.Count < countIterator)
                        {
                            Task wait = Task.Delay(50);
                            wait.Wait();
                            while (items.Contains(iElement)) { iElement = random.Next(0, countIterator); }
                            items.Add(iElement);
                            queueByKey.Enqueue(key, iElement.ToString() + "/" + threadID.ToString());
                        }
                    }
                });
                listTask.Add(t);
            }

        

            Task.WaitAll(listTask.ToArray());

            string value;
          
            foreach (var item in queueByKey.Keys)
            {
              
                while ((value = queueByKey.Dequeue(item)) != null)
                {
                    Console.WriteLine($"{item} => {value}");
                }
                Console.WriteLine($"----------------------");

            }
        }

        [TestMethod]
        public void TestQueueByKey()
        {
            const int countIterator = 5;
            QueueByKey<String, string> queueByKey = new QueueByKey<String, string>();
            for (int i = 0; i < countIterator; i++)
            {
                string key = i.ToString();
                for (int iElement = 0; iElement < countIterator; iElement++)
                {
                    queueByKey.Enqueue(key, iElement.ToString());
                }
            }

            string value;
            int counter = 0;
            foreach ( var item in  queueByKey.Keys)
            {
                counter = 0;
                while ( (value = queueByKey.Dequeue(item)) != null)
                {
                    Console.WriteLine($"{item} => {value}");
                  
                    if (!value.Equals(counter.ToString())) throw new Exception("invalid value from Dequeue");
                    counter++;
                }
                Console.WriteLine($"----------------------");
                if (counter != countIterator) throw new Exception("Enqueue != Dequeue");
            }
        }
    }
}
