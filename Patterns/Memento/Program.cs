/*  Хранитель + Одиночка
    Не нарушая инкапсуляцию, определяет
    и сохраняет внутреннее состояние объекта и
    позволяет позже восстановить объект в этом
    состоянии
 */
class Program
{
    public static void Main(string[] args)
    {
        using (var hero = new Hero())
        {
            hero.Shoot();
        }
        using (var heroMan = new Hero())
        {
            heroMan.RestoreState(GameHistory.Instance.History.Pop());
            heroMan.Shoot();
        }
        Console.ReadKey();
    }
}

class Hero : IDisposable
{
    private int patrons = 10; //кол-во патронов

    public void Shoot()
    {
        if(patrons > 0)
        {
            patrons--;
            Console.WriteLine($"Осталось {patrons} патронов...");
        }
        else
            Console.WriteLine("Нет патронов");
    }

    public HeroMemento SaveState()
    {
        Console.WriteLine($"Сохранено - {patrons}");
        return new HeroMemento(patrons);
    }

    public void RestoreState(HeroMemento memento)
    {
        patrons = memento.Patrons;
        Console.WriteLine($"Загружено - {patrons}");
    }

    public void Dispose()
    {
        GameHistory.Instance.History.Push(SaveState());
    }
}

class HeroMemento //Memento - Хранитель состояния
{
    public int Patrons { get; private set; }

    public HeroMemento(int patrons)
    {
        Patrons = patrons;
    }
}

class GameHistory //Caretaker - смотритель состояния
{
    private static GameHistory instance;
    public Stack<HeroMemento> History { get; set; }

    private GameHistory()
    {
        History = new Stack<HeroMemento>();
    }

    public static GameHistory Instance
    {
        get
        {
            if(instance == null)
                instance = new GameHistory();
            return instance;
        }
    }

    public void Clear()
    {
        History.Clear();
    }
}