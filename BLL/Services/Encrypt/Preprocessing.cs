using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Enum;
using DAL.Models;
using DAL.Services.DALAccess;
using DAL.Services.CoreAccess;
using DAL.Enum;
using DAL.Enum.ErrorType;

namespace BLL.Services.Encrypt
{
    public class Preprocessing
    {
        public DataType MainProc(EncryptStatus state)
        {
            AlgorithmInitialization processing = new AlgorithmInitialization();
            DataType data = new DataType();
            Core core = new Core();
            Access DALAccess = new Access();
            EncryptModel mainData = new EncryptModel();
            data = core.GetData(DataStatus.CORE_DATA);
            //data = DALAccess.GetData(DataStatus.GET_DATA_FROM_DAL);

            switch (state)
            {
                case EncryptStatus.ENCRYPT_NEW_KEY_NEEDED:
                    processing.GenerateNewKey();
                    data.ByteArray = processing.Encrypt(mainData);
                    return data;
                case EncryptStatus.ENCRYPT_NO_NEW_KEY_NEEDED:
                    return data;
                case EncryptStatus.DECRYPT:
                    mainData.EncryptedText = data.ByteArray;
                    //Array.Clear(data.ByteArray, 0, data.ByteArray.Length);//очищаем (!!!)
                    data.StringType = processing.Decrypt(mainData);
                    
                    return data;
            }


            //processing.GenerateNewKey();


            //mainData.UnEncryptedString = "А теперь зашифруй и меня";
            //byte[] dat = processing.Encrypt(mainData);
            //DataType typ = new DataType();
            //typ.ByteArray = dat;
            //core.SetData(typ, DAL.Enum.DataStatus.ENCRYPT_RESULT_TEST);


            //DataType typ1 = new DataType();
            //typ1 = core.GetData(DAL.Enum.DataStatus.ENCRYPT_RESULT_TEST);
            //mainData.EncryptedText = typ1.ByteArray;
            //string a = processing.Decrypt(mainData);
            //typ1.StringType = a;
            //core.SetData(typ1, DAL.Enum.DataStatus.UNENCRYPT_RESULT_TEST);






            //Вернуть расшифрованные данные на форму
            data.Error = ErrorType.DATA_TYPE_ERROR;
            return data;
        }
    }
}
