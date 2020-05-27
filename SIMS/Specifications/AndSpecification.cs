// File:    AndSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 17:22:53
// Purpose: Definition of Class AndSpecification

using System;

namespace SIMS.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> leftSpecification;
        private ISpecification<T> rightSpecification;

    }
}