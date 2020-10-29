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

    /// <summary>
    /// The factory class of the DbContext, Repositories and Logics.
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets the context of the database.
        /// </summary>
        public LibraryContext LibraryContext { get; }

        /// <summary>
        /// Gets the Book table's repository.
        /// </summary>
        public BookRepository BookRepository { get; }

        /// <summary>
        /// Gets the Renter table's repository.
        /// </summary>
        public RenterRepository RenterRepository { get; }

        /// <summary>
        /// Gets the Worker's table repository.
        /// </summary>
        public WorkerRepository WorkerRepository { get; }

        /// <summary>
        /// Gets the BookRental's table repository.
        /// </summary>
        public BookRentalRepository BookRentalRepository { get; }

        /// <summary>
        /// Gets the BookRentalRepository's and the BookRepository's logic.
        /// </summary>
        public LibraryLogic LibraryLogic { get; }

        /// <summary>
        /// Gets the WorkerRepository's and the RenterRepository's logic.
        /// </summary>
        public PersonLogic PersonLogic { get; }
    }
}
