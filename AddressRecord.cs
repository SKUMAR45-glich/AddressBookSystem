using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressRecord
    {
        public List<ContactDetails> contactDetails = new List<ContactDetails>();
        public int totalContacts { get; set; }

        public AddressRecord()
        {

        }

        public void AddContact(ContactDetails contactDetails)
        {
            this.contactDetails.Add(contactDetails);
            totalContacts = this.contactDetails.Count;
        }
    }
}
