using System.Collections.Generic;
using FluentValidation;

namespace CM.Payments.Client.Validators
{
    internal class PaymentValidatorBase<TBase> : BaseValidator<TBase>
    {
        protected void AddValidator<TType, TValidatorType>() where TValidatorType : IEnumerable<IValidationRule>, IValidator<TType>, new()
            where TType : TBase
        {
            When(t => t.GetType() == typeof(TType), AddDerivedRules<TValidatorType>);
        }

        private void AddDerivedRules<T>() where T : IEnumerable<IValidationRule>, new()
        {
            IEnumerable<IValidationRule> validator = new T();
            foreach (var rule in validator)
            {
                AddRule(rule);
            }
        }
    }
}