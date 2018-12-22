using System;
using LEA.Lib.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LEA_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
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
