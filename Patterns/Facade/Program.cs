/*  Фасад
    Предоставляет единый интерфейс к группе
    интерфейсов подсистемы. Определяет высокоуровневый
    интерфейс, делая систему проще для использования.
 */

class Program
{
    static void Main()
    {
        var facade = new Facade(new A(), new B());
        facade.Start();
        Console.ReadKey();
    }
}

class Facade
{
    ILogic logic1;
    ILogic logic2;
    public Facade(ILogic logic1, ILogic logic2)
    {
        this.logic1 = logic1;
        this.logic2 = logic2;
    }

    public void Start()
    {
        logic1.Process();
        logic2.Process();
    }
}

interface ILogic
{
    void Process();
}


class A : ILogic
{
    public void Process()
    {
        Console.WriteLine("Some Process " + GetType().Name);
    }
}

class B : ILogic
{
    public void Process()
    {
        Console.WriteLine("Some Process " + GetType().Name);
    }
}