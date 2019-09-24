using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_DataReaderService.Controller;

namespace WCF_DataReaderService
{
    public class DataReaderService : IDataReaderService
    {

        public ResultEntry ReadFile(string value)
        {

            ResultEntry result = ResultEntry.CreateSuccessEntry("");
            //调用service层的功能方法
            JsonDataFileController controller = new JsonDataFileController();
            if (controller.IsFileExist(value) == false)
                return result.UpdateState(false, controller.DisplayError_FileNotExsit(value));
            if (controller.ReadFileValue(value) == false)
                return result.UpdateState(false, controller.DisplayError_FileReadError(value));
            result.UpdateResult(controller.Result);
            controller.Release();
            return result;
        }

        public ResultEntry ConnectTest()
        {
            ResultEntry result = ResultEntry.CreateSuccessEntry("this is test");
            return result;
        }
    }
}
