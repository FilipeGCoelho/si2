using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using SI2.SQL;


namespace SI2
{
    class MethodDB
    {
        private static readonly string ConnectionString = "user id=si2;password=si2;database=SI2;";
        public static readonly SqlConnection Connection = new SqlConnection(ConnectionString);
        
        private static SI2Entities1 DB = new SI2Entities1();

//        public static String GetEntityString()
//        {
//
//            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
//            sqlBuilder.DataSource = "DESKTOP - EHJ4FO6";
//            sqlBuilder.InitialCatalog = "SI2";
//
//            EntityConnectionStringBuilder entityConnectionBuilder = new EntityConnectionStringBuilder();
//
//            entityConnectionBuilder.Provider = sqlBuilder.ToString();
//            
//            return entityConnection.ToString();
//        }

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

        public static void e_ef_insert()
        {
            DateTime inicio = DateTime.Parse(AuxiliaryMethods.GetVariable("Data de Inicio"));
            DateTime fim = DateTime.Parse(AuxiliaryMethods.GetVariable("Data de Fim"));
            string descricao = AuxiliaryMethods.GetVariable("Descricao");
            string tipo = AuxiliaryMethods.GetVariable("Tipo", "tempo ou desconto");

            DB.Insert_Promocao(inicio, fim, descricao, tipo);
        }

        public static void e_ef_insert(DateTime inicio, DateTime fim, string descricao, string tipo)
        {
            DB.Insert_Promocao(inicio, fim, descricao, tipo);
        }



        public static void e_ef_remove()
        {
            int id = AuxiliaryMethods.GetVariableInt("Id");

            DB.Remove_Promocao(id);
        }

        public static void e_ef_remove(int id)
        {
            DB.Remove_Promocao(id);
        }

        public static void e_ef_update()
        {
            int id = AuxiliaryMethods.GetVariableInt("Id");
            DateTime inicio = DateTime.Parse(AuxiliaryMethods.GetVariable("Data de Inicio"));
            DateTime fim = DateTime.Parse(AuxiliaryMethods.GetVariable("Data de Fim"));
            string descricao = AuxiliaryMethods.GetVariable("Descricao");
            string tipo = AuxiliaryMethods.GetVariable("Tipo", "tempo ou desconto");

            DB.Update_Promocao(id, inicio, fim, descricao, tipo);
        }

        public static void e_ef_update(int id, DateTime inicio, DateTime fim, string descricao, string tipo)
        {
            DB.Update_Promocao(id, inicio, fim, descricao, tipo);
        }

