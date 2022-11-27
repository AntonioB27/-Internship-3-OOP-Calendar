using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class Event
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<string> Emails { get; private set; }

        public Event(string name, string location, DateTime dateStart, DateTime dateEnd){
            Id = Guid.NewGuid();
            Name = name;
            Location = location;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Emails = new List<string>() { "empty" };
        }

        public Event(string name, string location, DateTime dateStart, DateTime dateEnd, List<string> emails)
        {
            Id = Guid.NewGuid();
            Name = name;
            Location = location;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Emails = emails;
        }

        public bool SetPeoplesEmails()
        {
            string emails;
            Console.WriteLine("Unesite e-mail adrese osoba koje dolaze na event, odvojite ih zarezom:");
            emails = Console.ReadLine();
            List<string> emailsList = emails.Split(' ').ToList();
            Emails = emailsList;
            return true;
        }

        public bool SetDafaultEmails()
        {
            List<string> emails = new List<string> { "sebastianvettel@mail.com", "maxverstappen@mail.com", "sergioserez@mail.com", "charlesleclerc@mail.com" };
            Emails = emails;
            return true;
        }

        public bool SetDafaultEmails2()
        {
            List<string> emails = new List<string> { "sebastianvettel@mail.com", "lewishamilton@mail.com", "georgerussell@mail.com", "charlesleclerc@mail.com" };
            Emails = emails;
            return true;
        }

        public bool SetDafaultEmails3()
        {
            List<string> emails = new List<string> { "charlesleclerc@mail.com", "maxverstappen@mail.com", "sergioserez@mail.com" };
            Emails = emails;
            return true;
        }

        public bool SetDafaultEmails4()
        {
            List<string> emails = new List<string> { "charlesleclerc@mail.com", "nicohulkenberg@mail.com", "georgerussell@mail.com" };
            Emails = emails;
            return true;
        }

        public bool SetDafaultEmails5()
        {
            List<string> emails = new List<string> { "sergioperez@mail.com", "maxverstappen@mail.com", "charlesleclerc@mail.com", "lewishamilton@mail.com" };
            Emails = emails;
            return true;
        }
    }
}
