using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib3.Rules
{
    public interface IModelRule
    {
        ValidationResult Validate(string fieldName, object fieldValue);
    }
}
