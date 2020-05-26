// File:    IFeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:54:24
// Purpose: Definition of Interface IFeedbackRepository

using System;

namespace Repository.Abstract.Misc
{
   public interface IFeedbackRepository : IRepository<Model.User.Feedback,long>
   {
   }
}