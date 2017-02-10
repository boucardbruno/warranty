using NUnit.Framework;

namespace warranty
{
    public class ContractAdminTests
    {
        [Test]
        public void ContractIsSetupCorrectlyTest()
        {
            var contract = new Contract(0, 100.0);
            Assert.AreEqual(100.0, contract.PurchasePrice);
            Assert.AreEqual(Contract.Lifecycle.Pending, contract.Status);
        }
    }
}
