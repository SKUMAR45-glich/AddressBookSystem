using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSystem;
using System.Collections.Generic;

namespace AddressBookSystemTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<ContactDetails> contactDetails = new List<ContactDetails>();
            AddressDetailsforSQLqueries addressDetailsforSQLqueries = new AddressDetailsforSQLqueries();

            contactDetails.Add(new ContactDetails("MS", "Dhoni", "Legacy", "Ranchi", "Jharkhnad", "99999999", "msd@gmail.com"));
            contactDetails.Add(new ContactDetails("VK","Kohli","Captain","Delhi","Delhi","88888888","vk@gmail.com"));

            DateTime startDateTime = DateTime.Now;
            addressDetailsforSQLqueries.addingMultipleContactWithoutThread(contactDetails);
            DateTime endDateTime = DateTime.Now;
            Console.WriteLine("Without Thread : " + (endDateTime - startDateTime));               // Time Taken For Addition Without Thread



            DateTime startDateTimeThread = DateTime.Now;
            addressDetailsforSQLqueries.addingMultipleContactWithThread(contactDetails);
            DateTime endDateTimeThread = DateTime.Now;
            Console.WriteLine("With Thread : " + (endDateTimeThread - startDateTimeThread));       // Time Taken For Addition With Thread

        }
    }
}
