using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Common.Modal.Settings
{
    public class ContactInfoVM
    {
        public int Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string HomePhoneNumber { get; set; } = string.Empty;
        public string BusinessPhoneNumber { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string MailingAddress { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
