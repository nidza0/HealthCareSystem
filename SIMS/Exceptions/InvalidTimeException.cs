﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Exceptions
{
    class InvalidTimeException : Exception
    {
        public InvalidTimeException()
        {

        }

        public InvalidTimeException(string message) : base(message)
        {

        }

        public InvalidTimeException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
