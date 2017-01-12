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
            bench_e2();
            bench_e3();

//            bench_f();
//            bench_g();
        }

        private static void bench_e1()
        {
            string inicio = "2016-06-06";
            string fim = "2017-06-06";
            string descrição = "desc_benchmark";
            string tipo = "desconto";
            int id;

            long init = DateTime.Now.Ticks;
                MethodDB.e_ef_insert(DateTime.Parse(inicio), DateTime.Parse(fim), descrição, tipo);
            long end = DateTime.Now.Ticks;

            long ef = end - init;

            id = MethodDB.DB.Promocao1.First(p => p.dataInicio.ToString() == inicio && p.dataFim.ToString() == fim && p.descricao == descrição && p.tipo == tipo).id;
            MethodDB.e_ef_remove(id);

            init = DateTime.Now.Ticks;
                MethodDB.e_ado_insert(inicio, fim, descrição, tipo);
            end = DateTime.Now.Ticks;

            long ado = end - init;

            id = MethodDB.DB.Promocao1.First(p => p.dataInicio.ToString() == inicio && p.dataFim.ToString() == fim && p.descricao == descrição && p.tipo == tipo).id;
            MethodDB.e_ef_remove(id);

            PrintDiff(dic["e1"].phrase, ef, ado);
        }

        private static void bench_e2()
        {
            string inicio = "2016-06-06";
            string fim = "2017-06-06";
            string descrição = "desc_benchmark";
            string tipo = "desconto";
            int id;

            MethodDB.DB.Insert_Promocao(DateTime.Parse(inicio), DateTime.Parse(fim), descrição, tipo);
            id = MethodDB.DB.Promocao1.First(p => p.dataInicio.ToString() == inicio && p.dataFim.ToString() == fim && p.descricao == descrição && p.tipo == tipo).id;

            long init = DateTime.Now.Ticks;
            MethodDB.e_ef_remove(id);
            long end = DateTime.Now.Ticks;

            long ef = end - init;

            MethodDB.DB.Insert_Promocao(DateTime.Parse(inicio), DateTime.Parse(fim), descrição, tipo);
            id = MethodDB.DB.Promocao1.First(p => p.dataInicio.ToString() == inicio && p.dataFim.ToString() == fim && p.descricao == descrição && p.tipo == tipo).id;

            init = DateTime.Now.Ticks;
            MethodDB.e_ado_remove(id);
            end = DateTime.Now.Ticks;

            long ado = end - init;

            PrintDiff(dic["e2"].phrase, ef, ado);
        }

        private static void bench_e3()
        {
            string inicio = "2016-06-06";
            string fim = "2017-06-06";
            string descrição = "desc_benchmark";
            string tipo = "desconto";
            int id;

            MethodDB.DB.Insert_Promocao(DateTime.Parse(inicio), DateTime.Parse(fim), descrição, tipo);
            id = MethodDB.DB.Promocao1.First(p => p.dataInicio.ToString() == inicio && p.dataFim.ToString() == fim && p.descricao == descrição && p.tipo == tipo).id;

            long init = DateTime.Now.Ticks;
            MethodDB.e_ef_update(id,new DateTime(2016,01,01), new DateTime(2017, 01, 01), "teste", "tempo");
            long end = DateTime.Now.Ticks;

            long ef = end - init;

            init = DateTime.Now.Ticks;
            MethodDB.e_ado_update(id, new DateTime(2016, 07, 01), new DateTime(2017, 01, 05), "teste", "tempo");
            end = DateTime.Now.Ticks;

            MethodDB.DB.Remove_Promocao(id);

            long ado = end - init;

            PrintDiff(dic["e3"].phrase, ef, ado);
        }

        private static void bench_f()
        {
            string inicio = "2016-06-06";
            string fim = "2017-06-06";
            string descrição = "desc_benchmark";
            int tipo = 1;
            int id;
            string nome = "xxxxxxxx";
            decimal nif = 197758642;
            string morada = "yyyyyyyyyyyy";
            decimal preco = 321313.12M;
            int empregado = 1;
            int nserie;
            int ncliente;

            long init = DateTime.Now.Ticks;
            MethodDB.f_ef(nome, nif, morada, DateTime.Parse(inicio), DateTime.Parse(fim), tipo, preco, 1);
            long end = DateTime.Now.Ticks;

            long ef = end - init;

            ncliente = MethodDB.DB.Cliente1.First(p => p.nif == nif && p.nome == nome).numero;
            nserie = MethodDB.DB.Aluguer1.First( p=> p.nCliente == ncliente).nSerie;
            MethodDB.DB.Remove_Aluguer(nserie);
            MethodDB.DB.Remove_Cliente(ncliente);

            init = DateTime.Now.Ticks;
            MethodDB.f_ado_net(nome, nif, morada, DateTime.Parse(inicio), DateTime.Parse(fim), tipo, preco, 1);
            end = DateTime.Now.Ticks;

            ncliente = MethodDB.DB.Cliente1.First(p => p.nif == nif && p.nome == nome).numero;
            nserie = MethodDB.DB.Aluguer1.First(p => p.nCliente == ncliente).nSerie;
            MethodDB.DB.Remove_Aluguer(nserie);
            MethodDB.DB.Remove_Cliente(ncliente);

            long ado = end - init;

            PrintDiff(dic["f"].phrase, ef, ado);
        }

        private static void bench_g()
        {
            string inicio = "2016-06-06";
            string fim = "2017-06-06";
            string descrição = "desc_benchmark";
            int tipo = 1;
            string nome = "xxxxxxxx";
            decimal nif = 32.3M;
            string morada = "yyyyyyyyyyyy";
            decimal preco = 321313.12M;
            int empregado = 1;
            int nserie;
            int ncliente;

            MethodDB.DB.Insert_Cliente(nome, nif, morada);
            ncliente = MethodDB.DB.Cliente1.First(p => p.nif == nif && p.nome == nome).numero;

            long init = DateTime.Now.Ticks;
            MethodDB.g_ef(ncliente, DateTime.Parse(inicio), DateTime.Parse(fim), tipo, preco, 1);
            long end = DateTime.Now.Ticks;

            long ef = end - init;

            nserie = MethodDB.DB.Aluguer1.First(p => p.nCliente == ncliente).nSerie;
            MethodDB.DB.Remove_Aluguer(nserie);

            init = DateTime.Now.Ticks;
            MethodDB.g_ado_net(ncliente, DateTime.Parse(inicio), DateTime.Parse(fim), tipo, preco, 1);
            end = DateTime.Now.Ticks;

            nserie = MethodDB.DB.Aluguer1.First(p => p.nCliente == ncliente).nSerie;
            MethodDB.DB.Remove_Aluguer(nserie);
            MethodDB.DB.Remove_Cliente(ncliente);

            long ado = end - init;

            PrintDiff(dic["g"].phrase, ef, ado);
        }

        private static void bench_h()
        {
            string inicio = "2016-06-06";
            string fim = "2017-06-06";
            string descrição = "desc_benchmark";
            int tipo = 1;
            string nome = "xxxxxxxx";
            decimal nif = 32.3M;
            string morada = "yyyyyyyyyyyy";
            decimal preco = 321313.12M;
            int empregado = 1;
            int nserie;
            int ncliente;

            MethodDB.DB.Insert_Cliente(nome, nif, morada);
            ncliente = MethodDB.DB.Cliente1.First(p => p.nif == nif && p.nome == nome).numero;

            long init = DateTime.Now.Ticks;
            MethodDB.g_ef(ncliente, DateTime.Parse(inicio), DateTime.Parse(fim), tipo, preco, 1);
            long end = DateTime.Now.Ticks;

            long ef = end - init;

            nserie = MethodDB.DB.Aluguer1.First(p => p.nCliente == ncliente).nSerie;
            MethodDB.DB.Remove_Aluguer(nserie);

            init = DateTime.Now.Ticks;
            MethodDB.g_ado_net(ncliente, DateTime.Parse(inicio), DateTime.Parse(fim), tipo, preco, 1);
            end = DateTime.Now.Ticks;

            nserie = MethodDB.DB.Aluguer1.First(p => p.nCliente == ncliente).nSerie;
            MethodDB.DB.Remove_Aluguer(nserie);
            MethodDB.DB.Remove_Cliente(ncliente);

            long ado = end - init;

            PrintDiff(dic["g"].phrase, ef, ado);
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
