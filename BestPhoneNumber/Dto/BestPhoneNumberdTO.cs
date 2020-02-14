using System;
using System.Collections.Generic;
using System.Text;

namespace BestPhoneNumber.Dto
{
    public class BestPhoneNumberDto
    {
        public BestPhoneNumberDto()
        {

        }
        public BestPhoneNumberDto(string phoneNumber, string telecomProvider)
        {
            PhoneNumber = phoneNumber;
            TelecomProvider = telecomProvider;
        }

        public string PhoneNumber { get; set; }
        public string TelecomProvider { get; set; }
    }
}
