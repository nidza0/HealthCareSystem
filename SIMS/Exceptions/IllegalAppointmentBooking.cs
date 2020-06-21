using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Exceptions
{
    class IllegalAppointmentBooking : Exception
    {
        public IllegalAppointmentBooking()
        {

        }

        public IllegalAppointmentBooking(string message) : base(message)
        {

        }

        public IllegalAppointmentBooking(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
