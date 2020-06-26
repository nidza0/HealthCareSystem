using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Exceptions
{
    class DoctorFeedbackServiceException: Exception
    {
        public DoctorFeedbackServiceException()
        {

        }

        public DoctorFeedbackServiceException(string message) : base(message)
        {

        }

        public DoctorFeedbackServiceException(string message, Exception inner) : base(message, inner)
        {

        }

    }
}
