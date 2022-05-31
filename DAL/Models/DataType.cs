using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enum;

namespace DAL.Models
{
    public class DataType
    {
        public string StringType { get; set; }
        public List<string> ListStringType { get; set; }
        public ErrorType Error { get; set; }
        public byte[] ByteArray { get; set; }
    }
}
