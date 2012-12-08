using System;
using System.Diagnostics;

namespace EECloud.PlayerIO.Test
{
    class Program
    {
        private static readonly Stopwatch Watch = new Stopwatch();

        private static void Main()
        {
            reConnect:
            Console.CursorVisible = false;
            Console.Write("Connecting...");
            Watch.Start();

            var client = PlayerIO.Connect("test-szf4hpjepkayftx3jm5wxa", "public", "testuser", null);
            var test = client.BigDB.LoadMyPlayerObject();
            var test2 = test.Item("02_Integer");
            Watch.Stop();

            Console.WriteLine(" Done!");
            Console.WriteLine("Token: " + client.Token + Environment.NewLine +
                              "Time elapsed: " + Watch.ElapsedMilliseconds);
            Console.CursorVisible = true;

            Console.ReadKey(true);
            Watch.Reset();
            Console.WriteLine();
            goto reConnect;
        }
    }
}
