using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL.Enum;
using DAL.Models;

namespace DAL.Services.CoreAccess
{
    public class Core
    {
        public List<string> Hash()
        {
            //Обработать несколько строк, если таковые будут в доке с пользовательскими хешами
            // + перенести весь функционал. Отсюда мы лишь получаем сырые данные
            DataType data = new DataType();
            data = GetData(DataStatus.USERS_HASH);
            string line = data.StringType;
            List<string> result = new List<string>();
            string word = "";
            if (line == null)
            {
                List<string> exception = new List<string>();
                exception.Add("NO_HASH_DATA_IN_CORE");
                return exception;
            }
            foreach (char i in line)
            {
                if (i == ';')
                {
                    result.Add(word);
                    word ="";
                }
                else
                {
                    word+=i;
                }
            }
            return result;
        }

        public DataType GetData(DataStatus state)
        {
            DataType data = new DataType();
            switch (state)
            {
                case DataStatus.USERS_HASH:
                    string path = @"..\..\..\..\DAL\Services\CoreAccess\UsersHash.txt";
                    StreamReader reader = new StreamReader(path);
                    data.StringType = reader.ReadLine();
                    reader.Close();
                    return data;
                case DataStatus.CORE_DATA_HASH:
                    path = @"..\..\..\..\DAL\Services\CoreAccess\CoreDataHash.txt";
                    reader = new StreamReader(path);
                    data.StringType = reader.ReadLine();
                    reader.Close();
                    return data;
                case DataStatus.CORE_DATA:
                    path = @"..\..\..\..\DAL\Services\CoreAccess\CoreData.txt";
                    reader = new StreamReader(path);
                    data.ListStringType = new List<string>();
                    data.ListStringType.Add(reader.ReadLine());
                    reader.Close();
                    return data;
                case DataStatus.ENCRYPT_KEY:
                    path = @"..\..\..\..\DAL\Services\CoreAccess\EncryptKey.txt";
                    //path = @"EncryptKey.txt";
                    data.EncryptKey = File.ReadAllBytes(path);
                    return data;
                case DataStatus.TEST:
                    path = @"D:\Practice\С#\Duplom\PersonalDataDefence\DAL\Services\CoreAccess\TEST.txt";
                    //path = @"TEST.txt";
                    string a = File.ReadAllText(path);
                    byte[] f = File.ReadAllBytes(path);

                    data.EncryptKey = File.ReadAllBytes(path);
                    return data;
            }
            data.Error = ErrorTypeEnum.DATA_TYPE_ERROR;
            return data;
        }

        public void SetData(DataType data, DataStatus state)
        {
            switch (state)
            {
                case DataStatus.ENCRYPT_KEY:
                    string path = @"..\..\..\..\DAL\Services\CoreAccess\EncryptKey.txt";
                    //var stream = new FileStream(path, FileMode.Append);
                    //stream.Write(data.EncryptKey, 0, data.EncryptKey.Length);
                    File.WriteAllBytes(path, data.EncryptKey);
                    break;
                case DataStatus.TEST:
                    path = @"..\..\..\..\DAL\Services\CoreAccess\TEST.txt";
                    
                    //var stream = new FileStream(path, FileMode.Append);
                    //stream.Write(data.EncryptKey, 0, data.EncryptKey.Length);

                    File.WriteAllBytes(path, data.EncryptKey);

                    //StreamWriter writer = new StreamWriter(path);
                    //writer.WriteLine(data.StringType);
                    break;
                case DataStatus.TEST2:
                    path = @"..\..\..\..\DAL\Services\CoreAccess\TEST2.txt";

                    //var stream = new FileStream(path, FileMode.Append);
                    //stream.Write(data.EncryptKey, 0, data.EncryptKey.Length);
                    File.WriteAllText(path, data.StringType);
                    //StreamWriter writer = new StreamWriter(path);
                    //writer.WriteLine(data.StringType);
                    break;
            }
        }

    }
}
