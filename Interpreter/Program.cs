/*  Интерпретатор
    Получая формальный язык, определяет
    представление его грамматики и интерпретатор,
    использующий это представление для обработки
    выражений языка (Применяется для часто повторяющихся операций)
 */
class Program
{
    public static void Main(string[] args)
    {
        var context = new Context();
        //создаём переменные
        int x = 5;
        int y = 8;
        int z = 2;
        //задаём переменные в контекст
        context.SetVariable("x", x);
        context.SetVariable("y", y);
        context.SetVariable("z", z);
        //x + y - z
        var expressionAdd = new AddExpression(new NumberExpression("x"), 
                                              new NumberExpression("y"));
        var expressionSub = new SubstructExpression(expressionAdd, 
                                                    new NumberExpression("z"));
        Console.WriteLine(expressionSub.Interpret(context));
        Console.Read();
    }
}

class Context
{
    Dictionary<string, int> variables;

    public Context()
    {
        variables = new Dictionary<string, int>();
    }

    public int GetVariable(string name)
    {
        if(variables.ContainsKey(name))
            return variables[name];
        else
            return -1;
    }

    public void SetVariable(string name, int value)
    {
        if(variables.ContainsKey(name))
            variables[name] = value;
        else
            variables.Add(name, value);
    }
}

interface IExpression //интерфейс интерпретатора
{
    int Interpret(Context context);
}

class NumberExpression : IExpression //терминальное выражение
{
    string Name { get; set; }
    public NumberExpression(string name)
    {
        Name = name;
    }

    public int Interpret(Context context)
    {
        return context.GetVariable(Name);
    }
}

class AddExpression : IExpression // нетерминальное выражение для сложения
{
    IExpression LeftExpression { get; set; }
    IExpression RightExpression { get; set; }

    public AddExpression(IExpression left, IExpression right)
    {
        LeftExpression = left;
        RightExpression = right;
    }

    public int Interpret(Context context)
    {
        return LeftExpression.Interpret(context) + RightExpression.Interpret(context);
    }
}

class SubstructExpression : IExpression // нетерминальное выражение для вычитания
{
    IExpression LeftExpression { get; set; }
    IExpression RightExpression { get; set; }

    public SubstructExpression(IExpression left, IExpression right)
    {
        LeftExpression = left;
        RightExpression = right;
    }

    public int Interpret(Context context)
    {
        return LeftExpression.Interpret(context) - RightExpression.Interpret(context);
    }
}