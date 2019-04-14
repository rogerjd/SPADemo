using System;
using System.Collections.Generic;
using System.Text;

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
            if (!_errors.ContainsKey(fieldName))
            {
                _errors.Add(fieldName, new Dictionary<string, string>());
            }
            if (_errors[fieldName].ContainsKey(ruleName))
            {
                _errors[fieldName].Remove(ruleName);
            }
            OnModelChanged();
        }

        public void CheckRules(string fieldName)
        {
            var propInfo = this.GetType().GetProperty(fieldName); //todo: how does is see fld in desc?
            var attrInfos = propInfo.GetCustomAttributes(true);
            foreach (var attrInfo in attrInfos)
            {
                if (attrInfo is IModelRule modelRule)
                {
                    var value = propInfo.GetValue(this);
                    var result = modelRule.Valid(fieldName, value);
                    if (result.IsValid)
                    {
                        RemoveError(fieldName, attrInfo.GetType().Name);
                    }
                    else
                    {
                        AddError(fieldName, attrInfo.GetType().Name, result.Message);
                    }
                }
            }
        }

        public bool CheckRules()
        {
            foreach (var propInfo in this.GetType().GetProperties(
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance))
                CheckRules(propInfo.Name);

            return HasErrors();
        }

        public string Errors(string fieldName)
        {
            if (!_errors.ContainsKey(fieldName))
            {
                _errors.Add(fieldName, new Dictionary<string, string>());
            }

            StringBuilder sb = new StringBuilder();
            foreach (var err in _errors[fieldName].Values)
            {
                sb.AppendLine(err);
            }
            return sb.ToString();
        }

        public bool HasErrors()
        {
            foreach (var fn in _errors.Keys)
            {
                if (_errors[fn].Keys.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetValue(string fieldName)
        {
            var propInfo = this.GetType().GetProperty(fieldName);
            var value = propInfo.GetValue(this);
            if (value != null) { return value.ToString(); }
            return string.Empty;
        }

        public void SetValue(string fieldName, object value)
        {
            var propInfo = this.GetType().GetProperty(fieldName);
            propInfo.SetValue(this, value);
            CheckRules();
        }

        public event EventHandler<EventArgs> ModelChanged;

        protected void OnModelChanged()
        {
            ModelChanged?.Invoke(this, new EventArgs());
        }
    }
}
