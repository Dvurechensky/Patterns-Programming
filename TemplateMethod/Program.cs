/*  Шаблонный метод  
    Определяет алгоритм, некоторые этапы которого
    делегируются подклассам. Позволяет подклассам
    переопределить эти этапы, не меняя структуру алгоритма.
 */

class Program
{
    public static void Main(string[] args)
    {
        new School().Learn();
        new University().Learn();
        Console.Read();
    }
}

abstract class Education
{
    public virtual void Learn()
    {
        Enter();
        Study();
        PassExams();
        GetDocument();
    }

    protected abstract void GetDocument(); //получение документа об окончании образования
    protected abstract void PassExams(); //сдача экзаменов в учебном заведении
    protected abstract void Study(); //обучение в учебном заведении
    protected abstract void Enter(); //поступление в учебное заведение
}

class School : Education
{
    protected override void Enter()
    {
        Console.WriteLine("Поступил в школу");
    }

    protected override void GetDocument()
    {
        Console.WriteLine("Получил аттестат");
    }

    protected override void PassExams()
    {
        Console.WriteLine("Сдал ЕГЭ и ОГЭ");
    }

    public void ExtraExams()
    {
        Console.WriteLine("Ходил на олимпиады");
    }

    protected override void Study()
    {
        Console.WriteLine("Обучился 11 классов");
    }

    public override void Learn()
    {
        base.Learn();
        ExtraExams();
    }
}

class University : Education
{
    protected override void Enter()
    {
        Console.WriteLine("Поступил в университет");
    }

    protected override void GetDocument()
    {
        Console.WriteLine("Получил диплом");
    }

    protected override void PassExams()
    {
        Console.WriteLine("Сдал экзамены и зачёты");
    }

    protected override void Study()
    {
        Console.WriteLine("Ходил на пары");
        Console.WriteLine("Ходил на лекции");
        Console.WriteLine("Сдавал лабораторные работы");
    }
}