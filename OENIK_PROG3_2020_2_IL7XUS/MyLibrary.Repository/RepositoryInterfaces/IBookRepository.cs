// <copyright file="IBookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository.RepositoryInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;

    public interface IBookRepository : IRepository<Book, string>
    {
        void ChangeYear(string id, int newYear);

        void ChangeLanguage(string id, string newLanguage);

        void ChangePublisher(string id, string newPublisher);
    }
}
