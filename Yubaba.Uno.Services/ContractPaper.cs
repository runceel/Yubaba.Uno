namespace Yubaba.Uno.Services
{
    public class ContractPaper
    {
        public ContractPaper(string signatureSign)
        {
            SignatureSign = signatureSign;
        }

        public string SignatureSign { get; }
    }
}
