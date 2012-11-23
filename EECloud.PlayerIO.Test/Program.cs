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

            var d = PlayerIO.SimpleConnect("mn1-dcmasqopteseuzd4ict5w", "guest", "guest");
            Console.WriteLine(d.Token);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
