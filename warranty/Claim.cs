using System;
using warranty_refactored;

namespace warranty
{
    public class Claim
    {
        public readonly int Id;
        public readonly double Amount;
        public readonly DateTime Date;
        public ProductReplacementEvent ProductReplacement;
        public CustomerReimbursementEvent CustomerReimbursement;

        public Claim(int id, double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
            Id = id;
        }
    }
}
