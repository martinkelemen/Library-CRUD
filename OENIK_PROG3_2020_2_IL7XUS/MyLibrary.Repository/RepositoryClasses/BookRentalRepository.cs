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

    public class BookRentalRepository : Repository<BookRental, int>, IBookRentalRepository
    {
        public BookRentalRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public void ChangeDays(int id, int newDays)
        {
            var rental = GetOne(id);
            rental.Days = newDays;
            this.ctx.SaveChanges();
        }

        public override BookRental GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.RentalId == id);
        }
    }
}
