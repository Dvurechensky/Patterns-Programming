/*  Цепочка обязанностей
    Избегает связывание отправителя запроса
    с его получателем, давая возможность обработать
    запрос более чем одному объекту. Связывает
    объекты-получатели и передаёт запрос по цепочке
    пока объект не обработает его.
 */
class Program
{
    static void Main()
    {
        Handler h1 = new ConcreateHandler1();
        Handler h2 = new ConcreateHandler2();
        h1.Successor = h2;
        h1.HandleRequest(2); //От первого до второго объекта обработка
        Console.Read();
    }
}

abstract class Handler
{
    public Handler Successor { get; set; }
    public abstract void HandleRequest(int condition);
}

class ConcreateHandler1 : Handler
{
    public override void HandleRequest(int condition)
    {   //какая-то обработка запроса
        Console.WriteLine("1");
        if(condition == 1)
            return;//завершаем выполнение
        else if(Successor != null) //передача запроса дальше по цепи
            Successor.HandleRequest(condition);
    }
}

class ConcreateHandler2 : Handler
{
    public override void HandleRequest(int condition)
    {   //какая-то обработка запроса
        Console.WriteLine("2");
        if (condition == 2)
            return;//завершаем выполнение
        else if (Successor != null) //передача запроса дальше по цепи
            Successor.HandleRequest(condition);
    }
}