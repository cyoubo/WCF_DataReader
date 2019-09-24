using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WCF_DataReader;


namespace WCF_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebServiceHost host = new WebServiceHost(typeof(DataReaderService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
