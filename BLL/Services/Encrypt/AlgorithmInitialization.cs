using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
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
        public static byte[] GenerateNewKey(bool bl)
        {
            Aes aes = Aes.Create();
            aes.GenerateKey();
            byte[] arr = aes.Key;
            return arr;
        }
        public byte[] Encrypt(EncryptModel model)
        {
            Core data = new Core();
            DataType dataModel = new DataType();
            dataModel = data.GetData(DataStatus.ENCRYPT_KEY);
            Aes aes = Aes.Create(); 
            aes.GenerateIV();
            byte[] shifrtext;
            ICryptoTransform crypt = aes.CreateEncryptor(dataModel.ByteArray, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(model.UnEncryptedString);
                    }
                }
                shifrtext = ms.ToArray();
            }
            byte[] encrypted_text = shifrtext.Concat(aes.IV).ToArray();
            return encrypted_text;

        }
        public static byte[] Encrypt(EncryptModel model, bool bl)
        {
            Core data = new Core();
            Aes aes = Aes.Create();
            aes.GenerateIV();
            byte[] shifrtext;
            ICryptoTransform crypt = aes.CreateEncryptor(model.Key_Encypt, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(model.UnEncryptedString);
                    }
                }
                shifrtext = ms.ToArray();
            }
            byte[] encrypted_text = shifrtext.Concat(aes.IV).ToArray();
            return encrypted_text;
        }
        public string Decrypt(EncryptModel model)
        {
            string result = "";
            byte[] bytesIV = new byte[16];
            byte[] mess = new byte[model.EncryptedText.Length - 16];
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
                        result = sr.ReadToEnd();
                    }
                }
            }
            return result;
        }
    }
}
