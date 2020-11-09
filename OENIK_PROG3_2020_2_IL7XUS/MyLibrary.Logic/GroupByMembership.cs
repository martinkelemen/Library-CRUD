using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Logic
{
    public class GroupByMembership
    {
        public string MembershipType { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return $"{this.MembershipType} members {this.Count} times rented a book.";
        }
    }
}
