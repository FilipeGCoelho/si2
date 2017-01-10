using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace SI2
{
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

        public static void e_ado_net()
        {
        }

        public static void e_ado_insert()
        {
            SqlCommand command = new SqlCommand("Insert_Promocao", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@dataInicio", AuxiliaryMethods.GetVariable("Data de Inicio"));
            command.Parameters.AddWithValue("@dataFim", AuxiliaryMethods.GetVariable("Data de Fim"));
            command.Parameters.AddWithValue("@descricao", AuxiliaryMethods.GetVariable("Descricao"));
            command.Parameters.AddWithValue("@tipo", AuxiliaryMethods.GetVariable("Tipo", "tempo ou desconto"));

            command.ExecuteNonQuery();
        }

        public static void e_ado_remove()
        {
            SqlCommand command = new SqlCommand("Remove_Promocao", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", AuxiliaryMethods.GetVariable("ID"));

            command.ExecuteNonQuery();
        }

        public static void e_ado_update()
        {
            SqlCommand command = new SqlCommand("Insert_Promocao", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", AuxiliaryMethods.GetVariable("ID"));
            command.Parameters.AddWithValue("@dataInicio", AuxiliaryMethods.GetVariable("Data de Inicio"));
            command.Parameters.AddWithValue("@dataFim", AuxiliaryMethods.GetVariable("Data de Fim"));
            command.Parameters.AddWithValue("@descricao", AuxiliaryMethods.GetVariable("Descricao"));
            command.Parameters.AddWithValue("@tipo", AuxiliaryMethods.GetVariable("Tipo", "tempo ou desconto"));

            command.ExecuteNonQuery();
        }

        //Inserir um aluguer com inserção de um cliente com dados completos
        public static void f_ef()
        {
        }

        public static void f_ado_net()
        {
            SqlCommand command = new SqlCommand("Insert_Aluguer_Sem_Cliente", Connection);
            command.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("-----Dados do Cliente-----\n");
            command.Parameters.AddWithValue("@nomeCliente", AuxiliaryMethods.GetVariable("Nome"));
            command.Parameters.AddWithValue("@nifCliente", AuxiliaryMethods.GetVariable("NIF"));
            command.Parameters.AddWithValue("@moradaCliente", AuxiliaryMethods.GetVariable("Morada"));

            Console.WriteLine("\n-----Dados do Aluguer-----\n");
            GetAluguerParameters(command);

            command.ExecuteNonQuery();
        }

        //Inserir um aluguer usando um cliente existente;
        public static void g_ef()
        {
        }

        public static void g_ado_net()
        {
            SqlCommand command = new SqlCommand("Insert_Aluguer_Com_Cliente", Connection);
            command.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("-----Dados do Cliente-----\n");
            command.Parameters.AddWithValue("@idCliente", AuxiliaryMethods.GetVariable("ID"));

            Console.WriteLine("\n-----Dados do Aluguer-----\n");
            GetAluguerParameters(command);
        }

        //Remover Aluguer
        public static void h_ef()
        {
        }

        public static void h_ado_net()
        {
            SqlCommand command = new SqlCommand("Remove_Aluguer", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@nSerie", AuxiliaryMethods.GetVariable("ID do Aluguer"));

            command.ExecuteNonQuery();

        }

        //Efectuar alterações de preçário
        public static void i_ef()
        {

        }

        public static void i_ado_net()
        {
            SqlCommand command = new SqlCommand("Add_Preco", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@idEquipamento", AuxiliaryMethods.GetVariable("ID do Equipamento"));
            command.Parameters.AddWithValue("@validade", AuxiliaryMethods.GetVariable("Validade"));
            command.Parameters.AddWithValue("@valor", AuxiliaryMethods.GetVariable("Valor"));

            command.ExecuteNonQuery();
        }

        //Listar todos os equipamentos livres, para um determinado tempo e tipo
        public static void j_ef()
        {
        }

        public static void j_ado_net()
        {
            SqlCommand command = new SqlCommand("ListEquipamentosLivres", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@tipo", AuxiliaryMethods.GetVariable("Tipo"));
            command.Parameters.AddWithValue("@tempo", AuxiliaryMethods.GetVariable("Duracao"));
            Console.Clear();

            using (SqlDataReader dr = command.ExecuteReader())
            {
                Console.WriteLine("Codigo\t| Descricao");
                Console.WriteLine("------------------");
                while (dr.Read())
                {
                    Console.WriteLine(dr["codigo"] + "\t" + "|" + dr["descricao"]);
                }
            }
            Console.ReadKey();

        }

        //Listar todos os equipamentos livres, para um determinado tempo e tipo
        public static void k_ef()
        {
        }

        public static void k_ado_net()
        {
            SqlCommand command = new SqlCommand("ListNaoUsadosSemana", Connection);
            command.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader dr = command.ExecuteReader())
            {
                Console.WriteLine("Codigo\t| Tipo\t\t| Descricao");
                Console.WriteLine("---------------------------");
                while (dr.Read())
                {
                    Console.WriteLine(dr["codigo"] + "\t|" + dr["tipo"] + "\t|" + dr["descricao"]);
                }
            }
            Console.ReadKey();
        }


        //auxiliar methods ---------------------------------------------

        private static void GetAluguerParameters(SqlCommand command)
        {
            command.Parameters.AddWithValue("@dataInicio", AuxiliaryMethods.GetVariable("Data de Inicio"));
            command.Parameters.AddWithValue("@dataFim", AuxiliaryMethods.GetVariable("Data de Fim"));
            command.Parameters.AddWithValue("@tipo", AuxiliaryMethods.GetVariable("Duracao"));
            command.Parameters.AddWithValue("@preco", AuxiliaryMethods.GetVariable("Preco"));
            command.Parameters.AddWithValue("@nEmpregado", AuxiliaryMethods.GetVariable("Numero do Empregado"));
        }


    }
}