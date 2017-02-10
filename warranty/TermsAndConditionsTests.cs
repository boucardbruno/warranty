using System;
using System.Globalization;
using NUnit.Framework;

namespace warranty
{
    public class TermsAndConditionsTests
    {
        private readonly CultureInfo _provider = CultureInfo.InvariantCulture;
        private const string FormatDate = "MM-dd-yyyy";

        [Test]
        public void ExtendedByOneYearTest()
        {
            var effectiveDate = DateTime.ParseExact("08-05-2010", FormatDate, _provider);
            var purchaseDate = DateTime.ParseExact("08-05-2010", FormatDate, _provider);
            var expirationDate = DateTime.ParseExact("08-05-2012", FormatDate, _provider);

            var termsAndConditions = new TermsAndConditions(
                effectiveDate,
                expirationDate,
                purchaseDate, 90);

            var newExpirationDate = DateTime.ParseExact("08-05-2013", FormatDate, _provider);
            var expectedTermsAndConditions = new TermsAndConditions(
                effectiveDate,
                newExpirationDate,
                purchaseDate, 90);

            Assert.AreEqual(expectedTermsAndConditions, termsAndConditions.AnnuallyExtended());

            // Note: annuallyExtended is a side-effect-free function, with closure of operation
            TermsAndConditions expectedUnmodified = new TermsAndConditions(
                effectiveDate,
                expirationDate,
                effectiveDate, 90);

            Assert.AreEqual(expectedUnmodified, termsAndConditions);
        }
    }
}
