// File:    ExpressionSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 18:28:49
// Purpose: Definition of Class ExpressionSpecification

using System;

namespace SIMS.Specifications
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private Func<T, bool> expression;

        public ExpressionSpecification(Func<T, bool> expression)
        {
            throw new NotImplementedException();
        }

    }
}