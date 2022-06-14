using BLL.Enum;
namespace BLL.Models
{
    public class EncryptModel
    {
        public string UnEncryptedString { get; set; }
        public byte[] EncryptedText { get; set; }
        public byte[] Key_Encypt { get; set; }
        public EncryptStatus State { get; set; }
    }
}
