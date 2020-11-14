using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class ContactDetails
    {

        //Default Constructor
        public ContactDetails()
        {

        }


        //Auto Get Set Function
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }


       //Paramaterized Constructor
        public ContactDetails(string firstName, string lastName, string address, string city, string state, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }
}
