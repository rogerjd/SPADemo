using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Rules
{
    public interface IModelRule
    {
        ValidationResult Validate(string fieldName, object fieldValue);
    }
}
