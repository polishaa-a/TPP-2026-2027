using System.Data;
using System.Globalization;
using System.Net.Mail;

class Character
{
    string name;
    int hp;
    int power;
    static int count = 0;
    public Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;
    }
    public void Attack(Character target)
    {
        target.hp -= power;
        Console.WriteLine($"{name} атакует {target.name} на {power}");
    }
    public void GetStatus()
    {
        Console.WriteLine($"{name}, {hp}");
    }
    public static int HowMany()
    {
        return count;
    }
    public static bool IsValidStatus(int hp, int power)
    {
        return hp > 0 && power > 0;
    }

}
class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {

    }
}
class Enemy : Character
{
    public Enemy(string name, int hp, int power):base(name,hp, power)
    {

    }
}
class Program
{
    static void Main()
    {
        Player p1 = new Player("Poli", 100, 5);
        Enemy e1 = new Enemy("Li", 16, 23);
        p1.Attack(e1);
        p1.GetStatus();
        e1.GetStatus();
        Console.WriteLine(Character.HowMany());
        Console.WriteLine(Character.IsValidStatus(0, 55));

    }
}