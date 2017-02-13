using System;

namespace warranty
{
    public class Claim: IEquatable<Claim>

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

        public bool Equals(Claim other)
        {
            return other != null && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Claim) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                hashCode = (hashCode * 397) ^ Date.GetHashCode();
                hashCode = (hashCode * 397) ^ ProductReplacement.GetHashCode();
                hashCode = (hashCode * 397) ^ CustomerReimbursement.GetHashCode();
                return hashCode;
            }
        }
    }
}
