using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    public class Program
    {
        //Dictionary for AddressRecord
        public Dictionary<string, AddressRecord> addressBook = new Dictionary<string, AddressRecord>();

    
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To AddressBook System");

            Console.WriteLine("Enter your choice" +
                "1. To Enter into Normal AddressBook " +
                "2. To Enter into Ado.net AddressBook");

            int flag = Convert.ToInt32(Console.ReadLine());


            //Process for AddressRecord Manual Insertion from User
            if(flag == 1)
            {
                bool flagContact = true;

                AddressRecord addressRecord = new AddressRecord();                                   //Address Record Class
                AddressFunction addressFunction = new AddressFunction();                             //Address Function Class

                while (flag == 1)
                {
                    Console.WriteLine("Chose an Option:\n" +
                        "Create New Address Book" + addressRecord.name + "\n" +                       
                        "Exit");

                    int userChoice = Convert.ToInt32(Console.ReadLine());

                    switch (userChoice)
                    {
                        case 1:                                                                     //Creation of AddressBook
                            flagContact = true;
                            Console.WriteLine("Add Name of new Address Book\n");
                            addressRecord.name = Console.ReadLine();
                            break;

                        case 0:
                            flagContact = false;
                            flag = 0;
                            break;

                        default:
                            break;
                    }

                    while (flagContact == true)
                    {
                        Console.WriteLine("Enter\n" +
                        "1 : Add Contact Details to " + addressRecord.name + " Address Book\n" +
                        "2 : Edit a Contact Detail\n" +
                        "3 : Delete a Contact Detail\n" +
                        "4 : Exit");

                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                addressFunction.AddContactDetails();                                      //Addition of Contact Details to AddressBook
                                break;

                            case 2:
                                addressFunction.EditContactDetails();                                     //Edition of Contact Details to AddressBook
                                break;


                            case 3:
                                addressFunction.DeleteContactDetails();                                   //Deletion of Contact Details to AddressBook
                                break;

                            case 4:
                                addressFunction.searchState();                                            //Searching of Contact with State to AddressBook
                                break;

                            case 5:
                                addressRecord.SortPersonByName();                                        //Sorting of Contact Name in AddressBook
                                break;

                            case 6:
                                addressFunction.searchState();                                           //Count of Contact Details to AddressBook
                                break;

                            case 7:
                                addressRecord.ReadorWriteinFile();                                      //Read Write in Text Contact Details to AddressBook
                                break;

                            case 8:
                                addressRecord.ReadorWriteinCSVFile();                                  //Read Write in CSV Contact Details to AddressBook
                                break;

                            case 9:
                                addressRecord.ReadorWriteinJSONFile();                                 //Read Write in JSON Contact Details to AddressBook
                                break;

                            case 0:
                                flagContact = false;
                                break;

                            default:
                                Console.WriteLine("Enter Correct Option");
                                break;

                        }
                    }
                }
            }
            

            //Process of AddressBook insertion With DBMS
            else if(flag == 2)
            {
                AddressFunction addressFunction = new AddressFunction();
                AddressDetailsforSQLqueries addressDetailsforSQLqueries = new AddressDetailsforSQLqueries();

                Console.WriteLine("Welcome To the Database Program of AddressBook");

                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch(choice)
                {
                    case 1:
                        addressDetailsforSQLqueries.GetAllDetails();                         //Get All Details from Database
                        break;

                    case 2:
                        addressDetailsforSQLqueries.addAddressDetails();                     //Add Details to contact in Database
                        break;

                    case 3:
                        addressFunction.DataintheDateRange();                               //Retrieve Data through DataRange
                        break;

                    case 4:
                        addressFunction.countDataintheState();                             //Count data in the State
                        break;

                    case 5:
                        addressFunction.addContactinAddressBook();                         //Addition of Contact in AddressBook
                        break;

                    case 0:
                        break;

                }
            }

            else
            {
                Console.WriteLine("Please Enter correct Option");
            }
        }
    }
}
