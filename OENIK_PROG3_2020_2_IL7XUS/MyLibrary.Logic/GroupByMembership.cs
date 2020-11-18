// <copyright file="GroupByMembership.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class for one of the non-crud methods. Contains information about how many times a type of membership member rented a book.
    /// </summary>
    public class GroupByMembership
    {
        /// <summary>
        /// Gets or sets the type of the membership.
        /// </summary>
        public string MembershipType { get; set; }

        /// <summary>
        /// Gets or sets how many times was a book rented by a membership type.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gives back all of the properties of the query.
        /// </summary>
        /// <returns>Returns a string.</returns>
        public override string ToString()
        {
            return $"{this.MembershipType} members {this.Count} times rented a book.";
        }

        public override bool Equals(object obj)
        {
            if (obj is GroupByMembership)
            {
                return (obj as GroupByMembership).Count == this.Count &&
                    (obj as GroupByMembership).MembershipType == this.MembershipType;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
