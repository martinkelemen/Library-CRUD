// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;
    using MyLibrary.Logic;
    using MyLibrary.Repository;

    public class Factory
    {
        public Factory()
        {
            this.LibraryContext = new LibraryContext();
            this.BookRepository = new BookRepository(this.LibraryContext);
            this.RenterRepository = new RenterRepository(this.LibraryContext);
            this.WorkerRepository = new WorkerRepository(this.LibraryContext);
            this.BookRentalRepository = new BookRentalRepository(this.LibraryContext);
            this.LibraryLogic = new LibraryLogic(this.BookRepository, this.BookRentalRepository);
            this.PersonLogic = new PersonLogic(this.RenterRepository, this.WorkerRepository);
        }

        public LibraryContext LibraryContext { get; }

        public BookRepository BookRepository { get; }

        public RenterRepository RenterRepository { get; }

        public WorkerRepository WorkerRepository { get; }

        public BookRentalRepository BookRentalRepository { get; }

        public LibraryLogic LibraryLogic { get; }

        public PersonLogic PersonLogic { get; }
    }
}
