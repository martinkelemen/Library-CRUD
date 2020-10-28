using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Logic
{
    interface IPersonLogic
    {
        Renter GetRenterById(int id);

        Worker GetWorkerById(int id);

        IList<Renter> GetAllRenters();

        IList<Worker> GetAllWorkers();

        void AddRenter(Renter renterInstance);

        void AddWorker(Worker workerInstance);

        void ChangeRenterAddress(int id, string newAddress);

        void ChangeRenterEmail(int id, string newEmail);

        void ChangeRenterMembershipType(int id, string newMembershipType);

        void ChangeRenterName(int id, string newName);

        void ChangeWorkerAddress(int id, string newAddress);

        void ChangeWorkerEmail(int id, string newEmail);

        void ChangeWorkerName(int id, string newName);

        void ChangeWorkerSalary(int id, int newSalary);
    }
}
