using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    public class Program
    {
        public Dictionary<string, AddressRecord> addressBook = new Dictionary<string, AddressRecord>();
    
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To AddressBook System");

            bool flag = true;
            bool flagContact = true;

            AddressRecord addressRecord = new AddressRecord();
            AddressFunction addressFunction = new AddressFunction();

            while (flag)
            {
                Console.WriteLine("Chose an Option:\n" +
                    "Create New Address Book" + addressRecord.name + "\n"+
                    "Exit");

                int userChoice = Convert.ToInt32(Console.ReadLine());

                switch(userChoice)
                {
                    case 1:
                        flagContact = true;
                        Console.WriteLine("Add Name of new Address Book\n");
                        addressRecord.name = Console.ReadLine();
                        break;

                    case 0:
                        flagContact = false;
                        flag = false;
                        break;

                    default:
                        break;
                }

                while(flagContact ==true)
                {
                    Console.WriteLine("Enter\n" +
                    "1 : Add Contact Details to " + addressRecord.name + " Address Book\n" +
                    "2 : Edit a Contact Detail\n" +
                    "3 : Delete a Contact Detail\n" +
                    "4 : Exit");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch(choice)
                    {
                        case 1:
                            addressFunction.AddContactDetails();
                            break;

                        case 2:
                            addressFunction.EditContactDetails();
                            break;
                            

                        case 3:
                            addressFunction.DeleteContactDetails();
                            break;
                            
                        case 4:
                            addressFunction.searchState();
                            break;

                        case 5:
                            addressRecord.SortPersonByName();
                            break;

                        case 6:
                            addressFunction.searchState();
                            break;

                        case 7:
                            addressRecord.ReadorWriteinFile();
                            break;

                        case 8:
                            addressRecord.ReadorWriteinCSVFile();
                            break;

                        case 9:
                            addressRecord.ReadorWriteinJSONFile();
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
    }
}
