using System;

namespace CQRSDemo.Entity
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public string BeneficiaryName { get; set; }
        public string BankName { get; set; }
        public string SWIFTCode { get; set; }
        public int Amount { get; set; }
    }
}
