/*  Одиночка
    Гарантирует что класс имеет только
    один экземпляр и представляет глобальную
    точку доступа к нему
 */

class Program
{
    static void Main()
    {
        (new Thread(() =>
        {
            Console.WriteLine(GameHistory.Instance.History[1]);
        })).Start();
        Console.WriteLine(GameHistory.Instance.History[0]);
        Console.ReadKey();
    }
}

class GameHistory
{
    private static object syncRoot = new Object();
    private static GameHistory _instance;
    public static GameHistory Instance
    {
        get
        {
            lock(syncRoot)
            {
                if(_instance == null)
                    _instance = new GameHistory();
            }
            return _instance;
        }
    }
    public string[] History { get; set; }
    private GameHistory()
    {
        History = new[] { "One History",
                            "Two History"}; 
    }
}