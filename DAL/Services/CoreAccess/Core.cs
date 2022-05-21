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
                    return data;
                case DataStatus.CORE_DATA_HASH:
                    path = @"..\..\..\..\DAL\Services\CoreAccess\CoreDataHash.txt";
                    reader = new StreamReader(path);
                    data.StringType = reader.ReadLine();
                    return data;
                case DataStatus.CORE_DATA:
                    path = @"..\..\..\..\DAL\Services\CoreAccess\CoreData.txt";
                    reader = new StreamReader(path);
                    data.ListStringType.Add(reader.ReadLine()) ;
                    return data;
            }
            data.Error = ErrorTypeEnum.DATA_TYPE_ERROR;
            return data;
        }

    }
}
