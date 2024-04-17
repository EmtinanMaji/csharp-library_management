using System;

public class LibraryItem
{
    public Guid Id { get; }
    public string Title { get; }
    public DateTime CreatedDate { get; }

    public LibraryItem(string title, DateTime? createdDate = null)
    {
        Id = Guid.NewGuid();
        Title = title;
        CreatedDate = createdDate ?? DateTime.Now;
    }
}

public class Book : LibraryItem
{
    public Book(string title, DateTime? createdDate = null) : base(title, createdDate) 
    { 

    }
}

public class User : LibraryItem
{
    public User(string name, DateTime? createdDate = null) : base(name, createdDate) 
    { 

    }
}

public class Library
{
    private List<Book> books = new List<Book>();
    private List<User> users = new List<User>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added successfully.");
    }

    public void AddUser(User user)
    {
        users.Add(user);
        Console.WriteLine($"User '{user.Title}' added successfully.");
    }

    public List<Book> FindBooksByTitle(string title)
    {
        var foundBooks = books.FindAll(b => b.Title.Contains(title)).ToList();
        if (foundBooks.Any())
        {
            Console.WriteLine($"Found {foundBooks.Count} book(s) with title '{title}':");
            foreach (var book in foundBooks)
            {
                Console.WriteLine($" - {book.Title}, Created Date: {book.CreatedDate.ToShortDateString()}");
            }
        }
        else
        {
            Console.WriteLine($"No books found with title '{title}'.");
        }
        return foundBooks;
    }

    public List<User> FindUsersByName(string name)
    {
        var foundUsers = users.FindAll(u => u.Title.Contains(name)).ToList();
        if (foundUsers.Any())
        {
            Console.WriteLine($"Found {foundUsers.Count} user(s) with name '{name}':");
            foreach (var user in foundUsers)
            {
                Console.WriteLine($" - {user.Title}, Created Date: {user.CreatedDate}");
            }
        }
        else
        {
            Console.WriteLine($"No users found with name '{name}'.");
        }
        return foundUsers;
    }

    public List<Book> GetBooks(int page, int pageSize)
    {
        var getBooks = books.OrderBy(b => b.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        Console.WriteLine($"Showing page {page} of books:");
        foreach (var book in getBooks)
        {
            Console.WriteLine($" - {book.Title}, Created Date: {book.CreatedDate}");
        }
        return getBooks;
    }

    public List<User> GetUsers(int page, int pageSize)
    {
        var getUsers = users.OrderBy(u => u.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        Console.WriteLine($"Showing page {page} of users:");
        foreach (var user in getUsers)
        {
            Console.WriteLine($" - {user.Title}, Created Date: {user.CreatedDate}");
        }
        return getUsers;
    }


    public void DeleteBook(Guid id)
    {
        Book bookToRemove = books.FirstOrDefault(b => b.Id == id);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Book with ID '{id}' deleted successfully.");
        }else{
            Console.WriteLine($"Book with ID '{id}' was not found");
        }
    }

    public void DeleteUser(Guid id)
    {
        User userToRemove = users.FirstOrDefault(u => u.Id == id);
        if (userToRemove != null)
        {
            users.Remove(userToRemove);
            Console.WriteLine($"User with ID '{id}' deleted successfully.");
        }else{
            Console.WriteLine($"User with ID '{id}' was not found");
        }
    }
}

internal class Program
{
    private static void Main()
    {
        var user1 = new User("Alice", new DateTime(2023, 1, 1));
        var user2 = new User("Bob", new DateTime(2023, 2, 1));
        var user3 = new User("Charlie", new DateTime(2023, 3, 1));
        var user4 = new User("David", new DateTime(2023, 4, 1));
        var user5 = new User("Eve", new DateTime(2024, 5, 1));
        var user6 = new User("Fiona", new DateTime(2024, 6, 1));
        var user7 = new User("George", new DateTime(2024, 7, 1));
        var user8 = new User("Hannah", new DateTime(2024, 8, 1));
        var user9 = new User("Ian");
        var user10 = new User("Julia");

        var book1 = new Book("The Great Gatsby", new DateTime(2023, 1, 1));
        var book2 = new Book("1984", new DateTime(2023, 2, 1));
        var book3 = new Book("To Kill a Mockingbird", new DateTime(2023, 3, 1));
        var book4 = new Book("The Catcher in the Rye", new DateTime(2023, 4, 1));
        var book5 = new Book("Pride and Prejudice", new DateTime(2023, 5, 1));
        var book6 = new Book("Wuthering Heights", new DateTime(2023, 6, 1));
        var book7 = new Book("Jane Eyre", new DateTime(2023, 7, 1));
        var book8 = new Book("Brave New World", new DateTime(2023, 8, 1));
        var book9 = new Book("Moby-Dick", new DateTime(2023, 9, 1));
        var book10 = new Book("War and Peace", new DateTime(2023, 10, 1));
        var book11 = new Book("Hamlet", new DateTime(2023, 11, 1));
        var book12 = new Book("Great Expectations", new DateTime(2023, 12, 1));
        var book13 = new Book("Ulysses", new DateTime(2024, 1, 1));
        var book14 = new Book("The Odyssey", new DateTime(2024, 2, 1));
        var book15 = new Book("The Divine Comedy", new DateTime(2024, 3, 1));
        var book16 = new Book("Crime and Punishment", new DateTime(2024, 4, 1));
        var book17 = new Book("The Brothers Karamazov", new DateTime(2024, 5, 1));
        var book18 = new Book("Don Quixote", new DateTime(2024, 6, 1));
        var book19 = new Book("The Iliad");
        var book20 = new Book("Anna Karenina");

        Library library = new Library();

        library.AddUser(user1);
        library.AddUser(user2);
        library.AddUser(user3);
        library.AddUser(user4);
        library.AddUser(user5);
        library.AddUser(user6);
        library.AddUser(user7);
        library.AddUser(user8);
        library.AddUser(user9);
        library.AddUser(user10);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.AddBook(book4);
        library.AddBook(book5);
        library.AddBook(book6);
        library.AddBook(book7);
        library.AddBook(book8);
        library.AddBook(book9);
        library.AddBook(book10);
        library.AddBook(book11);
        library.AddBook(book12);
        library.AddBook(book13);
        library.AddBook(book14);
        library.AddBook(book15);
        library.AddBook(book16);
        library.AddBook(book17);
        library.AddBook(book18);
        library.AddBook(book19);
        library.AddBook(book20);

        library.FindBooksByTitle("1984");
        library.FindUsersByName("Alice");

        library.GetBooks(page: 1, pageSize: 10);
        library.GetUsers(page: 1, pageSize: 10);

        library.DeleteBook(book1.Id);
        library.DeleteUser(user1.Id);
        library.DeleteUser(user1.Id);


        
    }
}