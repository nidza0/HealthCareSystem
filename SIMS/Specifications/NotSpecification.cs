// File:    NotSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 18:23:38
// Purpose: Definition of Class NotSpecification

using System;

namespace Specifications
{
   public class NotSpecification<T> : CompositeSpecification<T>
   {
      private ISpecification<T> leftSpecification;
      private ISpecification<T> rightSpecification;
   
   }
}