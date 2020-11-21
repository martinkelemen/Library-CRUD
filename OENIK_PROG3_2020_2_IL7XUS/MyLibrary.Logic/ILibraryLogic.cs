// <copyright file="ILibraryLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Castle.DynamicProxy.Contributors;
    using MyLibrary.Data;
    using MyLibrary.Repository;

    /// <summary>
    /// The logic interface of the book repository class and the book rental repository class.
    /// </summary>
    public interface ILibraryLogic
    {
        /// <summary>
        /// Gives back a Book instance by id.
        /// </summary>
        /// <param name="id">The id of the Book instance.</param>
        /// <returns>The Book instance.</returns>
        Book GetBookById(string id);

        /// <summary>
        /// Gives back a BookRental instance by id.
        /// </summary>
        /// <param name="id">The id of the BookRental instance.</param>
        /// <returns>The BookRental instance.</returns>
        BookRental GetBookRentalById(int id);

        /// <summary>
        /// Gives back an IList type with all books.
        /// </summary>
        /// <returns>The IList type.</returns>
        IList<Book> GetAllBooks();

        /// <summary>
        /// Gives back an IList type with all rentals.
        /// </summary>
        /// <returns>The IList type.</returns>
        IList<BookRental> GetAllBookRentals();

        /// <summary>
        /// Adds a new book to the table.
        /// </summary>
        /// <param name="bookInstance">The instance of the new book.</param>
        void AddBook(Book bookInstance);

        /// <summary>
        /// Adds a new rental to the table.
        /// </summary>
        /// <param name="rentalInstance">The instance of the new rental.</param>
        void AddRental(BookRental rentalInstance);

        /// <summary>
        /// Deletes a Book instance from the table by ID.
        /// </summary>
        /// <param name="id">The book's ID.</param>
        void DeleteBook(string id);

        /// <summary>
        /// Deletes a BookRental instance from the table by ID.
        /// </summary>
        /// <param name="id">The rental's ID.</param>
        void DeleteRental(int id);

        /// <summary>
        /// Changes the book's language by id.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newLanguage">The new language of the book.</param>
        void ChangeBookLanguage(string id, string newLanguage);

        /// <summary>
        /// Changes the book's publisher.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newPublisher">The new publisher of the book.</param>
        void ChangeBookPublisher(string id, string newPublisher);

        /// <summary>
        /// Changes the publishing year of the book.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newYear">The new publishing year of the book.</param>
        void ChangeBookYear(string id, int newYear);

        /// <summary>
        /// Changes the rental's number of days.
        /// </summary>
        /// <param name="id">The id of the rental.</param>
        /// <param name="newDays">The new number of days of the rental.</param>
        void ChangeBookRentalDays(int id, int newDays);

        /// <summary>
        /// Gives back an IList type with the rentals groupped by book's languages.
        /// </summary>
        /// <returns>IList type.</returns>
        IList<GroupByLanguage> GetRentByLanguage();

        /// <summary>
        /// Gives back an IList type with the rentals groupped by book's languages.
        /// </summary>
        /// <returns>IList type.</returns>
        Task<IList<GroupByLanguage>> GetRentByLanguageAsync();

        /// <summary>
        /// Gives back an IList type with the rentals groupped by renter's type of memberships.
        /// </summary>
        /// <returns>IList type.</returns>
        IList<GroupByMembership> GetRentByMembership();

        /// <summary>
        /// Gives back an IList type with the rentals groupped by renter's type of memberships.
        /// </summary>
        /// <returns>IList type.</returns>
        Task<IList<GroupByMembership>> GetRentByMembershipAsync();

        /// <summary>
        /// Gives back an IList type with all rents and the names of book's, worker's and renter's.
        /// </summary>
        /// <returns>IList type.</returns>
        IList<RentalWithNames> ListAllRents();

        /// <summary>
        /// Gives back an IList type with all rents and the names of book's, worker's and renter's.
        /// </summary>
        /// <returns>IList type.</returns>
        Task<IList<RentalWithNames>> ListAllRentsAsync();
    }
}
