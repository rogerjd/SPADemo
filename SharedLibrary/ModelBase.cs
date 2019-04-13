using System;
using System.Collections.Generic;

namespace SharedLibrary
{
    public class ModelBase
    {
        private Dictionary<string, Dictionary<string, string>> _errors =
            new Dictionary<string, Dictionary<string, string>>();

        public void AddError(string fieldName, string ruleName, string errorText)
        {

        }
    }
}
