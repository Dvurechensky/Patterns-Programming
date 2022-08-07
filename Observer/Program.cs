/*  Наблюдатель
    Определяет зависимость один ко многим
    между объектами так, что когда один меняет
    своё состояние, все зависимые объекты оповещаются
    и обновляются автоматически
 */
class Program
{
    static void Main()
    {
        var concreteObservable = new ConcreteObservable();
        concreteObservable.AddObserver(new Observer("Job"));
        concreteObservable.AddObserver(new Observer("Robin"));
        concreteObservable.AddObserver(new Observer("Jaz"));
        Console.Read();
    }
}

interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

class ConcreteObservable : IObservable
{
    private List<IObserver> _observers;

    public ConcreteObservable()
    {
        _observers = new List<IObserver>();
    }

    public void AddObserver(IObserver observer)
    {
        NotifyObservers();
        _observers.Add(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
            observer.Update();
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
        NotifyObservers();
    }
}

interface IObserver
{
    void Update();
}

class Observer : IObserver
{
    public string Name { get; set; }

    public Observer(string name)
    {
        Name = name;
    }

    public void Update()
    {
        Console.WriteLine($"Update {Name}");
    }
}