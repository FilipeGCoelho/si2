using System;
using System.Collections.Generic;
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

        }
    }

    class App
    {
        private static Dictionary<string, OperationInfo> operations = new Dictionary<string, OperationInfo>();

        public static void Run()
        {

        }

        private static void Menu()
        {
            Console.WriteLine(operations["h"].phrase);
        }

        public static void Init()
        {
            operations.Add("h",new OperationInfo("Remover um Aluguer",MethodDB.h_ef,MethodDB.h_ado_net));
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
        //Remover Aluguer
        public static void h_ef()
        {
            
        }

        public static void h_ado_net()
        {

        }
    }


}
