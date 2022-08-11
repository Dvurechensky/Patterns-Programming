using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;

class Program
{
    //Главное свойство dictionary — быстрый поиск с помощью ключей, Можно также добавлять и удалять элементы
    static Dictionary<string, object> _dictionary = new Dictionary<string, object>();
    //быстрее HashTable до 10-ти  элементов ListDictionary
    static ListDictionary LDictionary = new ListDictionary
    {
         { "key", "value"}
    };
    static HybridDictionary HDictionary = new HybridDictionary
    {
         { "key", "value"}
    };
    //вы хотите использовать ключи для поиска или foreach для итерации с помощью DictionaryEntry объектов
    //При просмотре большой коллекции чтение OrderedDictionary с использованием первого примера,
    //числового индекса, всегда будет быстрее, чем при использовании метода стиля словаря
    static OrderedDictionary ODictionary = new OrderedDictionary
            {
                {"01", "odin"},
                {"02", "dva"},
                {"03", "tri"},
                {"04", "chetiri"},
                {"06", "pyat"},
                {"07", "pyat"},
                {"08", "pyat"},
                {"09", "pyat"},
                {"10", "pyat"},
                {"11", "pyat"},
                {"12", "pyat"},
                {"13", "pyat"},
                {"14", "pyat"},
                {"15", "pyat"},
                {"16", "pyat"},
                {"17", "pyat"},
                {"18", "pyat"},
                {"19", "pyat"},
                {"20", "pyat"},
                {"21", "pyat"},
                {"22", "pyat"},
                {"23", "pyat"},
                {"24", "pyat"},
                {"25", "pyat"},
                {"26", "pyat"},
                {"27", "pyat"},
                {"28", "pyat"},
                {"29", "pyat"},
                {"30", "pyat"},
                {"31", "pyat"}
            };
    //дерево бинарного поиска, в котором все элементы отсортированы на основе ключа
    //быстрее вставляет и удаляет элементы
    static SortedDictionary<int, string> SDictionary = new SortedDictionary<int, string>();
    //потокобезопасная коллекция пар "ключ-значение", доступ к которой могут одновременно получать несколько потоков.
    //по умолчанию 4 потока на запись concurrencyLevel = 4
    //первоначальное число элементов 31 сapacity = 31
    //В отличие от обычного Dictionary, можно производить вставку в ConcurrentDictionary или удаление из него прямо во время перечисления
    static ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();

    static void Main()
    {
        //OrderedDictionary - быстрее если элементов больше 20-ти при цикле for
        //foreach быстрее for если элементов меньше 15-20
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for(int i = 0; i < ODictionary.Count; i++)
        {
            string val = (string)ODictionary[i];
            Console.WriteLine(val);
        }
        stopwatch.Stop();
        Console.WriteLine("1: " + stopwatch.Elapsed);
        stopwatch.Reset();
        stopwatch.Start();
        foreach (DictionaryEntry item in ODictionary)
        {
            Console.WriteLine(item.Value);
        }
        stopwatch.Stop();
        Console.WriteLine("2: " + stopwatch.Elapsed);
        Console.ReadKey();
    }
}