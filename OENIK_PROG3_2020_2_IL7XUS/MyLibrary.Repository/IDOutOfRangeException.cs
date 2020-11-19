// <copyright file="IDOutOfRangeException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLibrary.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class for the wrong ID exceptions.
    /// </summary>
    public class IDOutOfRangeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IDOutOfRangeException"/> class.
        /// </summary>
        /// <param name="message">The message of the excepption.</param>
        public IDOutOfRangeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IDOutOfRangeException"/> class.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">An exception object.</param>
        public IDOutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IDOutOfRangeException"/> class.
        /// </summary>
        public IDOutOfRangeException()
        {
        }
    }
}
