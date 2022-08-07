/*  Стратегия  
    Определяет группу алгоритмов,
    инкапсулирует их и делает взаимозаменяемыми.
    Позволяет изменять алгоритм независимо от клиентов,
    его использующих.
 */
class Program
{
    public static void Main(string[] args)
    {
        var car = new Car(new PetrolMove());
        car.Move();
        car.Movable = new ElectronicMove();
        car.Move();
        Console.Read();
    }
}

interface IMovable
{
    void Move();
}

class PetrolMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Движение на бензине");
    }
}

class ElectronicMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Движение на электричестве");
    }
}

class Car
{
    public IMovable Movable { private get; set; } //способ передвижения автомобиля

    public Car(IMovable movable)
    {
        Movable = movable;
    }

    public void Move()
    {
        Movable.Move();
    }
}
