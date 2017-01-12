using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class AuxiliaryMethods
    {
        public static string GetVariable(string name)
        {
            Console.Write(name + ": ");

            string s = Console.ReadLine();
            return s == "" ? null : s;
        }

        public static string GetVariable(string name, string instructions)
        {
            Console.Write(name + "(" + instructions + "): ");

            string s = Console.ReadLine();
            return s == "" ? null : s;
        }

        public static int GetVariableInt(string name, string instructions)
        {
            int answer = -1;

            while(answer<0)
            {
                try
                {
                    Console.WriteLine(name + "(" + instructions + "): ");
                    answer = Int32.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: No answer given\n");
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid number, make sure you're typing a number\n");
                }
            }

            return answer;
        }

        public static int GetVariableInt(string name)
        {
            int answer = -1;

            while (answer < 0)
            {
                try
                {
                    Console.WriteLine(name + ": ");
                    answer = Int32.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: No answer given\n");
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid number, make sure you're typing a number\n");
                }
            }

            return answer;
        }

        public static decimal GetVariableDecimal(string name, string instructions)
        {
            decimal answer = -1;

            while (answer < 0)
            {
                try
                {
                    Console.WriteLine(name + "(" + instructions + "): ");
                    answer = decimal.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: No answer given\n");
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid number, make sure you're typing a number\n");
                }
            }

            return answer;
        }

        public static decimal GetVariableDecimal(string name)
        {
            decimal answer = -1;

            while (answer < 0)
            {
                try
                {
                    Console.WriteLine(name + ": ");
                    answer = decimal.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: No answer given\n");
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid number, make sure you're typing a number\n");
                }
            }

            return answer;
        }

        public static DateTime GetVariableDate(string name, string instructions)
        {
            DateTime answer = DateTime.Parse("1975-01-01");

            while (answer == DateTime.Parse("1975-01-01"))
            {
                try
                {
                    Console.WriteLine(name + "(" + instructions + "): ");
                    answer = DateTime.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: No answer given\n");
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid date, make sure you're typing a YYYY-MM-dd\n");
                }
            }

            return answer;
        }

        public static DateTime GetVariableDate(string name)
        {
            DateTime answer = DateTime.Parse("1975-01-01");

            while (answer == DateTime.Parse("1975-01-01"))
            {
                try
                {
                    Console.WriteLine(name + ": ");
                    answer = DateTime.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: No answer given\n");
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid date, make sure you're typing a YYYY-MM-dd\n");
                }
            }

            return answer;
        }

        public static void ListResult <T> (List<T> list, Func<T,string> func)
        {
            Console.Clear();

            foreach (var o in list)
            {
                Console.WriteLine(func(o));
            }

            Console.WriteLine("\n\nto exit, press any key...");
            Console.ReadKey();
        }
    }
}
