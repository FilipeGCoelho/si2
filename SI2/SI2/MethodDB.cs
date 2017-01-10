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

            command.Parameters.AddWithValue("@dataInicio","1999-01-01");
            command.Parameters.AddWithValue("@dataFim","1999-01-02");
            command.Parameters.AddWithValue("@descricao","tralha");
            command.Parameters.AddWithValue("@tipo","tempo");
            command.ExecuteNonQuery();

//            command.Parameters.Add(new SqlParameter("@dataFim", SqlDbType.Date).Value = "1999-01-01");
//            command.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar).Value = "tralha");
//            command.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar).Value = "tipotralha");
        }

        public static void e_ado_remove()
        {
            new SqlCommand("Remove_Promocao", Connection).ExecuteNonQuery();
        }

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

