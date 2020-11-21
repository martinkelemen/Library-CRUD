// <copyright file="MainProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConsoleTools;
    using MyLibrary.Data;
    using MyLibrary.Logic;

    /// <summary>
    /// The main program.
    /// </summary>
    public static class MainProgram
    {
        /// <summary>
        /// The main method, where the program starts.
        /// </summary>
        public static void Main()
        {
            Factory factory = new Factory();
            Console.WindowWidth = 150;
            Console.WindowHeight = 25;
            Console.Title = "Library Database";

            var menu = new ConsoleMenu()
                .Add(">>BOOKS", () => Menu.BookMenu(factory.LibraryLogic))
                .Add(">>WORKERS", () => Menu.WorkerMenu(factory.PersonLogic))
                .Add(">>RENTERS", () => Menu.RenterMenu(factory.PersonLogic))
                .Add(">>BOOK RENTALS", () => Menu.RentalMenu(factory.LibraryLogic, factory.PersonLogic))
                .Add(">>GROUP BY LANGUAGES WITH AVERAGES OF THE NUMBER OF RENTAL DAYS", () => Menu.GroupByLanguages(factory.LibraryLogic))
                .Add(">>GROUP BY MEMBERSHIP TYPES AND COUNT THEM", () => Menu.GroupByMembershipType(factory.LibraryLogic))
                .Add(">>LIST RENTALS WITH ALL NAMES", () => Menu.ListAllRentsWithNames(factory.LibraryLogic))
                .Add(">>GROUP BY LANGUAGES WITH AVERAGES OF THE NUMBER OF RENTAL DAYS ASYNC", () => Menu.GroupByLanguagesAsync(factory.LibraryLogic))
                .Add(">>GROUP BY MEMBERSHIP TYPES AND COUNT THEM ASYNC", () => Menu.GroupByMembershipTypeAsync(factory.LibraryLogic))
                .Add(">>LIST RENTALS WITH ALL NAMES ASYNC", () => Menu.ListAllRentsWithNamesAsync(factory.LibraryLogic))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
        }
    }
}