using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Exceptions
{
    class ArticleServiceException : Exception
    {

        public ArticleServiceException()
        {

        }

        public ArticleServiceException(string message) : base(message)
        {

        }

        public ArticleServiceException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
