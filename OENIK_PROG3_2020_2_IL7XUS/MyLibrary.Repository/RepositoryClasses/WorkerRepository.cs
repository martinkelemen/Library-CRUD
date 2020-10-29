// <copyright file="WorkerRepository.cs" company="PlaceholderCompany">
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
    /// The worker repository inherited from the abstract Repository class, implements the IWorkerRepository interface.
    /// </summary>
    public class WorkerRepository : DbRepository<Worker, int>, IWorkerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerRepository"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        public WorkerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Changes the address of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newAddress">The new address of the worker.</param>
        public void ChangeAddress(int id, string newAddress)
        {
            var worker = this.GetOne(id);
            worker.Address = newAddress;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes the email of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newEmail">The new email of the worker.</param>
        public void ChangeEmail(int id, string newEmail)
        {
            var worker = this.GetOne(id);
            worker.Email = newEmail;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes the name of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newName">The new name of the worker.</param>
        public void ChangeName(int id, string newName)
        {
            var worker = this.GetOne(id);
            worker.Name = newName;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes the salary of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newSalary">The new salary of the worker.</param>
        public void ChangeSalary(int id, int newSalary)
        {
            var worker = this.GetOne(id);
            worker.Salary = newSalary;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Returns a worker instance back by id.
        /// </summary>
        /// <param name="id">The id of the worker instance.</param>
        /// <returns>The worker instance.</returns>
        public override Worker GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.WorkerId == id);
        }
    }
}
