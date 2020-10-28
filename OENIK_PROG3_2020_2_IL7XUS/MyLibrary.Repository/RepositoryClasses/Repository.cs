﻿// <copyright file="Repository.cs" company="PlaceholderCompany">
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

    public abstract class Repository<T, TK> : IRepository<T, TK>
        where T : class
    {
        protected DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void AddNew(T newInstance)
        {
            this.ctx.Add<T>(newInstance);
        }

        public void DeleteOld(T oldInstance)
        {
            this.ctx.Remove<T>(oldInstance);
        }

        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        public abstract T GetOne(TK id);
    }
}