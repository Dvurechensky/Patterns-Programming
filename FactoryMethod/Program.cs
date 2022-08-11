/*  Фабричный метод
    Определяет интерфейс для создания объекта,
    но позволяет подклассам решать, какой класс создавать.
    Позволяет делегировать создание класса
    объектам класса.
 */

class Program
{
    static void Main()
    {
        var ltd = new WoodDeveloper();
        ltd.Create();

        var rss = new OfficeDeveloper();
        rss.Create();

        Creator<WoodDeveloper> ltdEx = new Creator<WoodDeveloper>();
        var a1 = ltdEx.FactoryMethod();
        a1.Create();
        Creator<OfficeDeveloper> rssEx = new Creator<OfficeDeveloper>();
        var a2 = rssEx.FactoryMethod();
        a2.Create();

        Console.ReadKey();
    }
}

//*** представления через обобщения (нельзя инициализировать через параметризированный конструктор)
class Creator<T> where T : Developer, new()
{
    public T FactoryMethod() { return new T(); }
}

//строительная компания - базовая логика
abstract class Developer
{
    protected string Name { get; set; }

    public Developer(string name)
    {
        Name = name;
    }

    public abstract House Create();//фабричный метод
}

class WoodDeveloper : Developer
{
    public WoodDeveloper() : base("Wood Develop LTD")
    {
    }

    public override House Create()
    {
        return new PanelHouse();
    }
}

class OfficeDeveloper : Developer
{
    public OfficeDeveloper() : base("Office Develop RSS")
    {
    }

    public override House Create()
    {
        return new OfficeHouse();
    }
}

abstract class House
{
    public abstract void Build();
}

class PanelHouse : House
{
    public PanelHouse()
    {
        Build();
    }

    public override void Build()
    {
        Console.WriteLine("Build Panel House");
    }
}

class OfficeHouse : House
{
    public OfficeHouse()
    {
        Build();
    }

    public override void Build()
    {
        Console.WriteLine("Build Office House");
    }
}