//ссылочные лежат в куче, значимые (ссылка в куче, значение в стеке)
namespace Base;

//шаблон, по которому определяется форма объекта (ссылочный тип)
class Program
{
    static void Main()
    {
        ClassMain classMain = new ClassMain();
        classMain.ResizeExt();
        Console.Read();
    }
}

//интерфейс - это контракт (о том что должен содержать class или struct)(ссылочный тип)
//общий признак для разнородных объектов
internal interface IInterTest
{
    //декларация (метод без реализации по умолчанию)
    void Build(int build = 0);
    //операция без реализации (абстрактный метод или же сигнатура)
    abstract void Reload();
    string Name { get; set; }// (ссылочный тип)
    object ID { get; set; }// (ссылочный тип)
    delegate void Destiny();// (ссылочный тип)
    //после C# 8.0 можно указывать реализацию операции)
    void Relocate()
    {
        Console.WriteLine("Realize Relocate");
    }
}

//абстрактный класс
public abstract class AbstrTest
{
    //фиксированная операция с реализацией по умолчанию (метод)
    public void Move()
    {
        Console.WriteLine("Move Abstr");
    }

    //операция с реализацией по умолчанию (виртуальный метод)
    public virtual void Resize()
    {
        Console.WriteLine("Resize Abstr");
    }

    //сигнатура - операция без реализации (абстрактный метод или же сигнатура)
    public abstract void Open();
}

//(значимый тип) (нет деструктора, нет наследования)
public struct TestStruct : IInterTest
{
    public string Name { get; set; }
    public object ID { get; set; }

    public TestStruct()
    {
        Name = "Base";
        ID = (object)0;
    }

    public void Build(int build = 0)
    {
        Console.WriteLine($"Build TestStruct {build}");
    }

    public void Reload()
    {
        Console.WriteLine("Reload TestStruct");
    }
}


public class ClassMain : AbstrTest, IInterTest
{
    public int countBuild { get; set; }
    public string Name { get; set; }
    public object ID { get; set; }

    public ClassMain()
    {
        TestStruct testStruct = new TestStruct();
        Console.WriteLine($"TestStruct: {testStruct.Name}, {testStruct.ID}");
        Name = "Base";
        ID = (object)0;
        Move();
        Build();
        Reload();
        Resize();
        Open();
    }

    public ClassMain(int build, string name, object id)
    {
        countBuild = build;
        Name = name;
        ID = id;
        Move();
        Build(build);
        Reload();
        Resize();
        Open();
    }

    public virtual void GG()
    {
        Console.WriteLine("GG Virtual Method Class");
    }

    public void Build(int build = 0)
    {
        Console.WriteLine($"Build Interface Class {build}");
    }

    public void Reload()
    {
        Console.WriteLine("Reload Interface Abstract Method Class");
    }

    public override void Resize()
    {
        base.Resize();
        countBuild--;
        Console.WriteLine("Resize Class");
    }

    //переопределение сигнатуры в этом производном классе
    public override void Open()
    {
        Console.WriteLine("Open Abstract Method Class");
    }
}

internal class Nasled : ClassMain
{
    public override void GG()
    {
        base.GG();
    }
}
