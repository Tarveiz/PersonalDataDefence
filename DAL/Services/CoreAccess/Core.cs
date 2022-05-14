using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL.Services.CoreAccess
{
    public class Core
    {
        public List<string> Hash()
        {
            string path = @"..\..\..\..\DAL\Services\CoreAccess\Hash.txt";
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            List<string> result = new List<string>();
            List<char> word = new List<char>();
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
                    result.Add(word.ToString());
                    word.Clear();
                }
                else
                {
                    word.Add(i);
                }
            }
            return result;
        }
    }
}
