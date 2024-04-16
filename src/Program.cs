using System;

class Book
{
    public int Id { get; } 
    public string Title { get; } 
    public DateTime CreatedDate { get; } 

    public Book(int id,string title, DateTime createdDate)
    {
        Id = id; 
        Title = title;
        CreatedDate = createdDate;
    }
}

class User
{
    public int Id { get; } 
    public string Name { get; } 
    public DateTime CreatedDate { get; } 
    
    public User(int id, string name, DateTime createdDate)
    {
        Id = id;
        Name = name;
        CreatedDate = createdDate;
    }
}

class Library
{
    
}

internal class Program
{
    private static void Main()
    {
    }
}