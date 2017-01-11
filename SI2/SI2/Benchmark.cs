using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Benchmark
    {
        static Dictionary<string, OperationInfo> dic = Program.MappingFunctions();

        public static void Compare()
        {
            bench_e1();
        }

        private static void bench_e1()
        {
            string inicio = "2016-06-06";
            string fim = "2017-06-06";
            string descrição = "desc_benchmark";
            string tipo = "desconto";

            long init = DateTime.Now.Ticks;
                MethodDB.e_ef_insert(DateTime.Parse(inicio), DateTime.Parse(fim), descrição, tipo);
            long end = DateTime.Now.Ticks;

            long ef = end - init;

            init = DateTime.Now.Ticks;
                MethodDB.e_ado_insert(inicio, fim, descrição, tipo);
            end = DateTime.Now.Ticks;

            long ado = end - init;

            PrintDiff(dic["e1"].phrase, ef, ado);
        }

        private static void PrintDiff(string desc, long ef, long ado)
        {
            double cmp;

            if (ef > ado)
                cmp = (float)ado/ef*100;
            else
                cmp = (float)ef/ado*100;

            Console.Clear();
            Console.WriteLine("Tested operation: {0}\n\nFastest: " + (ef-ado > 0 ? "ADO-NET " : "EF ")  + "taking {1}% of the loser's time" ,desc, cmp);   
            Console.WriteLine("\n\n\npress any key to exit...");
            Console.ReadKey();
        }
    }
}