        public static void e_ado_insert()
        {
            SqlCommand command = new SqlCommand("Insert_Promocao", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@dataInicio", AuxiliaryMethods.GetVariableDate("Data de Inicio"));
            command.Parameters.AddWithValue("@dataFim", AuxiliaryMethods.GetVariableDate("Data de Fim"));
            command.Parameters.AddWithValue("@descricao", AuxiliaryMethods.GetVariable("Descricao"));
            command.Parameters.AddWithValue("@tipo", AuxiliaryMethods.GetVariable("Tipo", "tempo ou desconto"));

            command.ExecuteNonQuery();
        }

        public static void e_ado_insert(string inicio, string fim, string descricao, string tipo)
        {
            SqlCommand command = new SqlCommand("Insert_Promocao", Connection);
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@dataInicio", inicio);
            command.Parameters.AddWithValue("@dataFim", fim);
            command.Parameters.AddWithValue("@descricao", descricao);
            command.Parameters.AddWithValue("@tipo", tipo);
            command.ExecuteNonQuery();
            
        }

        public static void e_ado_remove()
        {
            SqlCommand command = new SqlCommand("Remove_Promocao", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", AuxiliaryMethods.GetVariableInt("ID"));

            command.ExecuteNonQuery();
        }

        public static void e_ado_update()
        {
            SqlCommand command = new SqlCommand("Update_Promocao", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", AuxiliaryMethods.GetVariableInt("ID"));
            command.Parameters.AddWithValue("@dataInicio", AuxiliaryMethods.GetVariable("Data de Inicio"));
            command.Parameters.AddWithValue("@dataFim", AuxiliaryMethods.GetVariable("Data de Fim"));
            command.Parameters.AddWithValue("@descricao", AuxiliaryMethods.GetVariable("Descricao"));
            command.Parameters.AddWithValue("@tipo", AuxiliaryMethods.GetVariable("Tipo", "tempo ou desconto"));

            command.ExecuteNonQuery();
        }

        //Inserir um aluguer com inserção de um cliente com dados completos
        public static void f_ef()
        {
            string nome = AuxiliaryMethods.GetVariable("Nome cliente");
            decimal nif = AuxiliaryMethods.GetVariableDecimal("NIF","9 digitos");
            string morada = AuxiliaryMethods.GetVariable("morada cliente");

            DB.Insert_Cliente(nome, nif, morada);
            Console.WriteLine();

            int id = DB.Clientes
                .Where(p => p.nif == nif && p.nome == nome && p.morada == morada)
                .First().numero;

            DateTime inicio = DateTime.Parse(AuxiliaryMethods.GetVariable("Data de Inicio"));
            DateTime fim = DateTime.Parse(AuxiliaryMethods.GetVariable("Data de Fim"));
            int tipo = AuxiliaryMethods.GetVariableInt("Tipo", "Esperado um Numero");
            decimal preco = AuxiliaryMethods.GetVariableDecimal("preço", "formato decimal: UU.DD");
            int empregado = AuxiliaryMethods.GetVariableInt("empregado");

            DB.Insert_Aluguer_Com_Cliente(id, inicio, fim, tipo, preco, empregado);
        }

        public static void f_ef(string nome, decimal nif, string morada, DateTime inicio, DateTime fim, int tipo, decimal preco, int empregado)
        {
            DB.Insert_Cliente(nome, nif, morada);

            int id = DB.Clientes
                .Where(p => p.nif == nif && p.nome == nome && p.morada == morada)
                .First().numero;

            DB.Insert_Aluguer_Com_Cliente(id, inicio, fim, tipo, preco, empregado);
        }

        public static void f_ado_net()
        {
            SqlCommand command = new SqlCommand("Insert_Aluguer_Sem_Cliente", Connection);
            command.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("-----Dados do Cliente-----\n");
            command.Parameters.AddWithValue("@nomeCliente", AuxiliaryMethods.GetVariable("Nome"));
            command.Parameters.AddWithValue("@nifCliente", AuxiliaryMethods.GetVariableInt("NIF"));
            command.Parameters.AddWithValue("@moradaCliente", AuxiliaryMethods.GetVariable("Morada"));

            Console.WriteLine("\n-----Dados do Aluguer-----\n");
            GetAluguerParameters(command);

            command.ExecuteNonQuery();
        }

        //Inserir um aluguer usando um cliente existente;
        public static void g_ef()
        {
            int id = AuxiliaryMethods.GetVariableInt("Id do cliente");
            DateTime inicio = DateTime.Parse(AuxiliaryMethods.GetVariable("Data de Inicio"));
            DateTime fim = DateTime.Parse(AuxiliaryMethods.GetVariable("Data de Fim"));
            int tipo = AuxiliaryMethods.GetVariableInt("Tipo", "Esperado um Numero");
            decimal preco = AuxiliaryMethods.GetVariableDecimal("preço", "formato decimal: UU.DD");
            int empregado = AuxiliaryMethods.GetVariableInt("empregado");

            DB.Insert_Aluguer_Com_Cliente(id, inicio, fim, tipo, preco, empregado);
        }

        public static void g_ef(int id, DateTime inicio, DateTime fim, int tipo, decimal preco, int empregado)
        {
            DB.Insert_Aluguer_Com_Cliente(id, inicio, fim, tipo, preco, empregado);
        }

        public static void g_ado_net()
        {
            SqlCommand command = new SqlCommand("Insert_Aluguer_Com_Cliente", Connection);
            command.CommandType = CommandType.StoredProcedure;

            Console.WriteLine("-----Dados do Cliente-----\n");
            command.Parameters.AddWithValue("@idCliente", AuxiliaryMethods.GetVariableInt("ID"));

            Console.WriteLine("\n-----Dados do Aluguer-----\n");
            GetAluguerParameters(command);
        }

        //Remover Aluguer
        public static void h_ef()
        {
            int nSerie = AuxiliaryMethods.GetVariableInt("Numero de serie", "id do aluguer");

            DB.Remove_Aluguer(nSerie);
        }

        public static void h_ef(int nSerie)
        { 
            DB.Remove_Aluguer(nSerie);
        }

        public static void h_ado_net()
        {
            SqlCommand command = new SqlCommand("Remove_Aluguer", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@nSerie", AuxiliaryMethods.GetVariableInt("ID do Aluguer"));

            command.ExecuteNonQuery();

        }

        //Efectuar alterações de preçário
        public static void i_ef()
        {
            int idEquipamento = AuxiliaryMethods.GetVariableInt("id equipamento");
            decimal valor = AuxiliaryMethods.GetVariableDecimal("novo preço", "formato decimal: UU.DD");
            int validade = -1;

            try
            {
                validade = DB.Preco1
                    .Where(p => p.idEquipamento == idEquipamento)
                    .First().validade;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.Write("idEquipamento inválido...\nCancelando operação");
                Thread.Sleep(2000);
                return;
            }

            DB.Add_Preco(idEquipamento, validade, valor);
        }

        public static void i_ef(int idEquipamento, decimal valor)
        {
            int validade = DB.Preco1
                                .Where(p => p.idEquipamento == idEquipamento)
                                .First().validade;

            DB.Add_Preco(idEquipamento, validade, valor);
        }

        public static void i_ado_net()
        {
            SqlCommand command = new SqlCommand("Add_Preco", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@idEquipamento", AuxiliaryMethods.GetVariableInt("ID do Equipamento"));
            command.Parameters.AddWithValue("@validade", AuxiliaryMethods.GetVariableInt("Validade"));
            command.Parameters.AddWithValue("@valor", AuxiliaryMethods.GetVariableDecimal("Valor"));

            command.ExecuteNonQuery();
        }

        //Listar todos os equipamentos livres, para um determinado tempo e tipo
        public static void j_ef()
        {
            int minutos = AuxiliaryMethods.GetVariableInt("minutos de aluguer");
            String tipo = AuxiliaryMethods.GetVariable("tipo de equipamento");

            List<ListEquipamentosLivres_Result> lst = DB.ListEquipamentosLivres(tipo, minutos).ToList();

            AuxiliaryMethods.ListResult<ListEquipamentosLivres_Result>(lst, i => { return string.Format("codigo: {0}, descrição: {1}",i.codigo, i.descricao); });
        }

        public static void j_ef(int minutos, string tipo)
        {
            List<ListEquipamentosLivres_Result> lst = DB.ListEquipamentosLivres(tipo, minutos).ToList();
        }

        public static void j_ado_net()
        {
            SqlCommand command = new SqlCommand("ListEquipamentosLivres", Connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@tipo", AuxiliaryMethods.GetVariable("Tipo"));
            command.Parameters.AddWithValue("@tempo", AuxiliaryMethods.GetVariableInt("Duracao", "Em minutos"));
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

        //Listar os equipamentos sem alugueres na última semana
        public static void k_ef()
        {
            List<ListNaoUsadosSemana_Result> lst = DB.ListNaoUsadosSemana().ToList();

            AuxiliaryMethods.ListResult(lst, x => {return String.Format("Descrição: {0}, Codigo: {1}, Tipo: {2}",x.descricao, x.codigo, x.tipo);});
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

        public static void CloseConnection()
        {
            Connection.Close();
        }

    }
}