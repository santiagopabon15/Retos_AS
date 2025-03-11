using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; }
    public string Author { get; }
    public int CopiesAvailable { get; private set; }

    public Book(string title, string author, int copies)
    {
        Title = title;
        Author = author;
        CopiesAvailable = copies;
    }

    public void DecreaseCopies()
    {
        if (CopiesAvailable > 0)
            CopiesAvailable--;
    }

    public void IncreaseCopies()
    {
        CopiesAvailable++;
    }
}

class User
{
    public string Name { get; }
    public string Id { get; }
    public string Email { get; }

    public User(string name, string id, string email)
    {
        Name = name;
        Id = id;
        Email = email;
    }
}

class Loan
{
    public User User { get; }
    public Book Book { get; }

    public Loan(User user, Book book)
    {
        User = user;
        Book = book;
    }

    public bool LoanBook()
    {
        if (Book.CopiesAvailable > 0)
        {
            Book.DecreaseCopies();
            return true;
        }
        return false;
    }

    public void ReturnBook()
    {
        Book.IncreaseCopies();
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(string title, string author, int copies)
    {
        books.Add(new Book(title, author, copies));
    }

    public Book GetBook(string title)
    {
        return books.FirstOrDefault(b => b.Title == title);
    }
}

class UserManager
{
    private List<User> users = new List<User>();

    public void AddUser(string name, string id, string email)
    {
        users.Add(new User(name, id, email));
    }

    public User GetUser(string id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }
}

class LoanManager
{
    private List<Loan> loans = new List<Loan>();
}