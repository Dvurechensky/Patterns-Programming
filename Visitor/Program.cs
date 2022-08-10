/*  Посетитель  
    Представляет собой операцию, которая
    будет выполнена над объектами группы классов.
    Даёт возможность определить новую операцию
    без изменения кода классов, над которыми
    эта операция производитcя.
 */

class Program
{
    public static void Main(string[] args)
    {
        var bank = new Bank();
        bank.Add(new Person(Name: "Joshua", Number: 1997));
        bank.Add(new Company(Name: "Microsoft", Number: 1904));
        bank.Accept(new HtmlVisitor());
        bank.Accept(new XmlVisitor());
        Console.Read();
    }
}

//абстрактный класс Element
interface IAccaunt
{
    void Accept(IVisitor visitor);
}

class Bank
{
    List<IAccaunt> Accaunts;

    public Bank()
    {
        Accaunts = new List<IAccaunt>();
    }

    public void Add(IAccaunt accaunt)
    {
        Accaunts.Add(accaunt);
    }

    public void Remove(IAccaunt accaunt)
    {
        Accaunts.Remove(accaunt);
    }

    public void Accept(IVisitor visitor)
    {
        foreach (var accaunt in Accaunts)
            accaunt.Accept(visitor);
    }
}

record Person(string Name, int Number) : IAccaunt
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitPersonAcc(this);
    }
}

record Company(string Name, int Number) : IAccaunt
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitCompanyAcc(this);
    }
}

//абстрактный класс посетителя
//отделяет логику сериализации от классов в которых она применима
interface IVisitor
{
    void VisitPersonAcc(Person person);
    void VisitCompanyAcc(Company company);
}

//сериализатор в HTML
class HtmlVisitor : IVisitor
{
    public void VisitCompanyAcc(Company company)
    {
        Console.WriteLine($"[HTML] {company}");
    }

    public void VisitPersonAcc(Person person)
    {
        Console.WriteLine($"[HTML] {person}");
    }
}

//сериализатор в XML
class XmlVisitor : IVisitor
{
    public void VisitCompanyAcc(Company company)
    {
        Console.WriteLine($"[XML] {company}");
    }

    public void VisitPersonAcc(Person person)
    {
        Console.WriteLine($"[XML] {person}");
    }
}