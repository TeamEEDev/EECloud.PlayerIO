using System;
using System.Diagnostics;

namespace EECloud.PlayerIO.Test
{
    class Program
    {
        private static readonly Stopwatch Watch = new Stopwatch();
        private static long TotalElapsedMilliseconds;

        private static void Main()
        {
            do
            {
                Console.CursorVisible = false;
                Console.Write("Testing... (Start time: " + DateTime.Now.ToString("G") + ")");


                // Connecting...
                Watch.Start();
                var client = PlayerIO.Connect("test-szf4hpjepkayftx3jm5wxa", "public", "testuser");
                Watch.Stop();
                WriteElapsedMilliseconds("Connected");

                // Loading a BigDB PlayerData item...
                Watch.Restart();
                var playerObject = client.BigDB.LoadMyPlayerObject();
                var item = playerObject.Item("11_Object");
                Watch.Stop();
                WriteElapsedMilliseconds("Loaded a BigDB PlayerData item");


                Console.WriteLine(Environment.NewLine +
                                  "Done! Total time elapsed: " + TotalElapsedMilliseconds + "ms");
                TotalElapsedMilliseconds = 0;

                Console.CursorVisible = true;
                Console.ReadKey(true);
                Console.WriteLine();
                Watch.Reset();
            } while (true);
        }

        private static void WriteElapsedMilliseconds(string cause)
        {
            Console.Write(Environment.NewLine +
                          "   " + cause + ": " + new string('.', Console.BufferWidth - cause.Length - Watch.ElapsedMilliseconds.ToString(Config.InvariantCulture).Length - 11) + " " +
                          Watch.ElapsedMilliseconds + "ms");
            TotalElapsedMilliseconds += Watch.ElapsedMilliseconds;
        }
    }
}
