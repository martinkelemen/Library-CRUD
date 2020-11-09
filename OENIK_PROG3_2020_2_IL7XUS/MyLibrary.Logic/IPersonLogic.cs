// <copyright file="IPersonLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;

    /// <summary>
    /// The logic interface of the worker repository class and the renter repository class.
    /// </summary>
    public interface IPersonLogic
    {
        /// <summary>
        /// Gives back a renter instance by id.
        /// </summary>
        /// <param name="id">The id of the renter instance.</param>
        /// <returns>Renter instance.</returns>
        Renter GetRenterById(int id);

        /// <summary>
        /// Gives back a worker instance by id.
        /// </summary>
        /// <param name="id">The id of the worker instance.</param>
        /// <returns>Worker instance.</returns>
        Worker GetWorkerById(int id);

        /// <summary>
        /// Gives back an IList type with all renters.
        /// </summary>
        /// <returns>IList type.</returns>
        IList<Renter> GetAllRenters();

        /// <summary>
        /// Gives back an IList type with all workers.
        /// </summary>
        /// <returns>IList type.</returns>
        IList<Worker> GetAllWorkers();


        /// <summary>
        /// Adds a new Renter instance to the table.
        /// </summary>
        /// <param name="renterInstance">The new Renter instance.</param>
        void AddRenter(Renter renterInstance);

        /// <summary>
        /// Adds a new Worker instance to the table.
        /// </summary>
        /// <param name="workerInstance">The new Worker instance.</param>
        void AddWorker(Worker workerInstance);

        void DeleteRenter(int id);

        void DeleteWorker(int id);

        /// <summary>
        /// Changes the address of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newAddress">The new address of the renter.</param>
        void ChangeRenterAddress(int id, string newAddress);

        /// <summary>
        /// Changes the email of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newEmail">The new email of the renter.</param>
        void ChangeRenterEmail(int id, string newEmail);

        /// <summary>
        /// Changes the type of the membership by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newMembershipType">The new type of membership.</param>
        void ChangeRenterMembershipType(int id, string newMembershipType);

        /// <summary>
        /// Changes the name of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newName">The new name of the renter.</param>
        void ChangeRenterName(int id, string newName);

        /// <summary>
        /// Changes the address of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newAddress">The new address of the worker.</param>
        void ChangeWorkerAddress(int id, string newAddress);

        /// <summary>
        /// Changes the email of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newEmail">The new email of the worker.</param>
        void ChangeWorkerEmail(int id, string newEmail);

        /// <summary>
        /// Changes the name of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newName">The new name of the worker.</param>
        void ChangeWorkerName(int id, string newName);

        /// <summary>
        /// Changes the salary of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newSalary">The new salary of the worker.</param>
        void ChangeWorkerSalary(int id, int newSalary);
    }
}
