using Castle.DynamicProxy.Contributors;
using MyLibrary.Data;
using MyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Logic
{
    interface ILibraryLogic
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
