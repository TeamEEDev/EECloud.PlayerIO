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

            var client = PlayerIO.QuickConnect.SimpleConnect("everybody-edits-su9rn58o40itdbnw69plyw", "guest", "guest");
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
