// <copyright file="BookRentalRepository.cs" company="PlaceholderCompany">
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
    /// The book rental repository class inherited from the abstract Repository class, implements the IBookRentalRepository.
    /// </summary>
    public class BookRentalRepository : DbRepository<BookRental, int>, IBookRentalRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookRentalRepository"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        public BookRentalRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Changes the number of days of a rental.
        /// </summary>
        /// <param name="id">The id of the rental.</param>
        /// <param name="newDays">The new number of days of the rental.</param>
        public void ChangeDays(int id, int newDays)
        {
            var rental = this.GetOne(id);
            rental.Days = newDays;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Returns a Book instance by id.
        /// </summary>
        /// <param name="id">The id of the instance.</param>
        /// <returns>A Book instance.</returns>
        public override BookRental GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.RentalId == id);
        }
    }
}
