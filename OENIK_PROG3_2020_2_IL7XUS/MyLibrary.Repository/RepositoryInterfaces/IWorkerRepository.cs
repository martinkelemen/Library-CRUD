// <copyright file="IWorkerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository.RepositoryInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;

    public interface IWorkerRepository : IRepository<Worker, int>
    {
        void ChangeName(int id, string newName);

        void ChangeAddress(int id, string newAddress);

        void ChangeEmail(int id, string newEmail);

        void ChangeSalary(int id, int newSalary);
    }
}
