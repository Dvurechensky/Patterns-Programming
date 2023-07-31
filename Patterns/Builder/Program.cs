/*  Строитель
    Разделяет создание сложного объекта
    и его инициализацию так, что одинаковый 
    процесс построения может может создавать
    объекты с разным состоянием
 */

class Program
{
    static void Main()
    {
        var rx = new Baker();
        var bread = rx.Bake(new RBuilderBread());
        Console.WriteLine(bread.ToString());
        Console.ReadKey();
    }
}

//мука
class Floor
{
    //Сорт муки
    public string Sort { get; set; }
}

//Соль
class Salt
{ 
    //Масса
    public double Mass { get; set; }
}

//Пищевые добавки
class Additives
{
    //Список пищевых добавок
    public string[] Names { get; set; }
}

//Сам хлеб
class Bread
{ 
    public Floor Floor { get; set; }
    public Salt Salt { get; set; }
    public Additives Additives { get; set; }

    public override string ToString()
    {
        return $"[F: {Floor.Sort}]---[S: {Salt.Mass}]---[A: {Additives.Names[0]}]";
    }
}

abstract class BreadBuilder
{
    public Bread Bread { get; set; }
    public void CreateBread()
    {
        Bread = new Bread();
    }

    public abstract void SetFloor();
    public abstract void SetSalt();
    public abstract void SetAdditives();
}

//пекарь
class Baker
{
    public Bread Bake(BreadBuilder breadBuilder)
    {
        breadBuilder.CreateBread();
        breadBuilder.SetFloor();
        breadBuilder.SetSalt();
        breadBuilder.SetAdditives();
        return breadBuilder.Bread;
    }
}


//для ржаного хлеба строитель
class RBuilderBread : BreadBuilder
{
    public override void SetAdditives()
    {
        Bread.Additives = new Additives() { Names = new[] { "E222", "E297" } };
    }

    public override void SetFloor()
    {
        Bread.Floor = new Floor() { Sort = "R class" };
    }

    public override void SetSalt()
    {
        Bread.Salt = new Salt() { Mass = 3.44 };
    }
}
