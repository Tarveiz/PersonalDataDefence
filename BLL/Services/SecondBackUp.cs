using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DAL.Services.CoreAccess;
using DAL.Services.DALAccess;
using System.Timers;
using BLL.Services;
using DAL.Enum;
using BLL.Services.Encrypt;
using BLL.Models;
using BLL.Models.UI_Model;
using DAL.Models;

namespace BLL.Services
{
    public class SecondBackUp
    {
        private static System.Timers.Timer aTimer;
        private static string coreHash = "";
        //private static string DALHash = "";
        static MainHash hash = new MainHash();
        static Core coreData = new Core();
        static Access DAL = new Access();
        static AlgorithmInitialization ag = new AlgorithmInitialization();

        static bool mainCheck = false;
        static byte[] reserveKey;
        static byte[] res;
        static string err = "";
        static Action<string> message;


        public static void MainProccess(string str, Action<string> mes)
        {
            message = mes;
            bool bl = false;
            err = str;
            if (mainCheck == false)
            {
                reserveKey = AlgorithmInitialization.GenerateNewKey(bl);
                mainCheck = true;
                EncryptModel model1 = new EncryptModel();
                DataType data = new DataType();
                data = coreData.GetData(DataStatus.CORE_DATA);
                model1.EncryptedText = data.ByteArray;
                EncryptModel model2 = new EncryptModel();
                model2.Key_Encypt = reserveKey;
                model2.UnEncryptedString = ag.Decrypt(model1);
                res = AlgorithmInitialization.Encrypt(model2, bl);
                File.WriteAllBytes(@"C:\Users\Misha\Desktop\ErrorResult\reserveKey.txt", reserveKey);



                DataType data2 = new DataType();
                data2 = coreData.GetData(DataStatus.CORE_DATA);
                data2.StringType = data2.ByteArray.ToString();
                data2.ByteArray = null;
                coreHash = hash.GetHash(data2);
                //DALHash = hash.GetHash(DAL.GetData(DataStatus.GET_DATA_FROM_DAL));
                StopTimer();
                SetTimer();
            }
            else
            {
                DataType data2 = new DataType();
                data2 = coreData.GetData(DataStatus.CORE_DATA);
                data2.StringType = data2.ByteArray.ToString();
                data2.ByteArray = null;
                coreHash = hash.GetHash(data2);
                //DALHash = hash.GetHash(DAL.GetData(DataStatus.GET_DATA_FROM_DAL));
                StopTimer();
                SetTimer();
            }
        }

        public static void InnerStop()
        {
            StopTimer();
        }

        public static void InnerStart()
        {
            SetTimer();
        }

        

        public static void ChangeLocal(DataType arr)
        {
            arr.StringType = arr.ByteArray.ToString();
            arr.ByteArray = null;
            coreHash = hash.GetHash(arr);
            //DALHash = coreHash;
        }

        private static void CriticalError()
        {
            string err = "ВНИМАНИЕ! Произошла критическая ошибка данных. Целостность данных была нарушена неизвестной атакой.";
            message(err);

            //CORE информация (зашифрованная)
            File.WriteAllBytes(@"C:\Users\Misha\Desktop\ErrorResult\coreData.txt", res);

            //Информация с формы пользователя (зашифрованная)
            byte[] res2;
            bool bl = false;
            EncryptModel enc = new EncryptModel();
            enc.UnEncryptedString = err;
            enc.Key_Encypt = reserveKey;
            res2 = AlgorithmInitialization.Encrypt(enc, bl);
            File.WriteAllBytes(@"C:\Users\Misha\Desktop\ErrorResult\lastChanges.txt", res2);
            
        }


        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void StopTimer()
        {
            if(aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DataType data = new DataType();
            //DataType data2 = new DataType();
            try
            {
                data = coreData.GetData(DataStatus.CORE_DATA);
                data.StringType = data.ByteArray.ToString();
                data.ByteArray = null;
                string coreHashCheck = hash.GetHash(data);

                //data2 = coreData.GetData(DataStatus.GET_DATA_FROM_DAL);
                //data2.StringType = data2.ByteArray.ToString();
                //data2.ByteArray = null;
                //string DALHashCheck = hash.GetHash(data2);
                // || DALHashCheck != DALHash

                if (coreHashCheck != coreHash)
                {
                    StopTimer();
                    CriticalError();
                }
            }
            catch
            {
                StopTimer();
                CriticalError();
            }
            
        }
    }
}
