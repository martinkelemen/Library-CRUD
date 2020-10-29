using MyLibrary.Data;
using MyLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLibrary.Logic
{
    public class PersonLogic : IPersonLogic
    {
        private IRenterRepository renterRepository;

        private IWorkerRepository workerRepository;

        public PersonLogic(IRenterRepository renterRepository, IWorkerRepository workerRepository)
        {
            this.renterRepository = renterRepository;
            this.workerRepository = workerRepository;
        }

        public void AddRenter(Renter renterInstance)
        {
            throw new NotImplementedException();
        }

        public void AddWorker(Worker workerInstance)
        {
            throw new NotImplementedException();
        }

        public void ChangeRenterAddress(int id, string newAddress)
        {
            throw new NotImplementedException();
        }

        public void ChangeRenterEmail(int id, string newEmail)
        {
            throw new NotImplementedException();
        }

        public void ChangeRenterMembershipType(int id, string newMembershipType)
        {
            throw new NotImplementedException();
        }

        public void ChangeRenterName(int id, string newName)
        {
            throw new NotImplementedException();
        }

        public void ChangeWorkerAddress(int id, string newAddress)
        {
            throw new NotImplementedException();
        }

        public void ChangeWorkerEmail(int id, string newEmail)
        {
            throw new NotImplementedException();
        }

        public void ChangeWorkerName(int id, string newName)
        {
            throw new NotImplementedException();
        }

        public void ChangeWorkerSalary(int id, int newSalary)
        {
            throw new NotImplementedException();
        }

        public IList<Renter> GetAllRenters()
        {
            return this.renterRepository.GetAll().ToList();
        }

        public IList<Worker> GetAllWorkers()
        {
            return this.workerRepository.GetAll().ToList();
        }

        public Renter GetRenterById(int id)
        {
            throw new NotImplementedException();
        }

        public Worker GetWorkerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
