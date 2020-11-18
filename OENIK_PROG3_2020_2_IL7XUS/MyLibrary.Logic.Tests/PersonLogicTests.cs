// <copyright file="PersonLogicTests.cs" company="PlaceholderCompany">
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
    public class PersonLogicTests
    {
        [Test]
        public void TestAddRenter()
        {
            Mock<IRenterRepository> renterRepository = new Mock<IRenterRepository>();
            Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
            PersonLogic pLogic = new PersonLogic(renterRepository.Object, workerRepository.Object);
            Renter r = new Renter()
            {
                RenterId = 1,
            };

            pLogic.AddRenter(r);

            renterRepository.Verify(repo => repo.AddNew(r), Times.Once);
        }

        [Test]
        public void TestGetOneWorker()
        {
            Mock<IRenterRepository> renterRepository = new Mock<IRenterRepository>();
            Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
            List<Worker> workers = new List<Worker>()
            {
                new Worker() { WorkerId = 1 },
                new Worker() { WorkerId = 2 },
                new Worker() { WorkerId = 3 },
                new Worker() { WorkerId = 4 },
                new Worker() { WorkerId = 5 },
            };
            Worker expectedWorker = new Worker() { WorkerId = 3 };
            workerRepository.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(workers[2]);
            PersonLogic pLogic = new PersonLogic(renterRepository.Object, workerRepository.Object);

            var result = pLogic.GetWorkerById(3);

            Assert.That(result, Is.EqualTo(expectedWorker));
            workerRepository.Verify(repo => repo.GetOne(3), Times.Once);
        }

        [Test]
        public void TestChangeRenterMembershipType()
        {
            Mock<IRenterRepository> renterRepository = new Mock<IRenterRepository>();
            Mock<IWorkerRepository> workerRepository = new Mock<IWorkerRepository>();
            PersonLogic pLogic = new PersonLogic(renterRepository.Object, workerRepository.Object);

            pLogic.ChangeRenterMembershipType(1, "Golden");

            renterRepository.Verify(repo => repo.ChangeMembershipType(1, "Golden"), Times.Once);
        }
    }
}
