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
            if (!_errors.ContainsKey(fieldName))
            {
                _errors.Add(fieldName, new Dictionary<string, string>());
            }
            if (_errors[fieldName].ContainsKey(ruleName))
            {
                _errors[fieldName].Remove(ruleName);
            }
            _errors[fieldName].Add(ruleName, errorText);
            OnModelChanged();
        }

        public void RemoveError(string fieldName, string ruleName)
        {
            if (!_errors.ContainsKey(fieldName)
            {
                _errors.Add(fieldName, new Dictionary<string, string>());
            }
            if (_errors[fieldName].ContainsKey(ruleName))
            {
                _errors[fieldName].Remove(ruleName);
            }
            OnModelChanged();
        }
    }
}
