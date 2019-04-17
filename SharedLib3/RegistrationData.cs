using SharedLib3.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib3
{
    public class RegistrationData: ModelBase
    {
        [RequiredRule]
        [MaxLengthRule(50)]
        public string FirstName { get; set; }

        [RequiredRule]
        [MaxLengthRule(50)]
        public string LastName { get; set; }
    
        [EmailRule]
        public string Email { get; set; }

        [PhoneRule]
        public string Phone { get; set; }
    }
}
