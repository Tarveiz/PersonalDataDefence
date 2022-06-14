using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Models;
using BLL.Enum.UI_Status;
using BLL.Enum;
using BLL.Models.UI_Model;

namespace BLL.Services.Encrypt
{
    public class MessageBroker
    {
        public void ReceivingMessage(UI_Model request)
        {
            DataType data = new DataType();
            List<string> result = new List<string>();
            RetrievedMessage(request);

        }
        public List<string> ReceivingMessage(UI_Status request)
        {
            DataType data = new DataType();
            List<string> result = new List<string>();
            UI_Model model = new UI_Model();
            model.State = request;
            data = RetrievedMessage(model);
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
            }
            return result;
        }
        public DataType RetrievedMessage(UI_Model request)
        {
            Preprocessing message = new Preprocessing();
            EncryptModel encryptModel = new EncryptModel();
            DataType data = new DataType();
            switch (request.State)
            {
                case UI_Status.OUTPUT_INFORMATION:
                    encryptModel.State = EncryptStatus.DECRYPT;
                    data = message.MainProc(encryptModel);
                    return data;
                case UI_Status.REWRITE_INFORMATION:
                    encryptModel.State = EncryptStatus.ENCRYPT_NO_NEW_KEY_NEEDED;
                    encryptModel.UnEncryptedString = request.StringType;
                    data = message.MainProc(encryptModel);
                    return data;
            }
            return data;
        }
    }
}
