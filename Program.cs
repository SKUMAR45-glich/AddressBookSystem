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
                AddressRecord addressRecord = new AddressRecord();
                AddressDetails addressDetails = new AddressDetails();

                var contact = addressDetails.UserValue();
                addressRecord.AddContact(contact);

                Console.WriteLine("Do you want to Enter more Y for Yes N for No:\n");
                char choice = Convert.ToChar(Console.ReadLine());

                if(choice == 'N')
                {
                    flag = false;
                }
                
            }
        }
    }
}
