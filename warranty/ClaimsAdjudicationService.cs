namespace warranty
{
    public class ClaimsAdjudicationService
    {
        public void Adjudicate(Contract contract, Claim newClaim)
        {
            contract.Add(newClaim);
        }
    }
}