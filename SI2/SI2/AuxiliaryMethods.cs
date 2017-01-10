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
            Console.WriteLine(name + ": ");

            return Console.ReadLine();
        }

        public static string GetVariable(string name, string instructions)
        {
            Console.WriteLine(name + "(" + instructions + "): ");

            return Console.ReadLine();
        }
    }
}
