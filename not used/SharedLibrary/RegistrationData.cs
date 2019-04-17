using SharedLibrary.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary
{
    class RegistrationData: ModelBase
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
