// <copyright file="BookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;

    /// <summary>
    /// The book repository class inherited from the abstract Repository class, implements the IBookRepository.
    /// </summary>
    public class BookRepository : DbRepository<Book, string>, IBookRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        public BookRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Changes the language of a book.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newLanguage">The new language of the book.</param>
        public void ChangeLanguage(string id, string newLanguage)
        {
            var book = this.GetOne(id);
            book.Language = newLanguage;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes the publisher of a book.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newPublisher">The new publisher of the book.</param>
        public void ChangePublisher(string id, string newPublisher)
        {
            var book = this.GetOne(id);
            book.Publisher = newPublisher;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes the publishing year of a book.
        /// </summary>
        /// <param name="id">The id of the book.</param>
        /// <param name="newYear">The new publishing year of the book.</param>
        public void ChangeYear(string id, int newYear)
        {
            var book = this.GetOne(id);
            book.Year = newYear;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Returns a Book instance by id.
        /// </summary>
        /// <param name="id">The id of the instance.</param>
        /// <returns>A Book instance.</returns>
        public override Book GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.ISBN == id);
        }
    }
}
