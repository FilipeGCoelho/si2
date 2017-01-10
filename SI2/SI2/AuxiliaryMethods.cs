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
            Console.Write(name + ": ");

            return Console.ReadLine();
        }

        public static string GetVariable(string name, string instructions)
        {
            Console.Write(name + "(" + instructions + "): ");

            return Console.ReadLine();
        }
    }
}
