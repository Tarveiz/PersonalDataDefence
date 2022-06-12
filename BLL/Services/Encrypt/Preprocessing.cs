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
        public DataType MainProc(EncryptModel model)
        {
            AlgorithmInitialization processing = new AlgorithmInitialization();
            DataType data = new DataType();
            Core core = new Core();
            Access DALAccess = new Access();
            EncryptModel mainData = new EncryptModel();
            
            //data = DALAccess.GetData(DataStatus.GET_DATA_FROM_DAL);

            switch (model.State)
            {
                case EncryptStatus.ENCRYPT_NEW_KEY_NEEDED:
                    //processing.GenerateNewKey();
                    //data.ByteArray = processing.Encrypt(mainData);
                    return data;
                case EncryptStatus.ENCRYPT_NO_NEW_KEY_NEEDED:
                    data.ByteArray = processing.Encrypt(model);
                    core.SetData(data, DataStatus.CORE_DATA);
                    DALAccess.SetData(data, DataStatus.SET_DATA_TO_DAL);
                    SecondBackUp.ChangeLocal(data);
                    return data;
                case EncryptStatus.DECRYPT:
                    data = DALAccess.GetData(DataStatus.GET_DATA_FROM_DAL);
                    mainData.EncryptedText = data.ByteArray;
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
