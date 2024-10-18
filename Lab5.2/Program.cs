using System;

// Інтерфейс для роботи з рахунками
interface IAccount
{
    void NewAccount();     // Метод для створення нового рахунку
    void DeleteAccount();  // Метод для видалення рахунку
}

// Базовий клас "Банківський рахунок"
public abstract class BankAccount : IAccount
{
    public int AccountNumber { get; protected set; }
    public decimal Balance { get; protected set; }

    public BankAccount(int accountNumber)
    {
        AccountNumber = accountNumber;
        Balance = 0;
    }

    // Реалізація інтерфейсного методу для створення нового рахунку
    public void NewAccount()
    {
        Console.WriteLine($"Новий рахунок #{AccountNumber} створено з початковим балансом {Balance} грн.");
    }

    // Реалізація інтерфейсного методу для видалення рахунку
    public void DeleteAccount()
    {
        Console.WriteLine($"Рахунок #{AccountNumber} видалено.");
    }

    // Абстрактні методи для поповнення та зняття коштів
    public abstract void Deposit(decimal amount);  // Метод поповнення
    public abstract void Withdraw(decimal amount); // Метод зняття коштів
}

// Клас "Поточний рахунок"
public class CurrentAccount : BankAccount
{
    public CurrentAccount(int accountNumber) : base(accountNumber) { }

    // Реалізація поповнення рахунку
    public override void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Поточний рахунок #{AccountNumber} поповнено на {amount} грн. Баланс: {Balance} грн.");
    }

    // Реалізація зняття коштів з рахунку
    public override void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine($"Недостатньо коштів на поточному рахунку #{AccountNumber}.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"З поточного рахунку #{AccountNumber} знято {amount} грн. Баланс: {Balance} грн.");
        }
    }
}

// Клас "Депозитний рахунок"
public class DepositAccount : BankAccount
{
    public DepositAccount(int accountNumber) : base(accountNumber) { }

    // Реалізація поповнення рахунку
    public override void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Депозитний рахунок #{AccountNumber} поповнено на {amount} грн. Баланс: {Balance} грн.");
    }

    // Реалізація зняття коштів з рахунку
    public override void Withdraw(decimal amount)
    {
        // Для депозитного рахунку можна додати певні умови для зняття коштів
        if (amount > Balance)
        {
            Console.WriteLine($"Недостатньо коштів на депозитному рахунку #{AccountNumber}.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"З депозитного рахунку #{AccountNumber} знято {amount} грн. Баланс: {Balance} грн.");
        }
    }
}

// Основна програма
class Program
{
    static void Main(string[] args)
    {
        // Створюємо поточний рахунок
        CurrentAccount current = new CurrentAccount(1001);
        current.NewAccount();
        current.Deposit(500);
        current.Withdraw(200);

        // Створюємо депозитний рахунок
        DepositAccount deposit = new DepositAccount(2002);
        deposit.NewAccount();
        deposit.Deposit(1000);
        deposit.Withdraw(500);

        // Видаляємо рахунки
        current.DeleteAccount();
        deposit.DeleteAccount();
    }
}
