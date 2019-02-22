using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Client.Library
{
    public static class Utils
    {
        public class ConsoleReader
        {
            private readonly ConcurrentQueue<string> buffer = new ConcurrentQueue<string>();
            private readonly Thread readThread;
            private bool _shutdown = false;

            public ConsoleReader()
            {
                readThread = new Thread(() =>
                {
                    while (!_shutdown)
                    {
                        buffer.Enqueue(Console.ReadLine());
                    }
                });
            }

            public void Start()
            {
                readThread.Start();
            }

            public void Shutdown()
            {
                _shutdown = true;
                readThread.Interrupt();
            }

            public bool DataReceived()
            {
                return buffer.Count > 0;
            }

            public string Take()
            {
                buffer.TryDequeue(out var result);
                return result;
            }
        }

        public static class ConsoleColors
        {
            public static void PrintWithColor(string text, ConsoleColor color, bool withNewline = true)
            {
                Console.ForegroundColor = color;
                if (withNewline)
                    Console.WriteLine(text);
                else
                    Console.Write(text);
                Console.ResetColor();
            }
        }
    }
}