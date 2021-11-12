using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PanelProducer producer1 = new PanelProducer {PanelAmount=5};
            Thread thread1 = new Thread(new ThreadStart(producer1.Run)); //Methoden Verweis -> ohne Klammern
            thread1.Start();

            // thread1.Join(); //wartet bis Thread1 fertig ist -> dann wird Thread2 gestartet

            PanelProducer producer2 = new PanelProducer {PanelAmount = 10};
            Thread thread2 = new Thread(new ThreadStart(producer2.Run)); //Methoden Verweis -> ohne Klammern "Wenn Thread gestartet, soll diese Methode aufgerufen werden"
            thread2.Start();

            Thread.Sleep(2000);
            producer2.ShouldStop = true;

            Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Anonymer Producer: Panel {i} produced.");
                    Thread.Sleep(500);
                    // if (i == 2)
                    //    throw new Exception("Fehler im Producer");
                }
            });

            Task.Run(() => new PanelProducer { PanelAmount = 3 }.Run());

        }
    }
}
