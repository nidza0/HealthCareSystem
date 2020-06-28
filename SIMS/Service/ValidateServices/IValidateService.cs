using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices
{
    public interface IValidateService<T>
    {
        void Validate(T entity);
    }
}
