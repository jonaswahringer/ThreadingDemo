using System;
using System.Threading;

namespace ThreadingDemo
{
    public class PanelProducer
    {
        private static int TotalPanelAmount;
        private static object totalAmountLock = new object(); //statisches lock object für lock

        public int PanelAmount { get; set; }
        public bool ShouldStop { get; set; }

        public void Run()
        {
            //lock (this)
            //{
            for (int i = 0; i < PanelAmount && !ShouldStop; i++)
            {
                Console.WriteLine($"Panel {i} produced.");
                // gemeinsam genutzte Resource
                lock(totalAmountLock) //Mutual exclusion für statisches lock object
                {
                    TotalPanelAmount++;
                    Console.WriteLine($"Total Amount of {TotalPanelAmount} produced.");
                }
                Thread.Sleep(1500);
            }
            //}
        }
    }
}
