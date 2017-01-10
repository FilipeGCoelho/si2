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

