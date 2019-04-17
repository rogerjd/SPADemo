using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib3.Rules
{
    public class MaxLengthRule : Attribute, IModelRule
    {
        private int _maxLength = 0;
        public MaxLengthRule(int maxLength) { _maxLength = maxLength; }

        public ValidationResult Validate(string fieldName, object fieldValue)
        {
            if (fieldValue == null) { return new ValidationResult { IsValid = true }; };

            var stringValue = fieldValue.ToString();
            if (stringValue.Length > _maxLength)
            {
                return new ValidationResult { IsValid = false, Message = $"Cannot be longer than {_maxLength} characters" };
            }
            return new ValidationResult { IsValid = true };
        }
    }
}
