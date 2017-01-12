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
    class XMLExporter
    {
        public static void AlugueresToXML(SqlConnection con)
        {
            const string strSql = "select * from Aluguer";

            using (SqlCommand sqlComm = new SqlCommand(strSql, con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ds.Tables[0].WriteXml("text.xml");
            }
        }

        public static void ProcessTable(DataSet ds)
        {
            Alugueres alugueres = new Alugueres();

            foreach (var row in ds.Tables[0].AsEnumerable())
            {
                alugueres.alugueres.Add(new Aluguer(1,"",1,1));
            }
        }
    }

    class Alugueres
    {
        public string inicio, fim;
        public List<Aluguer> alugueres;

        public override string ToString()
        {
            return String.Format("<alugueres dataInicio= \"{0}\" dataFim= \"{1}\" >{2}\n\n</alugueres>", inicio,fim,Alugueres_toString());
        }

        public string Alugueres_toString()
        {
            string toReturn = "";

            foreach (Aluguer aluguer in alugueres)
            {
                toReturn += "\n\n" + aluguer.ToString();
            }

            return ToString();
        }
    }

    class Aluguer
    {
        private int id;
        private string equipamento;
        private int nrCliente;
        private int codigo_equipamento;

        public override string ToString()
        {
            return
                String.Format("<aluguer id = \"{0}\" tipo = \"{1}\" >\n<cliente>{2}</cliente>\n<equipamento>{3}</equipamento>\n</aluguer>",
                    id,
                    equipamento,
                    nrCliente,
                    codigo_equipamento);
        }

        public Aluguer(int id, string equipamento, int nrc, int cod_eq)
        {
            this.id = id;
            this.equipamento = equipamento;
            this.nrCliente = nrc;
            this.codigo_equipamento = cod_eq;
        }
    }
}
