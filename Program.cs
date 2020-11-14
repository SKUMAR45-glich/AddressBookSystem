using System;

namespace AddressBookSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To AddressBook System");

            bool flag = true;

            AddressRecord addressRecord = new AddressRecord();
            AddressDetails addressDetails = new AddressDetails();

            while (flag)
            {
                
                var contact = addressDetails.UserValue();
                addressRecord.AddContact(contact);


                Console.WriteLine("Do you want to Enter more Y for Yes N for No:\n");
                char choice = Convert.ToChar(Console.ReadLine());

                if(choice == 'N')
                {
                    addressRecord.Display(contact);
                    flag = false;
                }
                
            }

            Console.WriteLine("Enter the Name of Person to Edit\n");
            string firstName = Console.ReadLine();

            if(addressRecord.contactDetails.ContainsKey(firstName))
            {
                var contactToEdit =addressRecord.contactDetails[firstName];
                addressRecord.Display(contactToEdit);

                Console.WriteLine("Enter the new values");
                var contact = addressDetails.UserValue();
                addressRecord.EditContact(firstName, contact);
                addressRecord.Display(contact);
            }

            else
            {
                Console.WriteLine("No Records Found");
            }
            

            Console.WriteLine("Enter FirstName to be deleted\n");
            Console.WriteLine("Enter the Name of Person to Deleted\n");
            //string firstName = Console.ReadLine();

            if (addressRecord.contactDetails.ContainsKey(firstName))
            {
                var contactToDelete = addressRecord.contactDetails[firstName];
                Console.WriteLine("Data before Deletion");
                addressRecord.Display(contactToDelete);

                Console.WriteLine("Data After Deletion");
                addressRecord.DeleteContact(firstName, contactToDelete);
                addressRecord.Display(contactToDelete);
            }

            else
            {
                Console.WriteLine("No Records Found");
            }
        }
    }
}
