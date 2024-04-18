using System;

public interface INotificationService
{
    void SendNotificationOnSuccess(string successMessage);
    void SendNotificationOnFailure(string errorMessage);
}

public class EmailNotificationService : INotificationService
{
    public void SendNotificationOnSuccess(string successMessage)
    {
        Console.WriteLine($"Email sent a notification on success: Hello, {successMessage}. If you have any queries or feedback, please contact our support team at support@library.com.");
    }

    public void SendNotificationOnFailure(string errorMessage)
    {
        Console.WriteLine($"Email sent a notification on failure: {errorMessage}.  For more help, visit our FAQ at library.com/faq.");
    }
}

public class SMSNotificationService : INotificationService
{
    public void SendNotificationOnSuccess(string successMessage)
    {
        Console.WriteLine($"SMS sent a notification on success: {successMessage}. Thank you!");
    }

    public void SendNotificationOnFailure(string errorMessage)
    {
        Console.WriteLine($"SMS sent a notification on failure: {errorMessage}. Please email support@library.com.");
    }
}

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
    private List<Book> books;
    private List<User> users;

    private INotificationService notificationService;

    public Library(INotificationService notificationService)
    {
        books = new List<Book>();
        users = new List<User>();
        this.notificationService = notificationService;
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        //Console.WriteLine($"Book '{book.Title}' added successfully.");
        notificationService.SendNotificationOnSuccess($"Book '{book.Title}' added successfully to the Library.");
    }

    public void AddUser(User user)
    {
        users.Add(user);
        //onsole.WriteLine($"User '{user.Title}' added successfully.");
        notificationService.SendNotificationOnSuccess($"User '{user.Title}' added successfully to the Library.");
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
            //Console.WriteLine($"Book with ID '{id}' deleted successfully.");
            notificationService.SendNotificationOnSuccess($"Book with ID '{id}' deleted successfully from the Library.");
        }else{
            //Console.WriteLine($"Book with ID '{id}' was not found");
            notificationService.SendNotificationOnFailure($"Book with ID '{id}' was not found in the Library.");
        }
    }

    public void DeleteUser(Guid id)
    {
        User userToRemove = users.FirstOrDefault(u => u.Id == id);
        if (userToRemove != null)
        {
            users.Remove(userToRemove);
            //Console.WriteLine($"User with ID '{id}' deleted successfully.");
            notificationService.SendNotificationOnSuccess($"User with ID '{id}' deleted successfully from the Library.");
        }else{
            //Console.WriteLine($"User with ID '{id}' was not found");
            notificationService.SendNotificationOnFailure($"User with ID '{id}' was not found in the Library.");
        }
    }
}

internal class Program
{
    private static void Main()
    {
        var emailService = new EmailNotificationService();
        var smsService = new SMSNotificationService();

        var libraryWithEmail = new Library(emailService);
        var libraryWithSMS = new Library(smsService);

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


        libraryWithEmail.AddUser(user1);
        libraryWithEmail.AddUser(user2);
        libraryWithEmail.AddUser(user3);
        libraryWithEmail.AddUser(user4);
        libraryWithEmail.AddUser(user5);
        libraryWithEmail.AddUser(user6);
        libraryWithEmail.AddUser(user7);
        libraryWithEmail.AddUser(user8);
        libraryWithEmail.AddUser(user9);
        libraryWithEmail.AddUser(user10);

        libraryWithEmail.AddBook(book1);
        libraryWithEmail.AddBook(book2);
        libraryWithEmail.AddBook(book3);
        libraryWithEmail.AddBook(book4);
        libraryWithEmail.AddBook(book5);
        libraryWithEmail.AddBook(book6);
        libraryWithEmail.AddBook(book7);
        libraryWithEmail.AddBook(book8);
        libraryWithEmail.AddBook(book9);
        libraryWithEmail.AddBook(book10);
        libraryWithSMS.AddBook(book11);
        libraryWithSMS.AddBook(book12);
        libraryWithSMS.AddBook(book13);
        libraryWithSMS.AddBook(book14);
        libraryWithSMS.AddBook(book15);
        libraryWithSMS.AddBook(book16);
        libraryWithSMS.AddBook(book17);
        libraryWithSMS.AddBook(book18);
        libraryWithSMS.AddBook(book19);
        libraryWithSMS.AddBook(book20);

        //library.FindBooksByTitle("1984");
        //library.FindUsersByName("Alice");

        //library.GetBooks(page: 1, pageSize: 10);
        //library.GetUsers(page: 1, pageSize: 10);

        libraryWithEmail.DeleteBook(book1.Id);
        libraryWithEmail.DeleteUser(user1.Id);
        libraryWithEmail.DeleteUser(user1.Id);


        
    }
}