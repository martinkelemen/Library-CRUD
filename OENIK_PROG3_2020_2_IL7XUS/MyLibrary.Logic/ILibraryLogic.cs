// <copyright file="ILibraryLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Castle.DynamicProxy.Contributors;
    using MyLibrary.Data;
    using MyLibrary.Repository;

    public interface ILibraryLogic
    {
        Book GetBookById(int id);

        BookRental GetBookRentalById(int id);

        IList<Book> GetAllBooks();

        IList<BookRental> GetAllBookRentals();

        void AddBook(Book bookInstance);

        void AddRental(BookRental rentalInstance);

        void ChangeBookLanguage(string id, string newLanguage);

        void ChangeBookPublisher(string id, string newPublisher);

        void ChangeBookYear(string id, int newYear);

        void ChangeBookRentalDays(int id, int newDays);

        IList<string> GetRentByLanguage();

        IList<string> GetRentByMembership();

        IList<string> ListAllRents();
    }
}
