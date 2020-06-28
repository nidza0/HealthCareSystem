using SIMS.Exceptions;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMiscService
{
    class ValidateMessage : IValidateService<Message>
    {
        public void Validate(Message entity)
        {
            if(entity.Sender == null)
            {
                throw new ServiceException("MessageService - Sender is not set!");
            }

            if (entity.Recipient == null)
            {
                throw new ServiceException("MessageService - Recipient is not set!");
            }
        }
    }
}
