// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;

    /// <summary>
    /// The abstract ancestor class of the repository classes.
    /// </summary>
    /// <typeparam name="T">Generic type T.</typeparam>
    /// <typeparam name="TK">Generic type TK.</typeparam>
    public abstract class Repository<T, TK> : IRepository<T, TK>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T, TK}"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        public Repository(DbContext ctx)
        {
            this.Ctx = ctx;
        }

        /// <summary>
        /// Gets the context of the database.
        /// </summary>
        protected DbContext Ctx { get; }

        /// <summary>
        /// Adds a new instance to a table.
        /// </summary>
        /// <param name="newInstance">The new instance.</param>
        public void AddNew(T newInstance)
        {
            this.Ctx.Set<T>().Add(newInstance);
        }

        /// <summary>
        /// Deletes an instance from a table by id.
        /// </summary>
        /// <param name="id">The id of the instance.</param>
        public void DeleteOld(TK id)
        {
            this.Ctx.Set<T>().Remove(this.GetOne(id));
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Returns an IQueryable type of all the elements in a table.
        /// </summary>
        /// <returns>Returns IQueryable type.</returns>
        public IQueryable<T> GetAll()
        {
            return this.Ctx.Set<T>();
        }

        /// <summary>
        /// Returns a single instance by ID.
        /// </summary>
        /// <param name="id">Id of Type T instance.</param>
        /// <returns>Returns T generic type based on Id.</returns>
        public abstract T GetOne(TK id);
    }
}
