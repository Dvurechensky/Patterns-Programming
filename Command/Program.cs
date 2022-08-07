/*  Команда
    Инкапсулирует запрос в виде объекта
    позволяя передавать их клиентам в
    качестве параметров, ставить в очередь,
    логировать, а также поддерживать отмену
    операций
 */
class Program
{
    static void Main()
    {
        var initCommand = new Invoker(new ConcreteCommand(new Receiver()));
        initCommand.Run();
        initCommand.Cancel();
        Console.Read();
    }
}

abstract class Command
{
    public abstract void Execute();
    public abstract void Undo();
}

class ConcreteCommand : Command
{
    Receiver receiver;

    public ConcreteCommand(Receiver receiver)
    {
        this.receiver = receiver;
    }

    public override void Execute()
    {
        receiver.Operation();
    }

    public override void Undo()
    {
        Console.WriteLine("Stop");
    }
}

class Receiver //получатель поманды
{
    public void Operation()
    {
        Console.WriteLine("Processing...");
    }
}

class Invoker //инициатор команды
{
    Command command;

    public Invoker(Command command)
    {
        this.command = command;
    }
    
    public void Run()
    {
        command.Execute();
    }

    public void Cancel()
    {
        command.Undo();
    }
}