/* Гибкий(плавный, текучий) строитель (интерфейс)
    Позволяет упростить процесс создания сложных 
    объектов с помощью методов-цепочек, которые 
    наделяют объект каким-то определенным качеством
 */

class Program
{
    static void Main()
    {
        User user = new User().Create().SetName("Alex").SetPassword("admin");
        Console.WriteLine(user);
        Console.ReadKey();
    }
}

class User
{
    public string Name { get; set; }
    public string Password { get; set; }

    public UserBuilder Create()
    {
        return new UserBuilder();
    }

    public override string ToString()
    {
        return $"Name {Name}, Password {Password}";
    }
}

//гибкий строитель конфигурации User
class UserBuilder
{
    private User CurrentUser { get; set; } 
    public UserBuilder()
    {
        CurrentUser = new User();
    }

    public UserBuilder SetName(string name)
    {
        CurrentUser.Name = name;
        return this;
    }

    public UserBuilder SetPassword(string password)
    {
        CurrentUser.Password = password;
        return this;
    }

    //преобразуем тип Builder в тип User для которого он использовался
    public static implicit operator User(UserBuilder builder)
    {
        return builder.CurrentUser;
    }
}