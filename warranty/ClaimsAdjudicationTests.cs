using System;
using System.Globalization;
using NUnit.Framework;

namespace warranty
{
    public class ClaimsAdjudicationTests
    {
        private readonly CultureInfo _provider = CultureInfo.InvariantCulture;
        private const string FormatDate = "MM-dd-yyyy";

        [Test]
        public void ClaimsAdjudicationTest()
        {
            var contract = new Contract(999, 100.0)
            {
                EffectiveDate = DateTime.ParseExact("08-05-2010", FormatDate, _provider),
                ExpirationDate = DateTime.ParseExact("08-05-2012", FormatDate, _provider),
                Status = Contract.Lifecycle.Active
            };

            var claim = new Claim(888, 79.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider));
            var adjudicator = new ClaimsAdjudicationService();

            adjudicator.Adjudicate(contract, claim);

            Assert.AreEqual(1, contract.Claims.Count);
        }

        [Test]
        public void ClaimsAdjudicationForInvalidClaimTest()
        {
            var contract = new Contract(999, 100.0)
            {
                EffectiveDate = DateTime.ParseExact("08-05-2010", FormatDate, _provider),
                ExpirationDate = DateTime.ParseExact("08-05-2012", FormatDate, _provider),
                Status = Contract.Lifecycle.Active
            };
            var claim = new Claim(888, 81.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider));
            var adjudicator = new ClaimsAdjudicationService();

            adjudicator.Adjudicate(contract, claim);

            Assert.AreEqual(0, contract.Claims.Count);
        }

        [Test]
        public void ClaimsAdjudicationForPendingContractTest()
        {
            var claim = new Claim(888, 81.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider));

            var pendingContract = new Contract(999, 100.0)
            {
                EffectiveDate = DateTime.ParseExact("08-05-2010", FormatDate, _provider),
                ExpirationDate = DateTime.ParseExact("08-05-2012", FormatDate, _provider),
                Status = Contract.Lifecycle.Pending
            };
            var adjudicator = new ClaimsAdjudicationService();

            adjudicator.Adjudicate(pendingContract, claim);

            Assert.AreEqual(0, pendingContract.Claims.Count);
        }

        [Test]
        public void ClaimsAdjudicationForExpiredContractTest()
        {
            var claim = new Claim(888, 79.0, new DateTime(2010, 05, 08));

            var pendingContract = new Contract(999, 100.0)
            {
                EffectiveDate = DateTime.ParseExact("08-05-2010", FormatDate, _provider),
                ExpirationDate = DateTime.ParseExact("08-05-2012", FormatDate, _provider),
                Status = Contract.Lifecycle.Expired
            };
            var adjudicator = new ClaimsAdjudicationService();

            adjudicator.Adjudicate(pendingContract, claim);

            Assert.AreEqual(0, pendingContract.Claims.Count);
        }
    }
}
