// <copyright file="IBookRentalRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;

    /// <summary>
    /// The book rental repository interface that implements the generic IRepository interface.
    /// </summary>
    public interface IBookRentalRepository : IRepository<BookRental, int>
    {
        /// <summary>
        /// Changes the number of days of a rental.
        /// </summary>
        /// <param name="id">The id of the rental.</param>
        /// <param name="newDays">The new number of days of the rental.</param>
        void ChangeDays(int id, int newDays);
    }
}
