/*  Адаптер
    Конвенртирует интерфейс класса в другой интерфейс,
    ожидаемый клиентом. Позволяет классам 
    с разными интерфейсами работать вместе.
 */

class Program
{
    static void Main()
    {
        var man = new Driver();
        //машина она едет также как мотоцикл, всё отлично
        var car = new Auto();
        //но мы хотим добраться на пешем транспорте (на верблюде)
        var camelTransport = new CamelToTransport(new Camel());

        man.Travel(camelTransport);
        man.Travel(car);

        Console.ReadKey();
    }
}

interface ITransport
{
    void Drive();
}

//оно едет
class Auto : ITransport
{
    public void Drive()
    {
        Console.WriteLine(GetType().Name + " Move");
    }
}

class Camel
{
    public void Move()
    {
        Console.WriteLine(GetType().Name + " Move");
    }
}


//верблюд не едет но ходит
class CamelToTransport : ITransport
{
    Camel camel;

    public CamelToTransport(Camel camel)
    {
        this.camel = camel;
    }

    public void Drive()
    {
        camel.Move();
    }
}

//наш путешественник
class Driver
{
    public void Travel(ITransport transport)
    {
        transport.Drive();
    }
}