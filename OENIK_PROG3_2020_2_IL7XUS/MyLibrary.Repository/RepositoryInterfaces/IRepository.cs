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

    /// <summary>
    /// The generic repository interface.
    /// </summary>
    /// <typeparam name="T">Generic type T.</typeparam>
    /// <typeparam name="TK">Generic type TK.</typeparam>
    public interface IRepository<T, TK>
        where T : class
    {
        /// <summary>
        /// Returns a single instance by ID.
        /// </summary>
        /// <param name="id">Id of Type T instance.</param>
        /// <returns>Returns T generic type based on Id.</returns>
        T GetOne(TK id);

        /// <summary>
        /// Returns an IQueryable type of all the elements in a table.
        /// </summary>
        /// <returns>Returns IQueryable type.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Adds a new instance to a table.
        /// </summary>
        /// <param name="newInstance">The new instance.</param>
        void AddNew(T newInstance);

        /// <summary>
        /// Deletes an instance from a table by id.
        /// </summary>
        /// <param name="id">The id of the instance.</param>
        void DeleteOld(TK id);

        void Update(T item);
    }
}
