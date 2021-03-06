﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AddressBookSystem
{
    public class AddressFunction
    {
        AddressDetails addressDetails = new AddressDetails();
        AddressRecord addressRecord = new AddressRecord();
        AddressforSearching addressforSearching = new AddressforSearching();
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

        public void searchState()
        {
            string state = Console.ReadLine();
            var values = addressforSearching.contactDetailsInState(state);
            
            if(values==null)
            {
                Console.WriteLine("No ctact for this state");
            }
            Console.WriteLine($"{values.Count} Conatacts are for {state}");
        }

        public void DataintheDateRange()
        {
            Console.WriteLine("Enter the Starting Date of DateRange");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the End Date of DateRange");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            List<DataRow> data = AddressDetailsforSQLqueries.ContactDetailsBetweenDateRange(startDate, endDate);

            foreach(DataRow dataRow in data)
            {
                Console.WriteLine(dataRow.Field<string>("firstName"));
            }
        }

        public void countDataintheState()
        {
            Dictionary<string, int> countContactByState = AddressDetailsforSQLqueries.retrieveCountByState();
            Console.WriteLine("State\tCount");
            foreach(var contact in countContactByState)
            {
                Console.WriteLine(contact.Key + "\t" + contact.Value);
            }
        }

        public void addContactinAddressBook()
        {
            AddressDetailsforSQLqueries addressDetailsforSQLqueries = new AddressDetailsforSQLqueries();
            ContactDetails contactDetails = new ContactDetails("MS","Dhoni","Legacy","Ranchi","Jharkhnad","99999999","msd@gmail.com");

            addressDetailsforSQLqueries.addContactinAddressDetails(contactDetails);

        }
    }
}
