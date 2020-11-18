// <copyright file="LibraryLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Moq;
    using MyLibrary.Data;
    using MyLibrary.Repository;
    using NUnit.Framework;

    [TestFixture]
    public class LibraryLogicTests
    {
        [Test]
        public void TestRemoveBook()
        {
            Mock<IBookRepository> bookRepository = new Mock<IBookRepository>();
            Mock<IBookRentalRepository> rentalRepository = new Mock<IBookRentalRepository>();
            LibraryLogic lLogic = new LibraryLogic(bookRepository.Object, rentalRepository.Object);

            lLogic.DeleteBook("ISBN #2");

            bookRepository.Verify(repo => repo.DeleteOld("ISBN #2"), Times.Once);
        }

        [Test]
        public void TestGetAllRentals()
        {
            Mock<IBookRepository> bookRepository = new Mock<IBookRepository>();
            Mock<IBookRentalRepository> rentalRepository = new Mock<IBookRentalRepository>();
            List<BookRental> rentals = new List<BookRental>()
            {
                new BookRental() { RentalId = 1 },
                new BookRental() { RentalId = 2 },
                new BookRental() { RentalId = 3 },
                new BookRental() { RentalId = 4 },
                new BookRental() { RentalId = 5 },
            };
            rentalRepository.Setup(repo => repo.GetAll()).Returns(rentals.AsQueryable());
            LibraryLogic lLogic = new LibraryLogic(bookRepository.Object, rentalRepository.Object);

            var result = lLogic.GetAllBookRentals();

            Assert.That(result, Is.EquivalentTo(rentals));
            rentalRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Test]
        public void TestGetRentByLanguage()
        {
            Mock<IBookRepository> bookRepository = new Mock<IBookRepository>();
            Mock<IBookRentalRepository> rentalRepository = new Mock<IBookRentalRepository>();
            List<Book> books = new List<Book>()
            {
                new Book() { ISBN = "1", Language = "Esperanto" },
                new Book() { ISBN = "2", Language = "Pirate" },
                new Book() { ISBN = "3", Language = "English" },
            };
            List<BookRental> rentals = new List<BookRental>()
            {
                new BookRental() { RentalId = 1, Book = books[0], Days = 5 },
                new BookRental() { RentalId = 2, Book = books[1], Days = 6 },
                new BookRental() { RentalId = 3, Book = books[1], Days = 12 },
                new BookRental() { RentalId = 4, Book = books[0], Days = 10 },
                new BookRental() { RentalId = 5, Book = books[2], Days = 2 },
            };
            List<GroupByLanguage> expectedResult = new List<GroupByLanguage>()
            {
                new GroupByLanguage() { Language = "Esperanto", Average = 7.5 },
                new GroupByLanguage() { Language = "Pirate", Average = 9 },
                new GroupByLanguage() { Language = "English", Average = 2 },
            };
            rentalRepository.Setup(repo => repo.GetAll()).Returns(rentals.AsQueryable());
            LibraryLogic lLogic = new LibraryLogic(bookRepository.Object, rentalRepository.Object);

            var result = lLogic.GetRentByLanguage();

            Assert.That(result, Is.EquivalentTo(expectedResult));
            rentalRepository.Verify(repo => repo.GetAll(), Times.Once);
            bookRepository.Verify(repo => repo.GetAll(), Times.Never);
        }

        [Test]
        public void TestGetRentByMembership()
        {
            Mock<IBookRepository> bookRepository = new Mock<IBookRepository>();
            Mock<IBookRentalRepository> rentalRepository = new Mock<IBookRentalRepository>();
            List<Renter> renters = new List<Renter>()
            {
                new Renter() { RenterId = 1, MembershipType = "Golden" },
                new Renter() { RenterId = 2, MembershipType = "Casual" },
                new Renter() { RenterId = 3, MembershipType = "Silver" },
            };
            List<BookRental> rentals = new List<BookRental>()
            {
                new BookRental() { RentalId = 1, Renter = renters[0] },
                new BookRental() { RentalId = 2, Renter = renters[1] },
                new BookRental() { RentalId = 3, Renter = renters[1] },
                new BookRental() { RentalId = 4, Renter = renters[2] },
                new BookRental() { RentalId = 5, Renter = renters[0] },
            };
            List<GroupByMembership> expectedResult = new List<GroupByMembership>()
            {
                new GroupByMembership() { MembershipType = "Golden", Count = 2 },
                new GroupByMembership() { MembershipType = "Casual", Count = 2 },
                new GroupByMembership() { MembershipType = "Silver", Count = 1 },
            };
            rentalRepository.Setup(repo => repo.GetAll()).Returns(rentals.AsQueryable());
            LibraryLogic lLogic = new LibraryLogic(bookRepository.Object, rentalRepository.Object);

            var result = lLogic.GetRentByMembership();

            Assert.That(result, Is.EquivalentTo(expectedResult));
            rentalRepository.Verify(repo => repo.GetAll(), Times.Once);
            bookRepository.Verify(repo => repo.GetAll(), Times.Never);
        }

        [Test]
        public void TestListAllRents()
        {
            Mock<IBookRepository> bookRepository = new Mock<IBookRepository>();
            Mock<IBookRentalRepository> rentalRepository = new Mock<IBookRentalRepository>();
            List<Renter> renters = new List<Renter>()
            {
                new Renter() { RenterId = 1, Name = "Renter #1" },
                new Renter() { RenterId = 2, Name = "Renter #2" },
            };
            List<Book> books = new List<Book>()
            {
                new Book() { ISBN = "1", Title = "Book #1" },
                new Book() { ISBN = "2", Title = "Book #2" },
            };
            List<Worker> workers = new List<Worker>()
            {
                new Worker() { WorkerId = 1, Name = "Worker #1" },
                new Worker() { WorkerId = 2, Name = "Worker #2" },
            };
            List<BookRental> rentals = new List<BookRental>()
            {
                new BookRental() { RentalId = 1, Renter = renters[0], Worker = workers[0], Book = books[0] },
                new BookRental() { RentalId = 2, Renter = renters[1], Worker = workers[1], Book = books[1] },
                new BookRental() { RentalId = 3, Renter = renters[0], Worker = workers[1], Book = books[1] },
                new BookRental() { RentalId = 4, Renter = renters[1], Worker = workers[0], Book = books[0] },
            };
            List<RentalWithNames> expectedResult = new List<RentalWithNames>()
            {
                new RentalWithNames() { RentId = 1, RenterName = "Renter #1", WorkerName = "Worker #1", BookName = "Book #1" },
                new RentalWithNames() { RentId = 2, RenterName = "Renter #2", WorkerName = "Worker #2", BookName = "Book #2" },
                new RentalWithNames() { RentId = 3, RenterName = "Renter #1", WorkerName = "Worker #2", BookName = "Book #2" },
                new RentalWithNames() { RentId = 4, RenterName = "Renter #2", WorkerName = "Worker #1", BookName = "Book #1" },
            };
            rentalRepository.Setup(repo => repo.GetAll()).Returns(rentals.AsQueryable());
            LibraryLogic lLogic = new LibraryLogic(bookRepository.Object, rentalRepository.Object);

            var result = lLogic.ListAllRents();

            Assert.That(result, Is.EquivalentTo(expectedResult));
            rentalRepository.Verify(repo => repo.GetAll(), Times.Once);
            bookRepository.Verify(repo => repo.GetAll(), Times.Never);
        }
    }
}
