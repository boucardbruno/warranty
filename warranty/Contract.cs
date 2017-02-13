using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace warranty
{
    public class Contract : IEquatable<Contract>
    {
        public readonly int Id;
        public readonly double PurchasePrice;
        private TermsAndConditions _termsAndConditions;
        private readonly IList<Claim> _claims;

        public Contract(int id, double purchasePrice, TermsAndConditions termsAndConditions)
        {
            Id = id;
            PurchasePrice = purchasePrice;
            _termsAndConditions = termsAndConditions;
            _claims = new List<Claim>();
        }

        public void Add(Claim newClaim)
        {
            if (newClaim.Amount < LimitOfLiability()
                && _termsAndConditions.IsActive(newClaim.Date))
            {
                _claims.Add(newClaim);
            }
            else
            {
                throw new ContractException(
                    "Contract is not active or amount is less than limit of liability");
            }
        }

        public IReadOnlyCollection<Claim> GetClaims()
        {
            return new ReadOnlyCollection<Claim>(_claims);
        }

        public void Remove(Claim claim)
        {
            _claims.Remove(claim);
        }

        public void ExtendAnnualSubscription()
        {
            _termsAndConditions = _termsAndConditions.AnnuallyExtended();
        }

        public TermsAndConditions TermsAndConditions()
        {
            return _termsAndConditions;
        }

        public double LimitOfLiability()
        {
            double claimTotal = 0;

            foreach (var clain in GetClaims())
            {
                claimTotal += clain.Amount;
            }
            return (PurchasePrice - claimTotal) * 0.8;
        }

        public bool Equals(Contract other)
        {
            return other != null && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Contract) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ PurchasePrice.GetHashCode();
                hashCode = (hashCode * 397) ^ _termsAndConditions.GetHashCode();
                hashCode = (hashCode * 397) ^ (_claims != null ? _claims.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}