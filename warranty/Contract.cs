using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace warranty
{
    public class Contract
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
    }
}