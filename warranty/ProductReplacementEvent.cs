using System;

namespace warranty
{
    public struct ProductReplacementEvent : IEquatable<ProductReplacementEvent>
    {
        public  readonly DateTime ReplacementDate;
	    public  readonly string Reason;
	
	    public ProductReplacementEvent(DateTime replacementDate, string reason)
        {
            ReplacementDate = replacementDate;
            Reason = reason;
        }

        public bool Equals(ProductReplacementEvent other)
        {
            return ReplacementDate.Equals(other.ReplacementDate) && string.Equals(Reason, other.Reason);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ProductReplacementEvent && Equals((ProductReplacementEvent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ReplacementDate.GetHashCode() * 397) ^ (Reason != null ? Reason.GetHashCode() : 0);
            }
        }
    }
}