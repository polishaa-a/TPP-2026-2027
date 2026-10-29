using System;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Character
{
    string name;
    int hp;
    int power;
    static int count = 0;

    public Character(string name = "1", int hp = 0, int power = 0)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Power
    {
        get { return power; }
        set { power = value; }

    }
    public virtual void Attack(Character target)
    {
        target.TakeDamage(power);
        Console.WriteLine($"{name} атакует {target.name} на {power}");
    }
    public void GetStatus()
    {
        Console.WriteLine($"{Name}, {Hp}");
    }
    public static int HowMany()
    {
        return count;
    }
    public static bool IsValidStatus(int hp, int power)
    {
        return hp > 0 && power > 0;
    }
    public int TakeDamage(int damage)
    {
        this.hp -= damage;
        return hp;
    }
    public bool IsAlive()
    {
        return hp > 0;
    }
}
class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {
        this.Name = name;
        this.Hp = hp;
        this.Power = power;
    }
    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"{Name}  бъёт {target.Name} на {Power}");
    }
}
class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {
        this.Name = name;
        this.Hp = hp;
        this.Power = power;
    }
    public override void Attack(Character target)
    {
        target.TakeDamage(Power);
        Console.WriteLine($"{Name}  кусает {target.Name} на {Power}");
    }
}
class Program
{
    static void Main()
    {
        list<Character> characters = new list<Character>
        { 
            new Player("Poli", 100, 5);
            new Enemy("Varya S", 16, 23);
        }
        while(characters.IsAlive())
        {
            characters.Attack()
        }
        Console.WriteLine(Character.HowMany());
        Console.WriteLine(Character.IsValidStatus(0, 55));
    }
}
