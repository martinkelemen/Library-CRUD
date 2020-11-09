﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Logic
{
    public class GroupByLanguage
    {
        public string Language { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return $"A book with {this.Language} language was rented {this.Count} times.";
        }
    }
}
