// <copyright file="IWorkerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;

    /// <summary>
    /// The worker repository interface that implements the generic IRepository interface.
    /// </summary>
    public interface IWorkerRepository : IRepository<Worker, int>
    {
        /// <summary>
        /// Changes the name of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newName">The new name of the worker.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// Changes the address of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newAddress">The new address of the worker.</param>
        void ChangeAddress(int id, string newAddress);

        /// <summary>
        /// Changes the email of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newEmail">The new email of the worker.</param>
        void ChangeEmail(int id, string newEmail);

        /// <summary>
        /// Changes the salary of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newSalary">The new salary of the worker.</param>
        void ChangeSalary(int id, int newSalary);
    }
}
