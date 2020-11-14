using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    public class AddressforSearching
    {
        public Dictionary<string, List<ContactDetails>> stateContact = new Dictionary<string, List<ContactDetails>>();

        public void addToState(ContactDetails contactDetails)
        {
            if(stateContact.ContainsKey(contactDetails.city))
            {
                stateContact[contactDetails.city].Add(contactDetails);
            }
            else
            {
                stateContact.Add(contactDetails.city, new List<ContactDetails> { contactDetails});
            }
        }

        public List<ContactDetails> contactDetailsInState(string state)
        {
            if (!stateContact.ContainsKey(state))
                return null;
            return stateContact[state].ToList();
        }
    }
}
