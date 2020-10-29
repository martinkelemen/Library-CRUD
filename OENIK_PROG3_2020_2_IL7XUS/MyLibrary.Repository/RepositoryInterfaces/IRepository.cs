// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyLibrary.Data;

    public interface IRepository<T, TK>
        where T : class
    {
        T GetOne(TK id);

        IQueryable<T> GetAll();

        void AddNew(T newInstance);

        void DeleteOld(TK id);
    }
}
