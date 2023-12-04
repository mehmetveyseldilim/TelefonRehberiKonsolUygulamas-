
namespace TelefonRehberiKonsolUygulaması
{
    // Kisi
    public class Person 
    {

        public  required string Name { get; set; }
        public  required string Surname { get; set; }
        public  required string PhoneNumber { get; set; }

        public override string ToString() 
        {
            return $"Name: {Name}, Surname: {Surname}, Phone Number: {PhoneNumber}";
        }

    }
}


