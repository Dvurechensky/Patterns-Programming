/*  Итератор
    Предоставляет способ последовательного
    доступа к множеству, независимо от его
    внутреннего устройства
 */

class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();
        Reader reader = new Reader();
        reader.SetBooks(library);
        Console.ReadKey();
    }
}

class Reader
{
    public void SetBooks(Library library)
    {
        IBookIterator iterator = library.CreateNumerator();
        while(iterator.HasNext())
        {
            Book book = iterator.Next();
            Console.WriteLine(book.Name);
        }
    }
}

interface IBookIterator
{
    bool HasNext();
    Book Next();
}

interface IBookNumerable
{
    IBookIterator CreateNumerator();
    int Count { get; }
    Book this[int index] { get; }
}

class Book
{
    public string Name { get; set; }
}

class Library : IBookNumerable
{
    private Book[] Books { get; set; }

    public Library()
    {
        Books = new Book[]
        {
            new Book(){ Name = "James"},
            new Book(){ Name = "Karl"},
            new Book(){ Name = "Rogan"}
        };
    }

    public Book this[int index] => Books[index];

    public int Count => Books.Length;

    public IBookIterator CreateNumerator() => new LibraryNumenator(this);
}

class LibraryNumenator : IBookIterator
{
    IBookNumerable Aggregate { get; set; }
    int index = 0;

    public LibraryNumenator(IBookNumerable bookNumerable) //передали коллекцию книг в Library
    {
        Aggregate = bookNumerable;
    }

    public bool HasNext() => index < Aggregate.Count;

    public Book Next() => Aggregate[index++];
}
