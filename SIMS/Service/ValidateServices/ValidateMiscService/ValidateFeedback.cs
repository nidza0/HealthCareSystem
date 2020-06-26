using SIMS.Exceptions;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMiscService
{
    class ValidateFeedback : IValidateService<Feedback>
    {
        public void Validate(Feedback entity)
        {
            if(entity.User == null)
            {
                throw new ServiceException("FeedbackService - User is null!");
            }

            if(entity.Comment.Length < 1 && entity.Rating == null)
            {
                throw new ServiceException("FeedbackService - Feedback is empty!");
            }
        }
    }
}
