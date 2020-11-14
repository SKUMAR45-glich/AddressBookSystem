using System;

namespace AddressBookSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To AddressBook System");

            bool flag = true;

            while(flag)
            {
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                string address = Console.ReadLine();
                string city = Console.ReadLine();
                string state = Console.ReadLine();
                string phoneNumber = Console.ReadLine();
                string email = Console.ReadLine();
                ContactDetails contactDetails = new ContactDetails(firstName,lastName,address,city,state,phoneNumber,email);

                AddressRecord addressRecord = new AddressRecord();
                addressRecord.AddContact(contactDetails);

                Console.WriteLine("Do You Want to Enter More Contacts: Y for Yes N for No");
                char choice = Convert.ToChar(Console.ReadLine());

                if(choice == 'N')
                {
                    flag = false;
                }

            }
        }
    }
}
