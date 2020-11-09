// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ConsoleTools;
    using MyLibrary.Data;
    using MyLibrary.Logic;

    public class Menu
    {
        public void BookMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOKS", () => this.ListAllBooks(libraryLogic))
                .Add(">> ADD A NEW BOOK", () => this.AddNewBook())
                .Add(">> DELETE A BOOK", () => this.DeleteBook())
                .Add(">> MODIFY A BOOK", () => this.ModifyBook())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ListAllBooks(ILibraryLogic libraryLogic)
        {
            Console.WriteLine(Book.ColumnInfo());
            libraryLogic.GetAllBooks().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void AddNewBook()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void DeleteBook()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyBook()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void WorkerMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL WORKERS", () => ListAllWorkers(personLogic))
                .Add(">> ADD A NEW WORKER", () => AddNewWorker())
                .Add(">> DELETE A WORKER", () => DeleteWorker())
                .Add(">> MODIFY A WORKER", () => ModifyBook())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ListAllWorkers(IPersonLogic personLogic)
        {
            Console.WriteLine(Worker.ColumnInfo());
            personLogic.GetAllWorkers().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void AddNewWorker()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void DeleteWorker()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyWorker()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void RenterMenu(IPersonLogic personLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL RENTERS", () => ListAllRenters(personLogic))
                .Add(">> ADD A NEW RENTER", () => AddNewRenter())
                .Add(">> DELETE A RENTER", () => DeleteRenter())
                .Add(">> MODIFY A RENTER", () => ModifyRenter())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ListAllRenters(IPersonLogic personLogic)
        {
            Console.WriteLine(Renter.ColumnInfo());
            personLogic.GetAllRenters().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine($"\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void AddNewRenter()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void DeleteRenter()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyRenter()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        public void RentalMenu(ILibraryLogic libraryLogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL BOOK RENTALS", () => ListAllRentals(libraryLogic))
                .Add(">> ADD A BOOK RENTAL", () => AddNewRental())
                .Add(">> DELETE A BOOK RENTAL", () => DeleteRental())
                .Add(">> MODIFY A BOOK RENTAL", () => ModifyRental())
                .Add(">> RETURN", ConsoleMenu.Close);

            menu.Show();
        }

        private void ListAllRentals(ILibraryLogic libraryLogic)
        {
            Console.WriteLine(BookRental.ColumnInfo());
            libraryLogic.GetAllBookRentals().ToList().ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void AddNewRental()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void DeleteRental()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }

        private void ModifyRental()
        {
            Console.WriteLine("Not implemented yet." + ' ');
            Console.WriteLine("\nPress a button to continue." + ' ');
            Console.ReadKey();
        }
    }
}
