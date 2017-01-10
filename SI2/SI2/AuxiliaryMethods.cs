using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class AuxiliaryMethods
    {
        public static string GetVariable(string name)
        {
            Console.Clear();
            Console.WriteLine("REQUESTED VALUE:\n\n" + name + ": ");

            return Console.ReadLine();
        }
    }
}
