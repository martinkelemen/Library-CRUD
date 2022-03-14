// <copyright file="RenterRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;

    /// <summary>
    /// The renter repository class inherited from the abstract Repository class, implements the IRenterRepository.
    /// </summary>
    public class RenterRepository : DbRepository<Renter, int>, IRenterRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenterRepository"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        public RenterRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Changes the address of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newAddress">The new address of the renter.</param>
        public void ChangeAddress(int id, string newAddress)
        {
            var renter = this.GetOne(id);
            renter.Address = newAddress;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes the email of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newEmail">The new email of the renter.</param>
        public void ChangeEmail(int id, string newEmail)
        {
            var renter = this.GetOne(id);
            renter.Email = newEmail;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes the type of the membership by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newMembershipType">The new type of membership.</param>
        public void ChangeMembershipType(int id, string newMembershipType)
        {
            var renter = this.GetOne(id);
            renter.MembershipType = newMembershipType;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes the name of a renter by id.
        /// </summary>
        /// <param name="id">The id of the renter.</param>
        /// <param name="newName">The new name of the renter.</param>
        public void ChangeName(int id, string newName)
        {
            var renter = this.GetOne(id);
            renter.Name = newName;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Returns a Renter instance by id.
        /// </summary>
        /// <param name="id">The id of the instance.</param>
        /// <returns>A Renter instance.</returns>
        public override Renter GetOne(int id)
        {
            var set = this.GetAll();
            if (id < 1)
            {
                throw new IDOutOfRangeException("There is no such ID in this table.");
            }
            else
            {
                Renter r = set.SingleOrDefault(x => x.RenterId == id);

                if (r == null)
                {
                    throw new IDOutOfRangeException("There is no such ID in this table.");
                }

                return r;
            }
        }

        public override void Update(Renter item)
        {
            var old = GetOne(item.RenterId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            Ctx.SaveChanges();
        }
    }
}
