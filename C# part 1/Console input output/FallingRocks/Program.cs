using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FallingRocks
{
    class Program
    {
        static void Main()
        {
            do
            {
                Random rand = new Random();

                for (int i = 0; i < 79; i++)
                {
                    char symbol = (char)rand.Next(60, 160);

                    Random randColor = new Random();
                    int colorRand = randColor.Next(0, 10);

                    Console.ResetColor();

                    if (colorRand > 8)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write(symbol);
                    Thread.Sleep(1);   
                }
                Console.WriteLine();
                 
            } while (true);
        }
    }
}
