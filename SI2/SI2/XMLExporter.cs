using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class XmlExporter
    {
        public static void AlugueresToXml(SqlConnection con)
        {
            const string strSql = "select * from Aluguer";
            DateTime inicio = AuxiliaryMethods.GetVariableDate("Data Inicial");
            DateTime fim = AuxiliaryMethods.GetVariableDate("Data Final");

            using (SqlCommand sqlComm = new SqlCommand(strSql, con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                DataSet ds = new DataSet();
                adapter.Fill(ds);


                ds.Tables[0].WriteXml("text.xml");
            }
        }
    }
}
