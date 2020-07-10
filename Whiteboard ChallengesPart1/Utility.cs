using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProblemSolvingProblems_1b
{
    class Utility
    {


        public static void ColorWriteLine(string msg, ConsoleColor color = ConsoleColor.Blue)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public static void ColorWrite(string msg, ConsoleColor color = ConsoleColor.Blue)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ResetColor();
        }

        public static void ColorAlternate(string msg, ConsoleColor color = ConsoleColor.Blue)
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Random rand = new Random((int)DateTime.Now.Ticks);
            int colorIndex = 0;
            for(int i = 0; i < msg.Length; i += 2)
            {
                colorIndex = rand.Next(colors.Length);

                if (i + 2 < msg.Length)
                {
                    ConsoleColor currentIndex = colors[colorIndex];
                    if(currentIndex == Console.BackgroundColor)
                    {
                        if (colorIndex >= colors.Length - 1)
                        colorIndex++;
                    }
                    ColorWrite(msg.Substring(i, 2), colors[colorIndex]);
                    colorIndex++;
                } 
                else
                {
                    ColorWrite(msg.Substring(i));
                    i = msg.Length;
                }
            }

        }


    }
}
