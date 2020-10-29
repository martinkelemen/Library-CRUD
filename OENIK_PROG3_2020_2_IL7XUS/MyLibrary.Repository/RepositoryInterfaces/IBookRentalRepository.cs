// <copyright file="IBookRentalRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository.RepositoryInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;

    public interface IBookRentalRepository : IRepository<BookRental, int>
    {
        void ChangeDays(int id, int newDays);
    }
}
