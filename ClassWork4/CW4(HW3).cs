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
    public virtual string ToString()
    {
        return $"{Name} (HP: {Hp})";
    }
    public virtual static int HowMany()
    {
        return count;
    }
    public virtual static bool IsValidStatus(int hp, int power)
    {
        return hp > 0 && power > 0;
    }
    public virtual int TakeDamage(int damage)
    {
        this.hp -= damage;
        return hp;
    }
    public virtual bool IsAlive()
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
        List<Character> characters = new List<Character>
        {
            new Player("Poli", 100, 5),
            new Enemy("Varya S", 16, 23)
        };
        Character p1 = characters[0];
        Character e1 = characters[1];
        while (p1.IsAlive() && e1.IsAlive())
        {
            p1.Attack(e1);
            Console.WriteLine(e1);
            if (!e1.IsAlive())
            {
                Console.WriteLine($"{e1} побеждён! {p1} выиграл.");
                break;
            }
            e1.Attack(p1);
            Console.WriteLine(p1);
            if (!p1.IsAlive())
            {
                Console.WriteLine($"{p1} побеждён! {e1} выиграл.");
                break;
            }
        }
        Console.WriteLine(Character.HowMany());
        Console.WriteLine(Character.IsValidStatus(0, 55));
    }
}

