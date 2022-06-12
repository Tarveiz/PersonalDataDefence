using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL.Enum;
using DAL.Models;
using DAL.Enum.ErrorType;


namespace DAL.Services.CoreAccess
{
    public class Core
    {
        public DataType GetData(DataStatus state)
        {
            DataType data = new DataType();
            switch (state)
            {
                case DataStatus.USERS_HASH:
                    //string path = Directory.GetCurrentDirectory() + @"\Services\CoreAccess\UsersHash.txt";
                    string path = @"..\..\..\..\DAL\Services\CoreAccess\UsersHash.txt";
                    StreamReader reader = new StreamReader(path);
                    data.StringType = reader.ReadLine();
                    reader.Close();
                    return data;
                case DataStatus.CORE_DATA:
                    //path = Directory.GetCurrentDirectory() + @"\Services\CoreAccess\CoreData.txt";
                    path = @"..\..\..\..\DAL\Services\CoreAccess\CoreData.txt";
                    data.ByteArray = File.ReadAllBytes(path);
                    return data;
                case DataStatus.ENCRYPT_KEY:
                    //path = Directory.GetCurrentDirectory() + @"\Services\CoreAccess\EncryptKey.txt";
                    path = @"..\..\..\..\DAL\Services\CoreAccess\EncryptKey.txt";
                    data.ByteArray = File.ReadAllBytes(path);
                    return data;
                case DataStatus.ENCRYPT_RESULT_TEST:
                    //path = Directory.GetCurrentDirectory() + @"\Services\CoreAccess\ENCRYPT_RESULT_TEST.txt";
                    path = @"..\..\..\..\DAL\Services\CoreAccess\ENCRYPT_RESULT_TEST.txt";
                    data.ByteArray = File.ReadAllBytes(path);
                    return data;
            }
            data.Error = ErrorType.DATA_TYPE_ERROR;
            return data;
        }

        public void SetData(DataType data, DataStatus state)
        {
            switch (state)
            {
                case DataStatus.ENCRYPT_KEY:
                    //string path = Directory.GetCurrentDirectory() + @"\Services\CoreAccess\EncryptKey.txt";
                    string path = @"..\..\..\..\DAL\Services\CoreAccess\EncryptKey.txt";
                    File.WriteAllBytes(path, data.ByteArray);
                    break;
                case DataStatus.ENCRYPT_RESULT_TEST:
                    //path = Directory.GetCurrentDirectory() + @"\Services\CoreAccess\ENCRYPT_RESULT_TEST.txt";
                    path = @"..\..\..\..\DAL\Services\CoreAccess\ENCRYPT_RESULT_TEST.txt";
                    File.WriteAllBytes(path, data.ByteArray);
                    break;
                case DataStatus.UNENCRYPT_RESULT_TEST:
                    //path = Directory.GetCurrentDirectory() + @"\Services\CoreAccess\UNENCRYPT_RESULT_TEST.txt";
                    path = @"..\..\..\..\DAL\Services\CoreAccess\UNENCRYPT_RESULT_TEST.txt";
                    File.WriteAllText(path, data.StringType);
                    break;
                case DataStatus.CORE_DATA:
                    //string path = Directory.GetCurrentDirectory() + @"\Services\CoreAccess\EncryptKey.txt";
                    path = @"..\..\..\..\DAL\Services\CoreAccess\CoreData.txt";
                    File.WriteAllBytes(path, data.ByteArray);
                    break;
            }
        }
    }
}
