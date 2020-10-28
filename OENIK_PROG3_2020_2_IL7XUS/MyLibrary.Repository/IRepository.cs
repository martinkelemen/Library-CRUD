﻿using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary.Repository
{
    public interface IRepository<T, TK>
        where T : class
    {
        T GetOne(TK id);

        IQueryable<T> GetAll();

        void AddNew(T newInstance);

        void DeleteOld(T oldInstance);

    }

    public interface IBookRepository : IRepository<Book, string>
    {
        void ChangeYear(string id, int newYear);

        void ChangeLanguage(string id, string newLanguage);

        void ChangePublisher(string id, string newPublisher);
    }

    public interface IRenterRepository : IRepository<Renter, int>
    {
        void ChangeName(int id, string newName);

        void ChangeAddress(int id, string newAddress);

        void ChangeEmail(int id, string newEmail);

        void ChangeMembershipType(int id, string newMembershipType);
    }

    public interface IWorkerRepository : IRepository<Worker, int>
    {
        void ChangeName(int id, string newName);

        void ChangeAddress(int id, string newAddress);

        void ChangeEmail(int id, string newEmail);

        void ChangeSalary(int id, int newSalary);
    }

    public interface IBookRentalRepository : IRepository<BookRental, int>
    {
        void ChangeDays(int id, int newDays);
    }
}