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
        #region Пример №1 - базовое
        var car = new Car(new PetrolMove());
        car.Move();
        car.Movable = new ElectronicMove();
        car.Move();
        Console.ReadKey();
        #endregion
    }
}

/// <summary>
/// Поведение движения
/// </summary>
interface IMovable
{
    void Move();
}

/// <summary>
/// Бензиновый двигатель
/// </summary>
class PetrolMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Движение на бензине");
    }
}

/// <summary>
/// Электродвигатель
/// </summary>
class ElectronicMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Движение на электричестве");
    }
}

/// <summary>
/// Автомобиль
/// </summary>
class Car
{
    /// <summary>
    /// Cпособ передвижения автомобиля
    /// </summary>
    public IMovable Movable { private get; set; }

    public Car(IMovable movable)
    {
        Movable = movable;
    }

    public void Move()
    {
        Movable.Move();
    }
}
