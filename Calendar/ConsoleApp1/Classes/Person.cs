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

        public Dictionary<string, bool> GetPresence()
        {
            return Presence;
        }

        public bool SetPresence(Event event1, bool isPresent, Dictionary<string, bool> Presence)
        {
            Presence.Add(event1.Id.ToString(), isPresent);
            return true;
        }
    }

}
