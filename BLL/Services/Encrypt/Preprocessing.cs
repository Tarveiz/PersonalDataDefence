using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL.Models;
using DAL.Services.CoreAccess;

namespace BLL.Services.Encrypt
{
    public class Preprocessing
    {
        public void MainProc()
        {
            AlgorithmInitialization processing = new AlgorithmInitialization();
            Core core = new Core();
            EncryptModel mainData = new EncryptModel();


            //processing.GenerateNewKey();


            //mainData.UnEncryptedString = "А теперь зашифруй и меня";
            //byte[] dat = processing.Encrypt(mainData);
            //DataType typ = new DataType();
            //typ.ByteArray = dat;
            //core.SetData(typ, DAL.Enum.DataStatus.TEST);


            //DataType typ1 = new DataType();
            //typ1 = core.GetData(DAL.Enum.DataStatus.TEST);
            //mainData.EncryptedText = typ1.ByteArray;
            //string a = processing.Decrypt(mainData);
            //typ1.StringType = a;
            //core.SetData(typ1, DAL.Enum.DataStatus.TEST2);

            //Вернуть расшифрованные данные на форму


        }
    }
}
