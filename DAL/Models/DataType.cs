using System.Collections.Generic;
using DAL.Enum.ErrorType;
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
