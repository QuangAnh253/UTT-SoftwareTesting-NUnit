using NUnit.Framework;
using BankSystem;

namespace BankSystem.Tests
{
    [TestFixture]
    public class TransferTests
    {
        private BankAccount _source;
        private BankAccount _target;

        [SetUp]
        public void SetUp()
        {
            _source = new BankAccount("ACC001", 1_000_000);
            _target = new BankAccount("ACC002", 500_000);
        }

        [Test]
        public void Transfer_ValidAmount_UpdateBoth()
        {
            _source.Transfer(_target, 400_000);

            Assert.That(_source.Balance, Is.EqualTo(600_000));
            Assert.That(_target.Balance, Is.EqualTo(900_000));
        }

        [Test]
        public void Transfer_ExactBalance_SourceZero()
        {
            _source.Transfer(_target, 1_000_000);

            Assert.That(_source.Balance, Is.EqualTo(0));
            Assert.That(_target.Balance, Is.EqualTo(1_500_000));
        }

        [Test]
        public void Transfer_MinAmount_WorkCorrect()
        {
            _source.Transfer(_target, 1);

            Assert.That(_source.Balance, Is.EqualTo(999_999));
            Assert.That(_target.Balance, Is.EqualTo(500_001));
        }

        [Test]
        public void Transfer_TargetNull_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(
                () => _source.Transfer(null, 100_000)
            );
        }

        [Test]
        public void Transfer_ExceedBalance_TargetNotChange()
        {
            try
            {
                _source.Transfer(_target, 9_999_999);
            }
            catch (InvalidOperationException) { }

            Assert.That(_target.Balance, Is.EqualTo(500_000));
        }

        [Test]
        public void Transfer_ExceedBalance_SourceNotChange()
        {
            try
            {
                _source.Transfer(_target, 9_999_999);
            }
            catch (InvalidOperationException) { }

            Assert.That(_source.Balance, Is.EqualTo(1_000_000));
        }

        [TestCase(1, 999_999, 500_001)]
        [TestCase(500_000, 500_000, 1_000_000)]
        [TestCase(1_000_000, 0, 1_500_000)]
        public void Transfer_MultipleAmounts(double amount, double expectedSource, double expectedTarget)
        {
            _source.Transfer(_target, amount);

            Assert.That(_source.Balance, Is.EqualTo(expectedSource));
            Assert.That(_target.Balance, Is.EqualTo(expectedTarget));
        }
    }
}