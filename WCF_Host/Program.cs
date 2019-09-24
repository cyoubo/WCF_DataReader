using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WCF_DataReaderService;


namespace WCF_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebServiceHost host = new WebServiceHost(typeof(DataReaderService)))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("服务已经启动,输入exit退出...");
                    while (true)
                    {
                        string temp = Console.ReadLine();
                        if (temp.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                        {
                            break;
                        }
                    }
                    host.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("服务启动异常{0},输入exit退出...", ex.Message);
                }
            }
        }
    }
}
