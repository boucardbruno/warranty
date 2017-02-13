using System;

namespace warranty
{
    public struct CustomerReimbursementEvent : IEquatable<CustomerReimbursementEvent>
    {
        public readonly DateTime DateOfReimbursement;
	    public readonly string Reason;
	    public readonly double Amount;

        public CustomerReimbursementEvent(DateTime dateOfReimbursement, string reason, double amount)
        {
            DateOfReimbursement = dateOfReimbursement;
            Reason = reason;
            Amount = amount;
        }

        public bool Equals(CustomerReimbursementEvent other)
        {
            return DateOfReimbursement.Equals(other.DateOfReimbursement) && string.Equals(Reason, other.Reason) && Amount.Equals(other.Amount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is CustomerReimbursementEvent && Equals((CustomerReimbursementEvent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = DateOfReimbursement.GetHashCode();
                hashCode = (hashCode * 397) ^ (Reason != null ? Reason.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                return hashCode;
            }
        }
    }
}