using NUnit.Framework;
using BankSystem;

namespace BankSystem.Tests
{
    [TestFixture]
    public class InterestTests
    {
        private BankAccount _account;

        [SetUp]
        public void SetUp()
        {
            _account = new BankAccount("ACC001", 1_000_000);
        }

        [Test]
        public void ApplyInterest_5Percent_Correct()
        {
            _account.ApplyInterest(0.05);

            Assert.That(_account.Balance, Is.EqualTo(1_050_000));
        }

        [Test]
        public void ApplyInterest_SmallRate_Correct()
        {
            _account.ApplyInterest(0.001);

            Assert.That(_account.Balance, Is.EqualTo(1_001_000));
        }

        [Test]
        public void ApplyInterest_100Percent_DoubleBalance()
        {
            _account.ApplyInterest(1.0);

            Assert.That(_account.Balance, Is.EqualTo(2_000_000));
        }

        [Test]
        public void ApplyInterest_0_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => _account.ApplyInterest(0));
        }

        [Test]
        public void ApplyInterest_Negative_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => _account.ApplyInterest(-0.05));
        }

        [Test]
        public void ApplyInterest_Invalid_NotChangeBalance()
        {
            double before = _account.Balance;

            try
            {
                _account.ApplyInterest(-0.1);
            }
            catch (ArgumentException) { }

            Assert.That(_account.Balance, Is.EqualTo(before));
        }

        [Test]
        public void ApplyInterest_Twice_ShouldCompoundCorrect()
        {
            _account.ApplyInterest(0.05);
            _account.ApplyInterest(0.05);

            Assert.That(_account.Balance, Is.EqualTo(1_102_500));
        }

        [TestCase(0.01, 1_010_000)]
        [TestCase(0.05, 1_050_000)]
        [TestCase(0.10, 1_100_000)]
        public void ApplyInterest_MultipleRates(double rate, double expected)
        {
            _account.ApplyInterest(rate);

            Assert.That(_account.Balance, Is.EqualTo(expected));
        }

        [Test]
        public void ApplyInterest_Buggy_ValidRate_RevealBug()
        {
            var acc = new BankAccountBuggy("ACC002", 1_000_000);

            acc.ApplyInterest(0.05);

            // Buggy chỉ cộng 0.05 thay vì 50.000
            Assert.That(acc.Balance, Is.EqualTo(1_050_000),
                $"[BUG] ApplyInterest cộng thẳng rate thay vì Balance*rate! " +
                $"Thực tế: {acc.Balance}");
        }

        // rate <= 0 -> ArgumentException
        [Test]
        public void ApplyInterest_Buggy_InvalidRate_ShouldThrow()
        {
            var acc = new BankAccountBuggy("BUG", 1_000_000);
            Assert.Throws<ArgumentException>(() => acc.ApplyInterest(0));
        }
    }
}