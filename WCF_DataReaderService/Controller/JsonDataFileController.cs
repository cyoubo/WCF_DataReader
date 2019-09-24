using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_DataReaderService.Config;

namespace WCF_DataReaderService.Controller
{
    public class JsonDataFileController
    {
        public bool IsFileExist(string value)
        {
            DataFileFoldConfig config = DataFileFoldConfig.Load();
            return (File.Exists(config.BaseFold + "/" + value));
        }

        public bool ReadFileValue(string value)
        {
            bool result = false;
            try
            {
                DataFileFoldConfig config = DataFileFoldConfig.Load();
                string FileName = config.BaseFold + "/" + value;
                using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (StreamReader sw = new StreamReader(fs, Encoding.UTF8))
                    {
                        Result = sw.ReadToEnd();
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReadFileValue {0} ", ex.Message);
            }
            return result;
        }

        public string DisplayError_FileNotExsit(string value)
        {
            DataFileFoldConfig config = DataFileFoldConfig.Load();
            string FileName = config.BaseFold + "/" + value;
            return string.Format("文件{0}不存在", FileName);
        }

        public string DisplayError_FileReadError(string value)
        {
            DataFileFoldConfig config = DataFileFoldConfig.Load();
            string FileName = config.BaseFold + "/" + value;
            return string.Format("文件{0} 读取错误", FileName);
        }

        public string Result { get; set; }

        public void Release()
        {
            Result = "";
        }
    }
}
