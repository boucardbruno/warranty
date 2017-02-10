using System.Collections.Generic;

namespace warranty
{
    public class ClaimsAdjudicationService
    {
        public void Adjudicate(Contract contract, Claim newClaim)
        {
            var claims = new List<Claim>();
            claims.AddRange(contract.Claims);

            double claimTotal = 0;
            foreach (var claim in claims)
            {
                claimTotal += claim.Amount;
            }

            if ((contract.PurchasePrice - claimTotal) * 0.8 > newClaim.Amount &&
                newClaim.Date.CompareTo(contract.EffectiveDate) >= 0 &&
                newClaim.Date.CompareTo(contract.ExpirationDate) <= 0 &&
                contract.Status == Contract.Lifecycle.Active)
            {
                contract.Add(newClaim);
            }

        }
    }
}