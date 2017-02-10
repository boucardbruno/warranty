using System;
using System.Globalization;
using NUnit.Framework;

namespace warranty
{
    public class ClaimsAdjudicationTests
    {
        private readonly CultureInfo _provider = CultureInfo.InvariantCulture;
        private const string FormatDate = "MM-dd-yyyy";

        public Contract BuildContract()
        {
            var termsAndConditions = new TermsAndConditions(
                DateTime.ParseExact("08-05-2010", FormatDate, _provider),
                DateTime.ParseExact("08-05-2012", FormatDate, _provider),
                DateTime.ParseExact("08-05-2010", FormatDate, _provider),
                90);

            return new Contract(999, 100.0, termsAndConditions);
        }

        [Test]
        public void ClaimsAdjudicationTest()
        {
            var contract = BuildContract();
            var claim = new Claim(888, 79.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider));
            var adjudicator = new ClaimsAdjudicationService();

            adjudicator.Adjudicate(contract, claim);

            Assert.AreEqual(1, contract.GetClaims().Count);
        }

        [Test]
        public void ClaimsAdjudicationForClaimExceedingLimitOfLiabilityTest()
        {
            var contract = BuildContract();
            var claim = new Claim(888, 81.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider));
            var adjudicator = new ClaimsAdjudicationService();

            Assert.Throws<ContractException>(() => adjudicator.Adjudicate(contract, claim));
        }


        [Test]
        public void ClaimsAdjudicationForPendingContractTest()
        {
            var contract = BuildContract();
            var claim = new Claim(888, 81.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider));
            var adjudicator = new ClaimsAdjudicationService();

            Assert.Throws<ContractException>(() => adjudicator.Adjudicate(contract, claim));
        }

        [Test]
        public void ClaimsAdjudicationForExpiredContractTest()
        {
            var contract = BuildContract();
            var claim = new Claim(888, 81.0, DateTime.ParseExact("08-05-2012", FormatDate, _provider));
            var adjudicator = new ClaimsAdjudicationService();

            Assert.Throws<ContractException>(() => adjudicator.Adjudicate(contract, claim));
        }
    }
}
