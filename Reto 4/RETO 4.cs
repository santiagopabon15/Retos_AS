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

    public bool Loan()
    {
        if (CopiesAvailable > 0)
        {
            CopiesAvailable--;
            return true;
        }
        return false;
    }

    public void Return()
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
    private List<(User, Book)> loans = new List<(User, Book)>();

    public bool LoanBook(User user, Book book)
    {
        if (book != null && book.Loan())
        {
            loans.Add((user, book));
            return true;
        }
        return false;
    }

    public bool ReturnBook(User user, Book book)
    {
        var loan = loans.FirstOrDefault(l => l.Item1 == user && l.Item2 == book);
        if (loan != default)
        {
            book.Return();
            loans.Remove(loan);
            return true;
        }
        return false;
    }
}
