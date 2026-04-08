using NUnit.Framework;
using BankSystem;

namespace BankSystem.Tests
{
    [TestFixture]
    public class DepositTests
    {
        private BankAccount _account;

        [SetUp]
        public void SetUp()
        {
            _account = new BankAccount("ACC001", 1_000_000);
        }

        [Test]
        public void Deposit_1_IncreaseCorrect()
        {
            _account.Deposit(1);

            Assert.That(_account.Balance, Is.EqualTo(1_000_001));
        }

        [Test]
        public void Deposit_200k_IncreaseCorrect()
        {
            _account.Deposit(200_000);

            Assert.That(_account.Balance, Is.EqualTo(1_200_000));
        }

        [Test]
        public void Deposit_LargeAmount_StillCorrect()
        {
            _account.Deposit(10_000_000);

            Assert.That(_account.Balance, Is.EqualTo(11_000_000));
        }

        [Test]
        public void Deposit_0_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => _account.Deposit(0));
        }

        [Test]
        public void Deposit_Negative_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => _account.Deposit(-1));
        }

        [Test]
        public void Deposit_NegativeLarge_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => _account.Deposit(-1_000_000));
        }

        [Test]
        public void Deposit_Fail_ShouldNotChangeBalance()
        {
            double before = _account.Balance;

            try
            {
                _account.Deposit(-500_000);
            }
            catch (ArgumentException) { }

            Assert.That(_account.Balance, Is.EqualTo(before));
        }

        [TestCase(100)]
        [TestCase(500_000)]
        [TestCase(10_000_000)]
        public void Deposit_MultipleValid(double amount)
        {
            double expected = _account.Balance + amount;

            _account.Deposit(amount);

            Assert.That(_account.Balance, Is.EqualTo(expected));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1_000_000)]
        public void Deposit_MultipleInvalid(double amount)
        {
            Assert.Throws<ArgumentException>(() => _account.Deposit(amount));
        }

        [Test]
        public void Deposit_Buggy_ShouldRevealBug()
        {
            var acc = new BankAccountBuggy("ACC003", 1_000_000);

            acc.Deposit(100_000);

            // bug: cộng x2
            Assert.That(acc.Balance, Is.EqualTo(1_100_000),
                "Lỗi nếu không +100k");
        }

        [Test]
        public void Deposit_Buggy_InvalidAmount_ShouldThrow()
        {
            var acc = new BankAccountBuggy("BUG", 1_000);
            Assert.Throws<ArgumentException>(() => acc.Deposit(0));
        }
    }
}