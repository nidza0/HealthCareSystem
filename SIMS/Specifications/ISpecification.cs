// File:    ISpecification.cs
// Author:  Geri
// Created: 19. maj 2020 17:22:51
// Purpose: Definition of Interface ISpecification

using System;

namespace Specifications
{
   public interface ISpecification<T>
   {
      Boolean IsSatisfiedBy(T candidate);
      
      ISpecification<T> And(ISpecification<T> other);
      
      ISpecification<T> Or(ISpecification<T> other);
      
      ISpecification<T> Not(ISpecification<T> other);
   
   }
}