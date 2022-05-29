using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using BLL.Enum;
using BLL.Models;
using DAL.Services.CoreAccess;
using DAL.Enum;
using DAL.Models;

namespace BLL.Services.Encrypt
{
    public class AlgorithmInitialization
    {

        public void GenerateNewKey()
        {
            DataType model = new DataType();
            Aes aes = Aes.Create();
            aes.GenerateKey();
            model.ByteArray = aes.Key;
            Core message = new Core();
            message.SetData(model, DataStatus.ENCRYPT_KEY);
        }

        public byte[] Encrypt(EncryptModel model)
        {
            Core data = new Core();
            DataType dataModel = new DataType();
            if (model.State == EncryptStatus.NEW_KEY_NEEDED)
            {
                GenerateNewKey();
            }
            dataModel = data.GetData(DataStatus.ENCRYPT_KEY);
            Aes aes = Aes.Create(); // make obj
            aes.GenerateIV(); // salt
            byte[] shifrtext;
            ICryptoTransform crypt = aes.CreateEncryptor(dataModel.ByteArray, aes.IV); // create encrypt

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(model.UnEncryptedString);
                    }
                }
                shifrtext = ms.ToArray();  // wryte encr bytes
            }

            byte[] encrypted_text = shifrtext.Concat(aes.IV).ToArray();


            //return key;
            return encrypted_text;

        }


        public string Decrypt(EncryptModel model)
        {
            string result = "";
            byte[] bytesIV = new byte[16]; // salt bytes
            byte[] mess = new byte[model.EncryptedText.Length - 16]; // rm rubbish
            // rm salt
            for (int i = model.EncryptedText.Length - 16, j = 0; i < model.EncryptedText.Length; i++, j++)
            {
                bytesIV[j] = model.EncryptedText[i];
            }
            for (int i = 0; i < model.EncryptedText.Length - 16; i++)
            {
                mess[i] = model.EncryptedText[i];
            }
            Aes aes = Aes.Create();
            Core data1 = new Core();
            DataType dataModel = new DataType();
            dataModel = data1.GetData(DataStatus.ENCRYPT_KEY);
            byte[] salt = bytesIV;
            byte[] data = mess;
            ICryptoTransform crypt = aes.CreateDecryptor(dataModel.ByteArray, salt);
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        //Результат записываем в переменную text в вие исходной строки
                        //cs.FlushFinalBlock();
                        result = sr.ReadToEnd();
                    }
                }
            }

            return result;
        }

    }
}
