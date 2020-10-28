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

    public class RenterRepository : Repository<Renter, int>, IRenterRepository
    {
        public RenterRepository(DbContext ctx)
            : base(ctx)
        {
        }

        public void ChangeAddress(int id, string newAddress)
        {
            var renter = GetOne(id);
            renter.Address = newAddress;
            this.ctx.SaveChanges();
        }

        public void ChangeEmail(int id, string newEmail)
        {
            var renter = GetOne(id);
            renter.Email = newEmail;
            this.ctx.SaveChanges();
        }

        public void ChangeMembershipType(int id, string newMembershipType)
        {
            var renter = GetOne(id);
            renter.MembershipType = newMembershipType;
            this.ctx.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var renter = GetOne(id);
            renter.Name = newName;
            this.ctx.SaveChanges();
        }

        public override Renter GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.RenterId == id);
        }
    }
}
