using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Models;
using BLL.Enum.UI_Status;
using BLL.Enum;

namespace BLL.Services.Encrypt
{
    public class MessageBroker
    {
        public List<string> ReceivingMessage(UI_Status request)
        {
            //Предоставление на форму пользователя информацию в таком виде, в котором она уже будет отображаться пользователю
            DataType data = new DataType();
            List<string> result = new List<string>();

            data = RetrievedMessage(request);

            switch (request)
            {
                case UI_Status.OUTPUT_INFORMATION:
                    string line = data.StringType;
                    string word = "";

                    foreach (char i in line)
                    {
                        if (i == ';')
                        {
                            result.Add(word);
                            word = "";
                        }
                        else
                        {
                            word += i;
                        }
                    }
                    if (word.Length != 0)
                    {
                        result.Add(word);
                    }
                    return result;
                case UI_Status.REWRITE_INFORMATION:
                    return result;
            }
            return result;
        }

        public DataType RetrievedMessage(UI_Status request)
        {
            //Препроцесс информации для внутренних классов в таком виде, в котором им её будет удобно использовать (в моделях)
            Preprocessing message = new Preprocessing();
            DataType data = new DataType();
            switch (request)
            {
                case UI_Status.OUTPUT_INFORMATION:
                    data = message.MainProc(EncryptStatus.DECRYPT);
                    return data;
                case UI_Status.REWRITE_INFORMATION:
                    return data;
            }
            
            return data;
        }
    }
}
