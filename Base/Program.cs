//ссылочные лежат в куче, значимые (ссылка в куче, значение в стеке)
using Newtonsoft.Json;

namespace Base;

//шаблон, по которому определяется форма объекта (ссылочный тип)
class Program
{
    static void Main()
    {
        IInterTest interTest = new ClassMain();
        interTest.ResizeExt();//static
        interTest.Relocate(); //объявлен и реализован в самом интерфейсе
        var Records = new Records(1, "rec1");
        var (NameS, idS) = Records; //можно разложить класс на переменные
        var RecNew = Records with { Name = "rec2" };//можно инициализировать другйо класс на основе данных первого
        Console.WriteLine($"{NameS} {idS}");
        var (NameS2, idS2) = RecNew; //можно разложить класс на переменные
        Console.WriteLine($"{NameS2} {idS2}");
        Console.WriteLine(Records == RecNew); //можно сравнить классы обычными операторами сравнения
        Console.WriteLine();
        Console.WriteLine(RecNew);//можно напечать JSON представление содержимого класса по умолчанию
        Console.WriteLine(Records);//можно напечать JSON представление содержимого класса по умолчанию
        var json = JsonConvert.SerializeObject(Records, Formatting.Indented);
        Console.WriteLine(json);
        var otherSideRecord = JsonConvert.DeserializeObject<Records>(json);
        Console.WriteLine(otherSideRecord);
        Records = Records with { Id = 10};
        Console.WriteLine(Records);
        Console.ReadKey();
    }
}

// *** это абстракция которая отвечает за контракт взаимодействия для различных типов
//интерфейс - это контракт взаимодействия (поведение) (о том что должен содержать class или struct)(ссылочный тип)
//общий признак для разнородных объектов (описываются только сигнатуры методов до C# 8.0) 
public interface IInterTest
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
        Console.WriteLine("->IInterTest: Relocate");
    }
}

//абстрактный класс
public abstract class AbstrTest
{
    public int key = 100;
    public string Name { get; set; }

    public AbstrTest()
    {
        key = 110;
        Name = "Fire";

        Console.WriteLine($"->>>AbstrTest {Name} {key}");
    }

    public AbstrTest(int key)
    {
        this.key = key;
        Name = "Fire";

        Console.WriteLine($"->>>AbstrTest {Name} {key}");
    }

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

//реализация поведения (ссылочный тип)
public class ClassMain : AbstrTest, IInterTest
{
    public int countBuild { get; set; }
    public string Name { get; set; }
    public object ID { get; set; }

    public ClassMain() : base (0)
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

    public ClassMain(int build, string name, object id) : base(build)
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

    ~ClassMain()
    {
        Console.WriteLine("###Destroy ClassMain");
    }
}

public class Nasled : ClassMain
{
    public override void GG()
    {
        base.GG();
    }
}


public record class Records
{
    // Свойства
    public int Id { get; init; }
    public string Name { get; init; }
    public Records(int id, string name)
    {
        Id = id;
        Name = name;
        Console.WriteLine("Construct");
    }
    // Деконструктор
    public void Deconstruct(out string name, out int id)
    {

        name = Name;
        id = Id;
        Console.WriteLine("Destruct");
    }
}

