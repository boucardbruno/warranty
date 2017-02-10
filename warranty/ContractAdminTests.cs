using System;
using System.Globalization;
using NUnit.Framework;

namespace warranty
{
    public class ContractAdminTests
    {
        private readonly CultureInfo _provider = CultureInfo.InvariantCulture;
        private const string FormatDate = "MM-dd-yyyy";

        [Test]
        public void TestContractIsSetupCorrectly()
        {
            var termsAndConditions = new TermsAndConditions(
            DateTime.ParseExact("08-05-2010", FormatDate, _provider),
            DateTime.ParseExact("08-05-2012", FormatDate, _provider),
            DateTime.ParseExact("08-05-2010", FormatDate, _provider),
            90);

            var contract = new Contract(999, 100.0, termsAndConditions);

            Assert.AreEqual(100.0, contract.PurchasePrice, 0.0);
        }


        [Test]
        public void TestLimitOfLiabilityNoClaims()
        {
            var termsAndConditions = new TermsAndConditions(
            DateTime.ParseExact("08-05-2010", FormatDate, _provider),
            DateTime.ParseExact("08-05-2012", FormatDate, _provider),
            DateTime.ParseExact("08-05-2010", FormatDate, _provider),
            90);

            var contract = new Contract(999, 100.0, termsAndConditions);

            Assert.AreEqual(80.0, contract.LimitOfLiability(), 0.0);
        }

        [Test]
        public void TestLimitOfLiabilityOneClaim()
        {
            var termsAndConditions = new TermsAndConditions(
            DateTime.ParseExact("08-05-2010", FormatDate, _provider),
            DateTime.ParseExact("08-05-2012", FormatDate, _provider),
            DateTime.ParseExact("08-05-2010", FormatDate, _provider),
            90);

            var contract = new Contract(999, 100.0, termsAndConditions);
            contract.Add(new Claim(888, 10.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider)));

            Assert.AreEqual(72.0, contract.LimitOfLiability(), 0.0);
        }


        [Test]
        public void TestLimitOfLiabilityMultipleClaims()
        {

            var termsAndConditions = new TermsAndConditions(
            DateTime.ParseExact("08-05-2010", FormatDate, _provider),
            DateTime.ParseExact("08-05-2012", FormatDate, _provider),
            DateTime.ParseExact("08-05-2010", FormatDate, _provider),
            90);

            var contract = new Contract(999, 100.0, termsAndConditions);
            contract.Add(new Claim(888, 10.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider)));
            contract.Add(new Claim(888, 20.0, DateTime.ParseExact("08-05-2010", FormatDate, _provider)));

            Assert.AreEqual(56.0, contract.LimitOfLiability(), 0.0);
        }
    }
}
