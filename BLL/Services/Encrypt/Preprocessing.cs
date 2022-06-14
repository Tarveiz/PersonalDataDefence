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
            switch (model.State)
            {
                case EncryptStatus.ENCRYPT_NEW_KEY_NEEDED:
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
            data.Error = ErrorType.DATA_TYPE_ERROR;
            return data;
        }
    }
}
