using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WCF_DataReaderService.Config
{
    public class DataFileFoldConfig
    {
        private static DataFileFoldConfig instance;

        private DataFileFoldConfig() { }

        public static DataFileFoldConfig Load()
        {
            if (instance == null)
            {
                instance = new DataFileFoldConfig();
                XmlDocument doc = new XmlDocument();
                doc.Load(System.IO.Directory.GetCurrentDirectory() + "/Config/DataFileFoldConfig.xml");
                XmlNode root = doc.SelectSingleNode("config");
                instance.BaseFold = root.SelectSingleNode("BaseFold").InnerText;
            }
            return instance;
        }



        public string BaseFold { get; set; }


    }
}
