using NUnit.Framework;
using BankSystem;

namespace BankSystem.Tests
{
    public class WithdrawTests
    {
        private BankAccount _account;

        [SetUp]
        public void SetUp()
        {
            _account = new BankAccount("ACC001", 1_000_000);
        }

        // rút hợp lệ

        [Test]
        public void Withdraw_1_DecreaseCorrectly()
        {
            _account.Withdraw(1);

            Assert.That(_account.Balance, Is.EqualTo(999_999),
                "Lỗi nếu rút 1 mà không trừ.");
        }

        [Test]
        public void Withdraw_NormalAmount_DecreaseCorrectly()
        {
            _account.Withdraw(300_000);

            Assert.That(_account.Balance, Is.EqualTo(700_000));
        }

        [Test]
        public void Withdraw_AllMoney_BalanceZero()
        {
            _account.Withdraw(1_000_000);

            Assert.That(_account.Balance, Is.EqualTo(0));
        }


        // input lỗi

        [Test]
        public void Withdraw_Zero_Throw()
        {
            Assert.Throws<ArgumentException>(
                () => _account.Withdraw(0));
        }

        [Test]
        public void Withdraw_Negative_Throw()
        {
            Assert.Throws<ArgumentException>(
                () => _account.Withdraw(-50_000));
        }


        // vượt số dư

        [Test]
        public void Withdraw_TooMuch_Throw()
        {
            Assert.Throws<InvalidOperationException>(
                () => _account.Withdraw(2_000_000));
        }


        // lỗi thì không được làm thay đổi số dư

        [Test]
        public void Withdraw_Fail_BalanceNotChange()
        {
            double before = _account.Balance;

            try
            {
                _account.Withdraw(9_999_999);
            }
            catch (InvalidOperationException) { }

            Assert.That(_account.Balance, Is.EqualTo(before));
        }


        // test nhiều case cho gọn

        [TestCase(1)]
        [TestCase(500_000)]
        [TestCase(1_000_000)]
        public void Withdraw_MultipleCases(double amount)
        {
            double expected = _account.Balance - amount;

            _account.Withdraw(amount);

            Assert.That(_account.Balance, Is.EqualTo(expected));
        }

        // So sánh: phiên bản đúng phải PASS cùng kịch bản
        [Test]
        public void Withdraw_CorrectVersion_ForComparison()
        {
            _account.Withdraw(200_000);
            Assert.That(_account.Balance, Is.EqualTo(800_000));
        }
    }
}