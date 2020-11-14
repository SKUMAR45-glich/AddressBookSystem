using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressRecord
    {
        string addressName;
        public Dictionary<string, ContactDetails> contactDetails = new Dictionary<string, ContactDetails>();
        public int totalContacts { get; set; }

        public AddressRecord()
        {

        }

        public string name { get => addressName; set =>addressName = value; }

        public void AddContact(ContactDetails contactDetails)
        {
            this.contactDetails.Add(contactDetails.firstName,contactDetails);
            totalContacts = this.contactDetails.Count;
        }

        public void EditContact(string firstName, ContactDetails contactDetails)
        {
            if(firstName == contactDetails.firstName)
            {
                AddContact(contactDetails);
            }
            else
            {
                Console.WriteLine("Please Enter Coreect Name");
            }    
        }


        public void DeleteContact(string firstName, ContactDetails contactDetails)
        {
            if (!this.contactDetails.ContainsKey(firstName))
            {
                Console.WriteLine("Please Enter Correct Name");
                return;
            }

            this.contactDetails.Remove(firstName);
            Console.WriteLine("Deleted Successfully");
        }


        public void Display(ContactDetails contactDetails)
        {
            Console.WriteLine($"First Name {contactDetails.firstName}");
            Console.WriteLine($"Last Name {contactDetails.lastName}");
            Console.WriteLine($"Address {contactDetails.address}");
            Console.WriteLine($"PhoneNumber {contactDetails.phoneNumber}");
            Console.WriteLine($"City {contactDetails.city}");
            Console.WriteLine($"State {contactDetails.state}");
            Console.WriteLine($"PhoneNumber {contactDetails.phoneNumber}");
            Console.WriteLine($"Email {contactDetails.email}");
        }


        public void SeachbyState()
        {
            string state = Console.ReadLine();

            foreach (var contact in contactDetails)
            {
                if (contact.Value.state == state)
                {
                    contact.Value.Display();
                    Console.WriteLine();
                    
                }
                else
                {
                    Console.WriteLine("Please Enter Correct Value");
                }
            }
        }
    }
}
