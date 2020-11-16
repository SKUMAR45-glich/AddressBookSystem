using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressModelforSQL
    {
        public string ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string contactName { get; set; }
        public string contactType { get; set; }
        public DateTime dateOfJoining { get; set; }
    }
}
