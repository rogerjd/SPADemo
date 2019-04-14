using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    public interface IModelRule
    {
        ValidationResult Validate(string fieldName, object fieldValue)
    }
}
