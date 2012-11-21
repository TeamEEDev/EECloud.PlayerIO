using System;
using System.Diagnostics;

namespace EECloud.PlayerIO.Test
{
    class Program
    {
        private static void Main()
        {
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 1; i <= 100; i++)
            {
                var d = PlayerIO.SimpleConnect("mn1-dcmasqopteseuzd4ict5w", "guest", "guest");
                Console.WriteLine(d.Token);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
