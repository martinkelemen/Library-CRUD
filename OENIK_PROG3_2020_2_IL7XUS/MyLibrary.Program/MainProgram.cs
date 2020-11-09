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

            var menu = new ConsoleMenu()
                .Add(">>BOOKS", () => factory.Menu.BookMenu(factory.LibraryLogic))
                .Add(">>WORKERS", () => factory.Menu.WorkerMenu(factory.PersonLogic))
                .Add(">>RENTERS", () => factory.Menu.RenterMenu(factory.PersonLogic))
                .Add(">>BOOK RENTALS", () => factory.Menu.RentalMenu(factory.LibraryLogic))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
        }
    }
}