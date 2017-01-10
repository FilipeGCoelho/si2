using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
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
            App.ShutDown();
        }
    }

    class App
    {
        private static Dictionary<string, OperationInfo> operations = new Dictionary<string, OperationInfo>();

        public static void Run()
        {
            while (true)
            {
                Menu();
                Listen();
            }
        }

        private static void Menu()
        {
            Console.Clear();
            foreach (var current in operations)
            {
                Console.WriteLine(current.Key + ".  " + current.Value.phrase);
            }

            Console.WriteLine("\n0.  Exit");
        }

        private static void Listen()
        {
            //read answer
            string answer_command = Console.ReadLine();

            //check if answer is valid
            OperationInfo opi;

            if(operations.TryGetValue(answer_command,out opi))
            {
                //choose the pretended mode (EF or ADO)
                Console.Clear();
                Console.WriteLine("Which mode do you want: \n1.Entity Framework (EF)\n2.ADO.NET\n\n3.Exit");

                //read answer
                string answer_mode = Console.ReadLine();

                if (answer_mode == "1")
                    opi.method_EF();

                else if (answer_mode == "2")
                    opi.method_ADO_NET();

                else if (answer_mode == "3")
                    return;

                else
                    ErrorMessage();

                return;
            }

            if (answer_command == "0")
                ShutDown();

            ErrorMessage();
            return;
        }

        private static void ErrorMessage()
        {
            Console.WriteLine("Invalid answer");
            Thread.Sleep(1500);
        }

        public static void ShutDown()
        {
            Console.Clear();
            Console.WriteLine("leaving ...");
            Thread.Sleep(1500);
            Environment.Exit(0);
        }
          
        public static void Init()
        {
            operations.Add("e1", new OperationInfo("Inserir informação de promoções", MethodDB.e1_ef, MethodDB.e1_ado_net));
            operations.Add("e2", new OperationInfo("Remover informação de promoções", MethodDB.e2_ef, MethodDB.e2_ado_net));
            operations.Add("e3", new OperationInfo("Actualizar informação de promoções", MethodDB.e3_ef, MethodDB.e3_ado_net));

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
        public static void e_ado_net()

        public static void e_ado_insert()
            SqlCommand command = new SqlCommand("Insert_Promocao", Connection);
            command.CommandType = CommandType.StoredProcedure;
            DateTime bixo= new DateTime(1999, 99, 99);
//          @dataInicio DATE,
//	        @dataFim DATE,
//	        @descricao VARCHAR(128),
//	        @tipo VARCHAR(8)

            SqlParameter dataInicio = new SqlParameter("@dataInicio", SqlDbType.Date);
            dataInicio.Value = bixo;
            command.Parameters.Add(dataInicio);
            SqlParameter dataFim = new SqlParameter("@dataFim", SqlDbType.Date);
            SqlParameter descricao = new SqlParameter("@descricao", SqlDbType.VarChar);
            SqlParameter tipo = new SqlParameter("@tipo", SqlDbType.VarChar);
        public static void e_ado_remove()
            new SqlCommand("Remove_Promocao", Connection).ExecuteNonQuery();                        
        public static void e_ado_update()
        {
            new SqlCommand("Update_Promocao", Connection).ExecuteNonQuery();                        
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
