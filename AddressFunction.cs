using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressFunction
    {
        AddressDetails addressDetails = new AddressDetails();
        AddressRecord addressRecord = new AddressRecord();

        public void AddContactDetails()
        {
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("Enter Details");
                var contact = addressDetails.UserValue();
                addressRecord.AddContact(contact);

                Console.WriteLine("Do you want to Enter more Y for Yes N for No:\n");
                char c = Convert.ToChar(Console.ReadLine());

                if (c == 'N')
                {
                    flag = false;
                    addressRecord.Display(contact);
                }
            }
        }

        public void EditContactDetails()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the Name of Person to Edit\n");
                string firstName = Console.ReadLine();

                if (addressRecord.contactDetails.ContainsKey(firstName))
                {
                    var contactToEdit = addressRecord.contactDetails[firstName];
                    addressRecord.Display(contactToEdit);

                    Console.WriteLine("Enter the new values");
                    var contactEdit = addressDetails.UserValue();
                    addressRecord.EditContact(firstName, contactEdit);
                    addressRecord.Display(contactEdit);
                }

                else
                {
                    Console.WriteLine("No Records Found");
               
                }

                Console.WriteLine("Do you want to Edit more Y for Yes N for No:\n");
                char c = Convert.ToChar(Console.ReadLine());

                if (c == 'N')
                {
                    flag = false;
                }
            }
        }

        public void DeleteContactDetails()
        {
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("Enter the FirstName of Person to Deleted\n");
                string firstName = Console.ReadLine();

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


                Console.WriteLine("Do you want to Delete more Y for Yes N for No:\n");
                char c = Convert.ToChar(Console.ReadLine());

                if (c == 'N')
                {
                    flag = false;
                }
            }
        }
    }
}
