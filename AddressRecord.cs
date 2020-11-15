using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    public class AddressRecord
    {
        
        string addressName;
        public Dictionary<string, ContactDetails> contactDetails = new Dictionary<string, ContactDetails>();
        public Dictionary<string, List<ContactDetails>> cityContactDetails = new Dictionary<string, List<ContactDetails>>();
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

        public void SortPersonByName()
        {
           foreach(KeyValuePair<string, ContactDetails> sortByName in contactDetails.OrderBy(key=>key.Key))
            {
                Console.WriteLine($"Sorted Name {sortByName.Key}");
            }
        }

        public void SortPersonByCity()
        {
            foreach (KeyValuePair<string, ContactDetails> sortByCity in contactDetails.OrderBy(key => key.Value.city))
            {
                Console.WriteLine($"Sorted Cities {sortByCity.Value.city}");
            }
        }

        public void ReadorWriteinFile()
        {
            Console.WriteLine("1. Read the text file" +
                "2. Write in the Text File" +
                "0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:

                    string path = @"C:\Users\saura\Desktop\Training\Pending\AddressBookSystem\AddressBookSystem\AddressBookSystem.txt";

                    if(!File.Exists(path))
                    {
                        Console.WriteLine("No such File Exists");
                        break;
                    }

                    using (var streamReader = File.OpenText(path))
                    {
                        string str = "";

                        while((str = streamReader.ReadLine()) != null)
                        {
                            Console.WriteLine(str);
                        }
                        break;
                    }



                case 2:

                    path = @"C:\Users\saura\Desktop\Training\Pending\AddressBookSystem\AddressBookSystem\AddressBookSystem.txt";

                    using(var streamWriter = File.AppendText(path))
                    {
                        foreach(var item in contactDetails)
                        {
                            streamWriter.WriteLine(item.Value.firstName);
                        }
                        streamWriter.Close();
                    }
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Please Enter Correct Option");
                    break;
            }
        }

        public void ReadorWriteinCSVFile()
        {
            Console.WriteLine("1. Read the CSV file" +
                "2. Write in the SCV File" +
                "0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    string path = @"C:\Users\saura\Desktop\Training\Pending\AddressBookSystem\AddressBookSystem\AddressBookSystem\ExampleCSV.csv";

                    if (!File.Exists(path))
                    {
                        Console.WriteLine("No such File Exists");
                        break;
                    }

                    using (var reader = new StreamReader(path))
                    using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var contacts = csvReader.GetRecords<ContactDetails>().ToList();
                        
                        foreach(var contact in contacts)
                        {
                            Display(contact);
                        }

                    }
                    break;



                case 2:

                    path = @"C:\Users\saura\Desktop\Training\Pending\AddressBookSystem\AddressBookSystem\AddressBookSystem\ExampleCSV.csv";

                    using (var reader = new StreamReader(path))
                    using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var items = contactDetails[name];
                        Console.WriteLine(items);
                    }
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Please Enter Correct Option");
                    break;
            }
        }

        public void ReadorWriteinJSONFile()
        {
            Console.WriteLine("1. Read the JSON file" +
                "2. Write in the JSON File" +
                "0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    string path = @"C:\Users\saura\Desktop\Training\Pending\AddressBookSystem\AddressBookSystem\AddressBookSystem\ExampleCSV.csv";

                    var contact = JsonConvert.DeserializeObject<List<KeyValuePair<string, ContactDetails>>>(File.ReadAllText(path));
                    foreach(var i in contact)
                    {
                        Display(i.Value);
                    }    

                    break;


                case 2:

                    path = @"C:\Users\saura\Desktop\Training\Pending\AddressBookSystem\AddressBookSystem\AddressBookSystem\ExampleCSV.csv";

                    var list = contactDetails.ToList();
                    var copy = new List<ContactDetails>();
                    foreach(var item in list)
                    {
                        copy.Add(item.Value);
                    }
                    
                    var serializeObject = new JsonSerializer();
                    using(var streamWriter = new StreamWriter(path))
                    using(var jsonWriteObject = new JsonTextWriter(streamWriter))
                    {
                        serializeObject.Serialize(jsonWriteObject, copy);
                    }
                    
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Please Enter Correct Option");
                    break;
            }
        }
    }
}
