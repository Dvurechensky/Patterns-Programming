/*  Посредник
    Определяет объект инкапсулирующий способ
    взаимодействия объектов. Обеспечивает слабую связь,
    избавляя их от необходимости ссылаться друг на друга
    и даёт возможность независимо изменять их взаимодействие.
 */

class Program
{
    public static void Main(string[] args)
    {
        ManagerMediator mediator = new ManagerMediator();
        Colleague customer = new CustomerCollegue(mediator);
        Colleague programmer = new ProgrammerCollegue(mediator);
        Colleague tester = new TesterCollegue(mediator);
        mediator.Customer = customer;
        mediator.Programmer = programmer;
        mediator.Tester = tester;
        customer.Send("Есть заказ! Нужно сделать REST API");
        programmer.Send("REST API готов, нужно протестировать swagger");
        tester.Send("Тест прошёл успешно, документация отличная!");
        Console.Read();
    }
}

abstract class Mediator //интерфейс для взаимодействия с посредником
{
    public abstract void Send(string message, Colleague colleague);
}

abstract class Colleague //интерфейс для взаимодействия с коллегами
{
    Mediator Mediator { get; set; }

    public Colleague(Mediator mediator)
    {
        Mediator = mediator;
    }

    public virtual void Send(string message)
    {
        Mediator.Send(message, this);
    }

    public abstract void Notify(string message);
}

class CustomerCollegue : Colleague //непосредственный заказчик
{
    public CustomerCollegue(Mediator mediator) : base(mediator) {}

    public override void Notify(string message)
    {
        Console.WriteLine($"Сообщение заказчику: {message}");
    }
}

class ProgrammerCollegue : Colleague //программист
{
    public ProgrammerCollegue(Mediator mediator) : base(mediator) { }

    public override void Notify(string message)
    {
        Console.WriteLine($"Сообщение программисту: {message}");
    }
}

class TesterCollegue : Colleague //тестировщик
{
    public TesterCollegue(Mediator mediator) : base(mediator) { }

    public override void Notify(string message)
    {
        Console.WriteLine($"Сообщение тестировщику: {message}");
    }
}

class ManagerMediator : Mediator
{
    public Colleague Customer { get; set; }
    public Colleague Programmer { get; set; }
    public Colleague Tester { get; set; }

    public override void Send(string message, Colleague colleague)
    {
        //если отправитель заказчик значит есть новый заказ
        //отправляем сообщение программисту - сделать заказ
        if(Customer == colleague)
            Programmer.Notify(message);
        //если отправитель программист значит приступаем к тестированию
        else if(Programmer == colleague)
            Tester.Notify(message);
        //если отправитель тестировщик значит оповещаем заказчика о готовности задачи
        else if(Tester == colleague)
            Customer.Notify(message);
    }
}