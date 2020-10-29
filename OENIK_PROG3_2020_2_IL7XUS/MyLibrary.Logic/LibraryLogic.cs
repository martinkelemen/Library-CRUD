// <copyright file="LibraryLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyLibrary.Data;
    using MyLibrary.Repository;

    public class LibraryLogic : ILibraryLogic
    {
        private IBookRepository bookRepository;
        private IBookRentalRepository bookRentalRepository;

        public LibraryLogic(IBookRepository bookRepository, IBookRentalRepository bookRentalRepository)
        {
            this.bookRepository = bookRepository;
            this.bookRentalRepository = bookRentalRepository;
        }

        public void AddBook(Book bookInstance)
        {
            throw new NotImplementedException();
        }

        public void AddRental(BookRental rentalInstance)
        {
            throw new NotImplementedException();
        }

        public void ChangeBookLanguage(string id, string newLanguage)
        {
            throw new NotImplementedException();
        }

        public void ChangeBookPublisher(string id, string newPublisher)
        {
            throw new NotImplementedException();
        }

        public void ChangeBookRentalDays(int id, int newDays)
        {
            throw new NotImplementedException();
        }

        public void ChangeBookYear(string id, int newYear)
        {
            throw new NotImplementedException();
        }

        public IList<BookRental> GetAllBookRentals()
        {
            return this.bookRentalRepository.GetAll().ToList();
        }

        public IList<Book> GetAllBooks()
        {
            return this.bookRepository.GetAll().ToList();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public BookRental GetBookRentalById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetRentByLanguage()
        {
            throw new NotImplementedException();
        }

        public IList<string> GetRentByMembership()
        {
            throw new NotImplementedException();
        }

        public IList<string> ListAllRents()
        {
            throw new NotImplementedException();
        }
    }
}
