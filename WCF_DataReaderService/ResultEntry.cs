using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_DataReaderService
{
    [DataContract]
    public class ResultEntry
    {
       private bool state;
       private string message;
       private string value;

        [DataMember]
       public bool State
        {
            get { return state; }
            set { state = value; }
        }

        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [DataMember]
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public static ResultEntry CreateSuccessEntry(string Value)
        {
            ResultEntry result = new ResultEntry();
            result.state = true;
            result.message = "";
            result.value = Value;
            return result;
        }

        public static ResultEntry CreateErrorEntry(string ErrorMessage)
        {
            ResultEntry result = new ResultEntry();
            result.state = false;
            result.message = ErrorMessage;
            result.value = "";
            return result;
        }

        public ResultEntry UpdateState(bool state, string ErrorMessage)
        {
            this.state = false;
            this.message = ErrorMessage;
            this.value = "";
            return this;
        }

        public void UpdateResult(string value)
        {
            this.state = true;
            this.message = "";
            this.value = value;
        }

    }
}