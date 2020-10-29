// <copyright file="IRenterRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLibrary.Data;

    /// <summary>
    /// The renter repository interface that implements the generic IRepository interface.
    /// </summary>
    public interface IRenterRepository : IRepository<Renter, int>
    {
        /// <summary>
        /// Changes the name of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newName">The new name of the renter.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// Changes the address of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newAddress">The new address of the renter.</param>
        void ChangeAddress(int id, string newAddress);

        /// <summary>
        /// Changes the email of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newEmail">The new email of the renter.</param>
        void ChangeEmail(int id, string newEmail);

        /// <summary>
        /// Changes the type of the membership by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newMembershipType">The new type of membership.</param>
        void ChangeMembershipType(int id, string newMembershipType);
    }
}
