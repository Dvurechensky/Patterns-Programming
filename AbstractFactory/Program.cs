/*  Абстрактная фабрика
    Предоставляет интерфейс для создания 
    групп связанных или зависимых объектов,
    не указывая их конкретный класс
 */

class Program
{
    static void Main()
    {
        var soldier = new Hero(new SoldierFactory());
        soldier.Run();
        soldier.Hit();

        var elf = new Hero(new ElfFactory());
        elf.Run();
        elf.Hit();

        Console.ReadKey();
    }
}

//оружие базовая логика
abstract class Weapon
{
    public abstract void Hit();
}

//движение базовая логика
abstract class Movement
{
    public abstract void Move();
}

class Gun : Weapon
{
    public override void Hit()
    {
        Console.WriteLine("Hit Gun");
    }
}

class Arbalet : Weapon
{
    public override void Hit()
    {
        Console.WriteLine("Hit Arbalet");
    }
}

class Fly : Movement
{
    public override void Move()
    {
        Console.WriteLine("Hero Fly");
    }
}

class Run : Movement
{
    public override void Move()
    {
        Console.WriteLine("Hero Run");
    }
}

//клиент - супергерой
class Hero
{
    private Weapon Weapon { get; set; }
    private Movement Movement { get; set; }

    public Hero(HeroFactory factory)
    {
        Weapon = factory.CreateWeapon();
        Movement = factory.CreateMovement();
    }

    public void Run()
    {
        Movement.Move();
    }

    public void Hit()
    {
        Weapon.Hit();
    }
}

abstract class HeroFactory
{ 
    public abstract Weapon CreateWeapon();
    public abstract Movement CreateMovement();
}

class ElfFactory : HeroFactory
{
    public override Movement CreateMovement()
    {
        return new Fly();
    }

    public override Weapon CreateWeapon()
    {
        return new Arbalet();
    }
}

class SoldierFactory : HeroFactory
{
    public override Movement CreateMovement()
    {
        return new Run();
    }

    public override Weapon CreateWeapon()
    {
        return new Gun();
    }
}
