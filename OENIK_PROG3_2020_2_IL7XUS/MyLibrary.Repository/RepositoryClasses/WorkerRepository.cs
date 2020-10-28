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

    public class WorkerRepository : Repository<Worker, int>, IWorkerRepository
    {
        public WorkerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public void ChangeAddress(int id, string newAddress)
        {
            var worker = GetOne(id);
            worker.Address = newAddress;
            this.ctx.SaveChanges();
        }

        public void ChangeEmail(int id, string newEmail)
        {
            var worker = GetOne(id);
            worker.Email = newEmail;
            this.ctx.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var worker = GetOne(id);
            worker.Name = newName;
            this.ctx.SaveChanges();
        }

        public void ChangeSalary(int id, int newSalary)
        {
            var worker = GetOne(id);
            worker.Salary = newSalary;
            this.ctx.SaveChanges();
        }

        public override Worker GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.WorkerId == id);
        }
    }
}
