﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Benchmark
    {
        public static void Compare()
        {
            
        }

        private void bench_e1()
        {
            DateTime inicio = DateTime.Parse("2016-06-06");
            DateTime fim = DateTime.Parse("2017-06-06");
            string descrição = "desc_benchmark";
            string tipo = "desconto";

            long init = DateTime.Now.Ticks;
                MethodDB.e_ef_insert(inicio, fim, descrição, tipo);
            long end = DateTime.Now.Ticks;

            long ef = end - init;


        }
    }
}