using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; }
        public string Mail { get; }
        public Dictionary<string, bool> Presence { get; set; }

        private List<Event> Events = new List<Event>();

        private List<Person> Persons = new List<Person>();

        public Person(string firstName, string lastName, string mail, List<Event> listOfEvents, List<Person> listOfPersons)
        {
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
            Events = CreateListOfEvents(listOfEvents);
            Persons = CreateListOfPersons(listOfPersons);
        }

        private List<Event> CreateListOfEvents(List<Event> listOfEvents){
            return listOfEvents;
        }

        private List<Person> CreateListOfPersons(List<Person> listOfPersons) {
            return listOfPersons;
        }

        public bool SetPresence()
        {
            Console.WriteLine("Unesite ID eventa na kojem zelite zabiljeziti prisutnost:");
            string id = Console.ReadLine();
            foreach(var ev in Events)
            {
                if(id == ev.Id.ToString())
                {
                    Console.WriteLine("Unesite mail osobe ciju prisutnost zelite zabiljeziti:");
                    string mail = Console.ReadLine();
                    foreach(var person in Persons)
                    {
                        if(mail == person.Mail)
                        {
                            bool pre = bool.Parse(Console.ReadLine());
                            Presence.Add(id,pre);
                            Console.WriteLine($"ID:{Presence.ContainsKey(id)},Prisutnost:{Presence.ContainsKey(id)}");
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }

}
