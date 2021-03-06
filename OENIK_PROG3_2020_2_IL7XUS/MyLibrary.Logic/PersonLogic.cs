// <copyright file="PersonLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyLibrary.Data;
    using MyLibrary.Repository;

    /// <summary>
    /// The logic class of the worker repository class and the renter repository class, implements the IPersonLogic interface.
    /// </summary>
    public class PersonLogic : IPersonLogic
    {
        private IRenterRepository renterRepository;

        private IWorkerRepository workerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonLogic"/> class.
        /// </summary>
        /// <param name="renterRepository">The renter repository.</param>
        /// <param name="workerRepository">The worker repository.</param>
        public PersonLogic(IRenterRepository renterRepository, IWorkerRepository workerRepository)
        {
            this.renterRepository = renterRepository;
            this.workerRepository = workerRepository;
        }

        /// <summary>
        /// Adds a new Renter instance to the table.
        /// </summary>
        /// <param name="renterInstance">The new Renter instance.</param>
        public void AddRenter(Renter renterInstance)
        {
            this.renterRepository.AddNew(renterInstance);
        }

        /// <summary>
        /// Adds a new Worker instance to the table.
        /// </summary>
        /// <param name="workerInstance">The new Worker instance.</param>
        public void AddWorker(Worker workerInstance)
        {
            this.workerRepository.AddNew(workerInstance);
        }

        /// <summary>
        /// Changes the address of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newAddress">The new address of the renter.</param>
        public void ChangeRenterAddress(int id, string newAddress)
        {
            this.renterRepository.ChangeAddress(id, newAddress);
        }

        /// <summary>
        /// Changes the email of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newEmail">The new email of the renter.</param>
        public void ChangeRenterEmail(int id, string newEmail)
        {
            this.renterRepository.ChangeEmail(id, newEmail);
        }

        /// <summary>
        /// Changes the type of the membership by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newMembershipType">The new type of membership.</param>
        public void ChangeRenterMembershipType(int id, string newMembershipType)
        {
            this.renterRepository.ChangeMembershipType(id, newMembershipType);
        }

        /// <summary>
        /// Changes the name of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newName">The new name of the renter.</param>
        public void ChangeRenterName(int id, string newName)
        {
            this.renterRepository.ChangeName(id, newName);
        }

        /// <summary>
        /// Changes the address of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newAddress">The new address of the worker.</param>
        public void ChangeWorkerAddress(int id, string newAddress)
        {
            this.workerRepository.ChangeAddress(id, newAddress);
        }

        /// <summary>
        /// Changes the email of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newEmail">The new email of the worker.</param>
        public void ChangeWorkerEmail(int id, string newEmail)
        {
            this.workerRepository.ChangeEmail(id, newEmail);
        }

        /// <summary>
        /// Changes the name of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newName">The new name of the worker.</param>
        public void ChangeWorkerName(int id, string newName)
        {
            this.workerRepository.ChangeName(id, newName);
        }

        /// <summary>
        /// Changes the salary of a worker by id.
        /// </summary>
        /// <param name="id">The id of the worker.</param>
        /// <param name="newSalary">The new salary of the worker.</param>
        public void ChangeWorkerSalary(int id, int newSalary)
        {
            this.workerRepository.ChangeSalary(id, newSalary);
        }

        /// <summary>
        /// Deletes a Renter instance from the table by ID.
        /// </summary>
        /// <param name="id">The renter's ID.</param>
        public void DeleteRenter(int id)
        {
            this.renterRepository.DeleteOld(id);
        }

        /// <summary>
        /// Deletes a Worker instance from the table by ID.
        /// </summary>
        /// <param name="id">The worker's ID.</param>
        public void DeleteWorker(int id)
        {
            this.workerRepository.DeleteOld(id);
        }

        /// <summary>
        /// Gives back an IList type with all renters.
        /// </summary>
        /// <returns>IList type.</returns>
        public IList<Renter> GetAllRenters()
        {
            return this.renterRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gives back an IList type with all workers.
        /// </summary>
        /// <returns>IList type.</returns>
        public IList<Worker> GetAllWorkers()
        {
            return this.workerRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gives back a renter instance by id.
        /// </summary>
        /// <param name="id">The id of the renter instance.</param>
        /// <returns>Renter instance.</returns>
        public Renter GetRenterById(int id)
        {
            return this.renterRepository.GetOne(id);
        }

        /// <summary>
        /// Gives back a worker instance by id.
        /// </summary>
        /// <param name="id">The id of the worker instance.</param>
        /// <returns>Worker instance.</returns>
        public Worker GetWorkerById(int id)
        {
            return this.workerRepository.GetOne(id);
        }

        public void UpdateRenter(Renter item)
        {
            this.renterRepository.Update(item);
        }

        public void UpdateWorker(Worker item)
        {
            this.workerRepository.Update(item);
        }
    }
}
