using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressDetails
    { 
        public ContactDetails UserValue()
        {
            ContactDetails contactDetails = new ContactDetails();
            string firstName = Console.ReadLine();
            if(contactDetails.firstName == firstName)
            {
                Console.WriteLine("Duplicate FirstName Values Not Allowed");
                return null;
            }
            string lastName = Console.ReadLine();
            string address = Console.ReadLine();
            string city = Console.ReadLine();
            string state = Console.ReadLine();
            string phoneNumber = Console.ReadLine();
            string email = Console.ReadLine();

            return new ContactDetails(firstName, lastName, address, city, state, phoneNumber, email);
        }
    }
}
