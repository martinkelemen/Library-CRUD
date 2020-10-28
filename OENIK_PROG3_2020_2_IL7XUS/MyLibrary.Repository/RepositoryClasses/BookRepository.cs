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

    public class BookRepository : Repository<Book, string>, IBookRepository
    {
        public BookRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public void ChangeLanguage(string id, string newLanguage)
        {
            var book = GetOne(id);
            book.Language = newLanguage;
            this.ctx.SaveChanges();
        }

        public void ChangePublisher(string id, string newPublisher)
        {
            var book = GetOne(id);
            book.Publisher = newPublisher;
            this.ctx.SaveChanges();
        }

        public void ChangeYear(string id, int newYear)
        {
            var book = GetOne(id);
            book.Year = newYear;
            this.ctx.SaveChanges();
        }

        public override Book GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.ISBN == id);
        }
    }
}
