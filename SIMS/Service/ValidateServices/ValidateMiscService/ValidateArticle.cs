using SIMS.Exceptions;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMiscService
{
    class ValidateArticle : IValidateService<Article>
    {
        public void Validate(Article entity)
        {
            if(entity.Author == null)
            {
                throw new ServiceException("ArticleService - Author is not set!");
            }
        }
    }
}
