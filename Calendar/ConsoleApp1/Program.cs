using ConsoleApp1.Classes;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

var listOfPersons = new List<Person>();

var listOfEvents = new List<Event>();

var event1 = new Event("Split Grand Prix", "Split", DateTime.Now.AddDays(0), DateTime.Now.AddDays(7));
listOfEvents.Add(event1);
event1.SetDafaultEmails();

var event2 = new Event("Dubrovnik Grand Prix", "Dubrovnik", DateTime.Now.AddDays(-14), DateTime.Now.AddDays(-12));
listOfEvents.Add(event2);
event2.SetDafaultEmails2();

var event3 = new Event("Zagreb Grand Prix", "Zagreb", DateTime.Now.AddDays(19), DateTime.Now.AddDays(21));
listOfEvents.Add(event3);
event3.SetDafaultEmails3();

var event4 = new Event("Zadar Grand Prix", "Zadar", DateTime.Now.AddDays(26), DateTime.Now.AddDays(28));
listOfEvents.Add(event4);
event4.SetDafaultEmails4();

var event5 = new Event("Osijek Grand Prix", "Osijek", DateTime.Now.AddDays(33), DateTime.Now.AddDays(35));
listOfEvents.Add(event5);
event5.SetDafaultEmails5();

var peron1 = new Person("Sebastian", "Vettel", "sebastianvettel@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron1);
var peron2 = new Person("Max", "Verstappen", "maxverstappen@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron2);
var peron3 = new Person("Sergio", "Perez", "sergioperez@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron3);
var peron4 = new Person("Charles", "Leclerc", "charlesleclerc@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron4);
var peron5 = new Person("Carlos", "Sainz", "carlossainz@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron5);
var peron6 = new Person("Lewis", "Hamilton", "lewishamilton@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron6);
var peron7 = new Person("George", "Russell", "georgerussell@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron7);
var peron8 = new Person("Lando", "Norris", "landonorris@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron8);
var peron9 = new Person("Oscar", "Piastri", "oscarpiastri@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron9);
var peron10 = new Person("Nico", "Hulkenberg", "nicohulkenberg@mail.com", listOfEvents, listOfPersons);
listOfPersons.Add(peron10);

void SystemLoading()
{
    Console.WriteLine("Loading...");
    Console.Write("[");
    for (var i = 0; i < 10; i++)
    {
        var rand = new Random();
        int num = rand.Next(100, 1000);
        Console.Write("#");
        Thread.Sleep(num);
    }
    Console.Write("]");
    Thread.Sleep(1000);
    Console.Clear();
}

bool PrintActiveEvents()
{
    foreach (var i in listOfEvents)
    {
        if (i.DateStart < DateTime.Now && i.DateEnd > DateTime.Now)
        {

            var hour =i.DateEnd.Date - DateTime.Now.Date;
            Console.WriteLine($"Tren5utno aktivni event:\n" +
                $"Ime:{i.Name}\n" +
                $"Lokacija: {i.Location}\n" +
                $"Sati do zavrsetka: {Math.Round((decimal)hour.Days*24,1)}\n" +
                $"Sudionici:");
            foreach (var email in i.Emails) Console.WriteLine(email);
            Console.WriteLine("\n");
            return true;
        }
    }
    return false;
}

bool PrintFutureEvents()
{
    var flag = 0;
    foreach (var i in listOfEvents)
    {
        if(i.DateStart > DateTime.Now)
        {
            var hours = i.DateEnd - i.DateStart;
            Console.WriteLine($"\nNadolazeci event:\n" +
                $"Ime:{i.Name}\n" +
                $"Lokacija: {i.Location}\n" +
                $"Dana do pocetka: {i.DateStart.Day}\n" +
                $"Vrijeme trajanja: {24*hours.Days}h\n" +
                $"Sudionici:");
            foreach (var email in i.Emails) Console.WriteLine(email);
            Console.WriteLine($"ID: {i.Id}\n");
            Thread.Sleep(1000);
            flag = 1;
        }
    }
    if(flag==0)
        return false;
    return true;
}

bool DeleteEvent()
{
    Console.WriteLine("Unesite event ID onog eventa kojeg zelite izbrisati:");
    var id = Console.ReadLine();
    foreach(var i in listOfEvents)
    {
        if (i.Id.ToString() == id && i.DateStart > DateTime.Now)
        {
            Console.WriteLine("Jeste li sigurni da zelite izbrisati event?" +
                "\nDa[y]" +
                "\nNe[n]");
            var yn = Console.ReadLine();
            switch (yn)
            {
                case "y":
                    listOfEvents.Remove(i);
                    return true;
                    break;
                case "n":
         
                    return false;
                    break;
            }
        }
    }
    return false;
}

bool DeleteParticipant()
{
    Console.WriteLine("Unesite ID eventa:");
    var id = Console.ReadLine();
    Console.WriteLine("Unesite mail osobe koje zelite obrisati:");
    var mail = Console.ReadLine();
    foreach(var i in listOfEvents)
    {
        if (i.Id.ToString() == id && i.DateStart > DateTime.Now)
        {
            foreach(var j in i.Emails)
            {
                if(j == mail)
                {
                    Console.WriteLine("Jeste li sigurni da zelite izbrisati sudionika?" +
                        "\nDa[y]" +
                        "\nNe[n]");
                    var yn = Console.ReadLine();
                    switch (yn)
                    {
                        case "y":
                            i.Emails.Remove(j);
                            return true;
                            break;
                        case "n":
                            return false;
                            break;
                        default:
                            Console.WriteLine("Krivi unos!");
                            break;
                    }
                }
            }
            return false;
        }
    }
    return false;
}

bool PrintPastEvents()
{
    var flag = 0;
    foreach (var i in listOfEvents)
    {
        if (i.DateEnd < DateTime.Now)
        {
            var hours = i.DateEnd - i.DateStart;
            Console.WriteLine($"\nZavrseni event:\n" +
                $"Ime:{i.Name}\n" +
                $"Lokacija: {i.Location}\n" +
                $"Dana od zavrsetka: {DateTime.Now.Day - i.DateEnd.Day}\n" +
                $"Vrijeme trajanja: {24 * hours.Days}h\n");
            Thread.Sleep(1000);
            flag = 1;
        }
    }
    if (flag == 0)
        return false;
    return true;
}

//SystemLoading();

Console.WriteLine("Dobrodosli u aplikaijcu za managanje vasih evenata. Unesite broj za zeljenu akciju:");

int userInput1;

do
{
    Console.WriteLine("1 - Aktivni eventi");
    Console.WriteLine("2 - Nadolazeci eventi");
    Console.WriteLine("3 - Zavrseni eventi");
    Console.WriteLine("0 - Izadi iz aplikacije");
    userInput1 = int.Parse(Console.ReadLine());
    switch (userInput1)
    {
        case 1:
            if (PrintActiveEvents())
            {
                Console.WriteLine("\n1 - Unesi prisutnost");
                Console.WriteLine("0 - Povratak na glavni meni");
                var userInput2 = int.Parse(Console.ReadLine());
                switch (userInput2)
                {
                    case 1:

                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Krivi unos!\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Trenutno nema aktivnih evenata\n");
            }
            break;
        case 2:
            if (PrintFutureEvents())
            {
                Console.WriteLine("\n1 - Izbrisi event");
                Console.WriteLine("2 - Izbrisi sudionika");
                Console.WriteLine("0 - Povratak na glavni meni");
                var userInput3 = int.Parse(Console.ReadLine());
                switch (userInput3)
                {
                    case 1:
                        if (DeleteEvent())
                            Console.WriteLine("Event uspjesno izbrisan!\n");
                        else
                            Console.WriteLine("Event nije izbrisan!\n");
                        break;
                    case 2:
                        if (DeleteParticipant())
                            Console.WriteLine("Sudionik uspjesno izbrisan!\n");
                        else
                            Console.WriteLine("Sudionik nije izbrisan!\n");
                        break;
                    default:
                        Console.WriteLine("Krivi unos!\n");
                        break;
                }
            }
            else
                Console.WriteLine("Ne postoje nikakvi buduci eventovi!\n");
            break;
        case 3:
            if (!PrintPastEvents())
            {
                Console.WriteLine("Ne postoji niti jedan zavrseni event!\n");
            }
            break;
        case 0:
            break;
        default:
            Console.WriteLine("Krivi unos!\n");
            break;
    } 
} while (userInput1 != 0);

