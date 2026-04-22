using NUnit.Framework;
using BankSystem;

namespace BankSystem.Tests
{
    [TestFixture]
    public class PayBillTests
    {
        private BankAccount _account;

        [SetUp]
        public void SetUp()
        {
            _account = new BankAccount("ACC001", 1_000_000);
        }

        [Test]
        public void PayBill_ValidAmount_ShouldDeductAmountAndFee()
        {
            _account.PayBill(500_000);

            Assert.That(_account.Balance, Is.EqualTo(498_000));
        }

        [Test]
        public void PayBill_ExactBalance_ShouldThrowInvalidOperationException()
        {
            // Amount exactly equals balance, no fee left -> should throw
            Assert.Throws<InvalidOperationException>(() => _account.PayBill(1_000_000));
        }

        [Test]
        public void PayBill_ToExactZero_ShouldPass()
        {
            // Amount + 2000 = 1,000,000 -> amount = 998,000
            _account.PayBill(998_000);
            Assert.That(_account.Balance, Is.EqualTo(0));
        }

        [Test]
        public void PayBill_0_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _account.PayBill(0));
        }

        [Test]
        public void PayBill_NegativeAmount_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _account.PayBill(-500_000));
        }

        [Test]
        public void PayBill_Invalid_NotChangeBalance()
        {
            double before = _account.Balance;

            try
            {
                _account.PayBill(-100);
            }
            catch (ArgumentException) { }

            Assert.That(_account.Balance, Is.EqualTo(before));
        }

        [Test]
        public void PayBill_InsufficientFunds_NotChangeBalance()
        {
            double before = _account.Balance;

            try
            {
                _account.PayBill(1_000_000);
            }
            catch (InvalidOperationException) { }

            Assert.That(_account.Balance, Is.EqualTo(before));
        }

        [TestCase(100_000, 898_000)]
        [TestCase(500_000, 498_000)]
        [TestCase(998_000, 0)]
        public void PayBill_MultipleAmounts(double amount, double expected)
        {
            _account.PayBill(amount);

            Assert.That(_account.Balance, Is.EqualTo(expected));
        }
    }
}
