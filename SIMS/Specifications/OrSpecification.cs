// File:    OrSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 18:23:37
// Purpose: Definition of Class OrSpecification

using System;

namespace SIMS.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> leftSpecification;
        private ISpecification<T> rightSpecification;

    }
}