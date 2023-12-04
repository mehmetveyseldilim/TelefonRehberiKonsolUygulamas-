using System.Text;
using TelefonRehberiKonsolUygulaması;
namespace TelefonRehberiKonsolUygulaması
{
    // Rehber
    public class Phone 
    {
        public Person User {get; set;}

        public List<Person> Persons {get; set;}

        public Phone(Person user)
        {
            this.User = user ?? throw new ArgumentNullException($"{nameof(User)}");
            Persons = new List<Person>();
            
        }

        public void SavePerson(Person person) 
        {
            Persons.Add(person);
        }

        public void DeletePerson(string nameOrLastName) 
        {
            var person = FindPerson(nameOrLastName);

            Persons.Remove(person!);
        }

        public void EditPerson(Person person, string newPhoneNumber) 
        {
            

            person.PhoneNumber = newPhoneNumber;


        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(var person in Persons) 
            {
                stringBuilder.AppendLine(person.ToString());
            }

            return stringBuilder.ToString();


        }

        public Person? FindPersonByNameOrLastName(string nameOrLastName) 
        {
            var person = FindPerson(nameOrLastName);

            return person;
        }

        public Person? FindPersonViaPhoneNumber(string phoneNumber) 
        {
            var person = FindPersonByPhoneNumber(phoneNumber);



            return person;
        }

        public IEnumerable<Person> FindPersonsViaNameOrSurname(string nameOrSurName) 
        {
            var result = Persons.Where(p => p.Name.Contains(nameOrSurName, StringComparison.OrdinalIgnoreCase) ||
                        p.Surname.Contains(nameOrSurName, StringComparison.OrdinalIgnoreCase));

            return result;
        }


        private Person? FindPerson(string nameOrLastName) 
        {
            Person person = Persons.FirstOrDefault
            (p => p.Name.Equals(nameOrLastName, StringComparison.OrdinalIgnoreCase) 
            || p.Surname.Equals(nameOrLastName, StringComparison.OrdinalIgnoreCase) )!;
            

            return person;
        }

        private Person? FindPersonByPhoneNumber(string phoneNumber) 
        {
            Person person = Persons.FirstOrDefault
            (p => p.PhoneNumber.Equals(phoneNumber) )!;
            

            return person;
        }








    }

}


