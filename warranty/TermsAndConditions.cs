using System;

namespace warranty_refactored
{
    public struct TermsAndConditions
    {
        public readonly DateTime EffectiveDate;
        public readonly DateTime ExpirationDate;
        public readonly DateTime PurchaseDate;
        public readonly int InStoreGuaranteeDays;

        public TermsAndConditions(DateTime effectiveDate, 
            DateTime expirationDate, 
            DateTime purchaseDate, 
            int inStoreGuaranteeDays)
        {
            EffectiveDate = effectiveDate;
            ExpirationDate = expirationDate;
            PurchaseDate = purchaseDate;
            InStoreGuaranteeDays = inStoreGuaranteeDays;
        }

        public bool IsPending(DateTime date)
        {
            return date.CompareTo(EffectiveDate) < 0;
        }

        public bool IsExpired(DateTime date)
        {
            return date.CompareTo(ExpirationDate) > 0;
        }

        public bool IsActive(DateTime date)
        {
            return date.CompareTo(EffectiveDate) >= 0
                    && date.CompareTo(ExpirationDate) <= 0;
        }

        public TermsAndConditions AnnuallyExtended()
        {
            return new TermsAndConditions(EffectiveDate, new DateTime(ExpirationDate.Year + 1, ExpirationDate.Month, ExpirationDate.Day), PurchaseDate, InStoreGuaranteeDays);
        }

        public bool Equals(TermsAndConditions other)
        {
            return EffectiveDate.Equals(other.EffectiveDate) && ExpirationDate.Equals(other.ExpirationDate) && PurchaseDate.Equals(other.PurchaseDate) && InStoreGuaranteeDays == other.InStoreGuaranteeDays;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TermsAndConditions && Equals((TermsAndConditions) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EffectiveDate.GetHashCode();
                hashCode = (hashCode * 397) ^ ExpirationDate.GetHashCode();
                hashCode = (hashCode * 397) ^ PurchaseDate.GetHashCode();
                hashCode = (hashCode * 397) ^ InStoreGuaranteeDays;
                return hashCode;
            }
        }
    }
}