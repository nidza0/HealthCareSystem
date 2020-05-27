// File:    CompositeSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 18:20:27
// Purpose: Definition of Class CompositeSpecification

using System;

namespace SIMS.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> And(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSatisfiedBy(T candidate)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Not(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            throw new NotImplementedException();
        }
    }
}