// <copyright file="IBookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;

    /// <summary>
    /// The book repository interface that implements the generic IRepository interface.
    /// </summary>
    public interface IBookRepository : IRepository<Book, string>
    {
        /// <summary>
        /// Changes the publishing year of a book.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newYear">The new publishing year of the book.</param>
        void ChangeYear(string id, int newYear);

        /// <summary>
        /// Changes the language of a book.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newLanguage">The new language of the book.</param>
        void ChangeLanguage(string id, string newLanguage);

        /// <summary>
        /// Changes the publisher of a book.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newPublisher">The new publisher of the book.</param>
        void ChangePublisher(string id, string newPublisher);
    }
}
