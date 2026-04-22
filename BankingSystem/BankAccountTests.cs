namespace BankSystem
{
    public class BankAccount
    {
        public string AccountId { get; private set; }
        public double Balance { get; private set; }

        public BankAccount(string accountId, double initialBalance)
        {
            AccountId = accountId;
            Balance = initialBalance;
        }

        // + tiền
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Số tiền nạp phải > 0");

            Balance += amount;
        }

        // rút tiền
        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException(); // True nếu tiền rút <= 0

            if (amount > Balance)
                throw new InvalidOperationException(); // True nếu rút nhiều hơn số dư

            Balance -= amount;
        }

        public void Transfer(BankAccount target, double amount)
        {
            if (target == null)
                throw new ArgumentNullException();

            // bắt buộc phải trừ trước
            Withdraw(amount);

            target.Deposit(amount);
        }

        public void PayBill(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException();

            double fee = 2000; // phí cố định
            if (amount + fee > Balance)
                throw new InvalidOperationException();

            Balance -= (amount + fee);
        }
    }
}