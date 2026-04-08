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

        public void ApplyInterest(double rate)
        {
            if (rate <= 0)
                throw new ArgumentException();

            // lãi kép
            Balance += Balance * rate;
        }
    }
    
    // 4 lỗi cho 4 module
    public class BankAccountBuggy
    {
        public string AccountId { get; private set; }
        public double Balance { get; private set; }

        public BankAccountBuggy(string accountId, double initialBalance)
        {
            AccountId = accountId;
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException();

            Balance += amount * 2; // đúng: Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException();

            if (amount > Balance)
                throw new InvalidOperationException();

            Balance -= amount * 2; // đúng: Balance -= amount;
        }

        public void Transfer(BankAccountBuggy target, double amount)
        {
            if (target == null)
                throw new ArgumentNullException();

            // bug: cộng trước rồi mới trừ
            target.Deposit(amount);
            Withdraw(amount);
        }

        public void ApplyInterest(double rate)
        {
            if (rate <= 0)
                throw new ArgumentException();

            Balance += rate; // đúng: Balance += Balance * rate;
        }
    }
}