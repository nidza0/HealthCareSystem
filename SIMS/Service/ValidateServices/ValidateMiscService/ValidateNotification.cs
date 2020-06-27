using SIMS.Exceptions;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMiscService
{
    class ValidateNotification : IValidateService<Notification>
    {
        public void Validate(Notification entity)
        {
            if(entity.Recipient == null)
            {
                throw new ServiceException("NotificationService - Recipient is not set!");
            }
        }
    }
}
