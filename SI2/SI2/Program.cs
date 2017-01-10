using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodDB.Init();
            App.Init();
            App.Run();
        }
    }

    class App
    {
        private static Dictionary<string, OperationInfo> operations = new Dictionary<string, OperationInfo>();

        public static void Run()
        {
            Menu();
        }

        private static void Menu()
        {
            foreach (var current in operations)
            {
                Console.WriteLine(current.Key + '.' + current.Value.phrase);
            }
        }


        public static void Init()
        {
            operations.Add("e", new OperationInfo("Inserir, remover e actualizar informação de promoções", MethodDB.e_ef, MethodDB.e_ado_net));
            operations.Add("f", new OperationInfo("Inserir um aluguer com inserção de um cliente com dados completos", MethodDB.f_ef, MethodDB.f_ado_net));
            operations.Add("g", new OperationInfo("Inserir um aluguer usando um cliente existente", MethodDB.g_ef, MethodDB.g_ado_net));
            operations.Add("h", new OperationInfo("Remover um Aluguer",MethodDB.h_ef,MethodDB.h_ado_net));
            operations.Add("i", new OperationInfo("Efectuar alterações de preçário", MethodDB.i_ef, MethodDB.i_ado_net));
            operations.Add("j", new OperationInfo("Listar todos os equipamentos livres, para um determinado tempo e tipo", MethodDB.j_ef, MethodDB.j_ado_net));
            operations.Add("k", new OperationInfo("Listar os equipamentos sem alugueres na última semana", MethodDB.k_ef, MethodDB.k_ado_net));
        }
    }


    public delegate void MethodDelegate();
    

    class OperationInfo
    {
        public string phrase;
        public MethodDelegate method_EF;
        public MethodDelegate method_ADO_NET;

        public OperationInfo(string s, MethodDelegate ef, MethodDelegate ado)
        {
            phrase = s;
            method_EF = ef;
            method_ADO_NET = ado;
        }
    }

    class MethodDB
    {
        private static readonly string ConnectionString = "user id=si2;password=si2;database=SI2;";
        private static readonly SqlConnection Connection = new SqlConnection(ConnectionString);

        public static void Init()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //Inserir, remover e actualizar informação de promoções
        public static void e_ef()
        {

        }

        public static void e_ef_insert()
        {
            new SqlCommand("Insert_Promocao", Connection).ExecuteNonQuery();            
        }

        public static void e_ef_remove()
        {
            new SqlCommand("Remove_Promocao", Connection).ExecuteNonQuery();                        
        }

        public static void e_ef_update()
        {
            new SqlCommand("Update_Promocao", Connection).ExecuteNonQuery();                        
        }

        public static void e_ado_net()
        {

        }

        //Inserir um aluguer com inserção de um cliente com dados completos
        public static void f_ef()
        {

        }

        public static void f_ado_net()
        {

        }

        //Inserir um aluguer usando um cliente existente;
        public static void g_ef()
        {

        }

        public static void g_ado_net()
        {

        }

        //Remover Aluguer
        public static void h_ef()
        {
            
        }

        public static void h_ado_net()
        {

        }

        //Efectuar alterações de preçário
        public static void i_ef()
        {

        }

        public static void i_ado_net()
        {

        }

        //Listar todos os equipamentos livres, para um determinado tempo e tipo
        public static void j_ef()
        {

        }

        public static void j_ado_net()
        {

        }

        //Listar todos os equipamentos livres, para um determinado tempo e tipo
        public static void k_ef()
        {

        }

        public static void k_ado_net()
        {

        }
    }


}
