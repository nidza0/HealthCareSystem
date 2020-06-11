using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewPatient.Exceptions
{
    class RegistrationException : Exception
    {
        private RegistrationException()
        {

        }

        public RegistrationException(string name) : base(name)
        {

        }
    }
}
