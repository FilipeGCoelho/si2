using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SI2.SQL;

namespace SI2
{
    class XmlExporter
    {
        public static void AlugueresToXml(SqlConnection con)
        {
            DateTime inicio = AuxiliaryMethods.GetVariableDate("Data Inicial");
            DateTime fim = AuxiliaryMethods.GetVariableDate("Data Final");

            using (SqlCommand sqlComm = new SqlCommand("ListAlugueresBetween", con))
            {
                sqlComm.Parameters.AddWithValue("@dataInicio", inicio);
                sqlComm.Parameters.AddWithValue("@datafim", fim);
                sqlComm.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                DataSet ds = new DataSet();
                adapter.SelectCommand = sqlComm;
                adapter.Fill(ds);

                Console.Clear();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Console.WriteLine("Sem resultados");
                }
                else {ProcessTable(ds, inicio, fim);
                Console.WriteLine("\nPress any key to continue ...");
}
                Console.ReadKey();
            }
        }

        public static void ProcessTable(DataSet ds, DateTime inicio, DateTime fim)
        {
            Alugueres alugueres = new Alugueres();
            alugueres.fim = fim.ToShortDateString();
            alugueres.inicio = inicio.ToShortDateString();

            foreach (var row in ds.Tables[0].AsEnumerable())
            {
                alugueres.alugueres.Add(new Aluguer(
                    row["aluguerId"].ToString(),
                    row["tipoEquipamento"].ToString(),
                    row["clienteId"].ToString(),
                    row["codigoEquipamento"].ToString()));
            }

            System.IO.File.WriteAllText("text.xml", alugueres.ToString());
        }
    }

    class Alugueres
    {
        public string inicio, fim;
        public List<Aluguer> alugueres = new List<Aluguer>();

        public override string ToString()
        {
            return
                String.Format(
                    "<xml>\n  <alugueres dataInicio= \"{0}\" dataFim= \"{1}\" >{2}\n\n  </alugueres>\n</xml>", inicio,
                    fim, Alugueres_toString());
        }

        public string Alugueres_toString()
        {
            string toReturn = "";

            foreach (Aluguer aluguer in alugueres)
            {
                toReturn += "\n\n" + aluguer;
            }

            return toReturn;
        }
    }

    class Aluguer
    {
        private string id;
        private string equipamento;
        private string nrCliente;
        private string codigo_equipamento;

        public override string ToString()
        {
            return
                string.Format("  <aluguer id = \"{0}\" tipo = \"{1}\" >\n" +
                              "    <cliente>{2}</cliente>\n" +
                              "    <equipamento>{3}</equipamento>\n" +
                              "  </aluguer>",
                    id,
                    equipamento,
                    nrCliente,
                    codigo_equipamento);
        }

        public Aluguer(string id, string equipamento, string nrc, string cod_eq)
        {
            this.id = id;
            this.equipamento = equipamento;
            this.nrCliente = nrc;
            this.codigo_equipamento = cod_eq;
        }
    }
}