using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressDetails
    {
        public ContactDetails UserValue()
        {

            string firstName = Console.ReadLine();
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
