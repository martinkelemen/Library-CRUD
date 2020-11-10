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

    /// <summary>
    /// The logic class of the book repository class and the book rental repository class, implements the ILibraryLogic interface.
    /// </summary>
    public class LibraryLogic : ILibraryLogic
    {
        private IBookRepository bookRepository;
        private IBookRentalRepository bookRentalRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryLogic"/> class.
        /// </summary>
        /// <param name="bookRepository">The repository of the Book table.</param>
        /// <param name="bookRentalRepository">The repository of the BookRental table.</param>
        public LibraryLogic(IBookRepository bookRepository, IBookRentalRepository bookRentalRepository)
        {
            this.bookRepository = bookRepository;
            this.bookRentalRepository = bookRentalRepository;
        }

        /// <summary>
        /// Adds a new book to the table.
        /// </summary>
        /// <param name="bookInstance">The instance of the new book.</param>
        public void AddBook(Book bookInstance)
        {
            this.bookRepository.AddNew(bookInstance);
        }

        /// <summary>
        /// Adds a new rental to the table.
        /// </summary>
        /// <param name="rentalInstance">The instance of the new rental.</param>
        public void AddRental(BookRental rentalInstance)
        {
            this.bookRentalRepository.AddNew(rentalInstance);
        }

        /// <summary>
        /// Changes the book's language by id.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newLanguage">The new language of the book.</param>
        public void ChangeBookLanguage(string id, string newLanguage)
        {
            this.bookRepository.ChangeLanguage(id, newLanguage);
        }

        /// <summary>
        /// Changes the book's publisher.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newPublisher">The new publisher of the book.</param>
        public void ChangeBookPublisher(string id, string newPublisher)
        {
            this.bookRepository.ChangePublisher(id, newPublisher);
        }

        /// <summary>
        /// Changes the rental's number of days.
        /// </summary>
        /// <param name="id">The id of the rental.</param>
        /// <param name="newDays">The new number of days of the rental.</param>
        public void ChangeBookRentalDays(int id, int newDays)
        {
            this.bookRentalRepository.ChangeDays(id, newDays);
        }

        /// <summary>
        /// Changes the publishing year of the book.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newYear">The new publishing year of the book.</param>
        public void ChangeBookYear(string id, int newYear)
        {
            this.bookRepository.ChangeYear(id, newYear);
        }

        /// <summary>
        /// Deletes a Book instance from the table by ID.
        /// </summary>
        /// <param name="id">The book's ID.</param>
        public void DeleteBook(string id)
        {
            this.bookRepository.DeleteOld(id);
        }

        /// <summary>
        /// Deletes a BookRental instance from the table by ID.
        /// </summary>
        /// <param name="id">The rental's ID.</param>
        public void DeleteRental(int id)
        {
            this.bookRentalRepository.DeleteOld(id);
        }

        /// <summary>
        /// Gives back an IList type with all rentals.
        /// </summary>
        /// <returns>The IList type.</returns>
        public IList<BookRental> GetAllBookRentals()
        {
            return this.bookRentalRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gives back an IList type with all books.
        /// </summary>
        /// <returns>The IList type.</returns>
        public IList<Book> GetAllBooks()
        {
            return this.bookRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gives back a Book instance by id.
        /// </summary>
        /// <param name="id">The id of the Book instance.</param>
        /// <returns>The Book instance.</returns>
        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back a BookRental instance by id.
        /// </summary>
        /// <param name="id">The id of the BookRental instance.</param>
        /// <returns>The BookRental instance.</returns>
        public BookRental GetBookRentalById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back an IList type with the rentals groupped by book's languages.
        /// </summary>
        /// <returns>IList type.</returns>
        public IList<GroupByLanguage> GetRentByLanguage()
        {
            var q = from x in this.bookRentalRepository.GetAll()
                    group x by x.Book.Language into g
                    orderby g.Average(t => t.Days) descending
                    select new GroupByLanguage()
                    {
                        Language = g.Key,
                        Average = g.Average(t => t.Days),
                    };

            return q.ToList();
        }

        /// <summary>
        /// Gives back an IList type with the rentals groupped by renter's type of memberships.
        /// </summary>
        /// <returns>IList type.</returns>
        public IList<GroupByMembership> GetRentByMembership()
        {
            var q = from x in this.bookRentalRepository.GetAll()
                    group x by x.Renter.MembershipType into g
                    orderby g.Count() descending
                    select new GroupByMembership()
                    {
                        MembershipType = g.Key,
                        Count = g.Count(),
                    };

            return q.ToList();
        }

        /// <summary>
        /// Gives back an IList type with all rents and the names of book's, worker's and renter's.
        /// </summary>
        /// <returns>IList type.</returns>
        public IList<RentalWithNames> ListAllRents()
        {
            var q = from x in this.bookRentalRepository.GetAll()
                    orderby x.RentalId
                    select new RentalWithNames()
                    {
                        RentId = x.RentalId,
                        BookName = x.Book.Title,
                        RenterName = x.Renter.Name,
                        WorkerName = x.Worker.Name,
                        RentDate = x.RentalDate,
                        Days = x.Days,
                    };

            return q.ToList();
        }
    }
}
