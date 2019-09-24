using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_DataReader
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
            get { return Value; }
            set { Value = value; }
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
    }
}