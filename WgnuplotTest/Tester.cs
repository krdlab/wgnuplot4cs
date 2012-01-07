using System;
using System.Collections.Generic;
using System.Text;
using KrdLab.Tools.Wgnuplot;
using System.Reflection;

namespace KrdLab.Test
{
    class Tester
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Type tester = typeof(Tester);
            MethodInfo[] methods = tester.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            foreach (MethodInfo method in methods)
            {
                if (!method.Name.StartsWith("Test"))
                {
                    continue;
                }
                using (Wgnuplot plot = new Wgnuplot(@".\gnuplot\bin\pgnuplot.exe"))
                {
                    System.Console.WriteLine("Method.Name = " + method.Name);
                    System.Console.Write("exit? [y/n]: ");
                    method.Invoke(null, new object[] { plot });
                    ConsoleKeyInfo key = System.Console.ReadKey();
                    System.Console.WriteLine();
                    if (key.Key == ConsoleKey.Y)
                    {
                        break;
                    }
                }
            }
        }

        static void Test01(Wgnuplot plot)
        {
            plot.Send("splot x**2 + y**2");
        }
    }
}
