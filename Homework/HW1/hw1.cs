using System;

public class Bank
{
    public void Show(double a)
    {
        Console.WriteLine(a);
    }
    public double Add(double a, double b, List<string> history)
    {
        if (b > 0)
        {
            a = a + b;
            history.Add("Пополнение на " + b);
        }
        else
        {
            Console.WriteLine("Сумма должна быть больше нуля!");
        }
        return a;
    }
    public double Withdraw(double a, double c, List<string> history)
    {
        if (c <= 0)
        {
            Console.WriteLine("Сумма должна быть больше нуля!");
        }
        else if (c > a)
        {
            Console.WriteLine("Недостаточно средств на счёте!");
        }
        else
        {
            a = a - c;
            history.Add("Снятие: -" + c);
        }
        return a;
    }
    public void ShowHistory(List<string> history)
    {
        if (history.Count == 0)
        {
            Console.WriteLine("История операций отсутствует");
            return;
        }
        Console.WriteLine("История операций: ");
        for (int i = 0; i < history.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + history[i]);
        }
    }
}
class Program
{
    static void Main()
    {
        Bank bank = new Bank();
        Console.WriteLine("Введите ваш баланс: ");
        double balance = double.Parse(Console.ReadLine());
        List<string> history = new List<string>();
        int num = -1;
        while (num != 0)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите номер операции :");
            num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                bank.Show(balance);
            }
            else if (num == 2)
            {
                Console.WriteLine("Введите сумму пополнения: ");
                double amount = double.Parse(Console.ReadLine());
                balance = bank.Add(balance, amount, history);
            }
            else if (num == 3)
            {
                Console.WriteLine("Введите сумму снятия: ");
                double amount = double.Parse(Console.ReadLine());
                balance = bank.Withdraw(balance, amount, history);
            }
            else if (num == 4)
            {
                bank.ShowHistory(history);
            }
            else if (num == 0)
            {
                Console.WriteLine("Выход из программы");
            }
            else
            {
                Console.WriteLine("Неверный номер операции");
            }
        }
    }
}