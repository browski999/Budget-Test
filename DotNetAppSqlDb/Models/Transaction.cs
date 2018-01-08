using System;

namespace DotNetAppSqlDb.Models
{
    public class Transaction
    {
        public Transaction()
        {
            Company = new Company();
            TransactionType = new TransactionType();
        }

        public int Id { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string AuthCode { get; set; }
        public Company Company { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}