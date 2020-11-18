// <copyright file="IDOutOfRangeException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IDOutOfRangeException : Exception
    {
        public IDOutOfRangeException(string message)
            : base(message)
        {
        }

        public IDOutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
