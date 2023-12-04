using System;

namespace TelefonRehberiKonsolUygulaması
{
    public class Program
    {
        private static void WriteMenuOperationsToConsole() 
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
            Console.WriteLine("     (1) Yeni Numara Kaydetmek");
            Console.WriteLine("     (2) Varolan Numarayi Silmek");
            Console.WriteLine("     (3) Varolan Numarayi Güncelleme");
            Console.WriteLine("     (4) Rehberi Listelemek");
            Console.WriteLine("     (5) Rehberde Arama Yapmak");
        }

        private static char GetSingleInputFromUser() 
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
        
            // Console.WriteLine("\nYou pressed: " + keyInfo.KeyChar);

            return keyInfo.KeyChar;
        }

        private static string GetStringInputFromUser() 
        {
            string input = Console.ReadLine()!;

            return input!;
        }

        private static void SearchInPhone(Phone phone) 
        {
            Console.WriteLine("Rehberde arama  yapma işlemini seçtiniz.");
            var input = GetStringInputFromUser();

            var persons = phone.FindPersonsViaNameOrSurname(input);

            Console.WriteLine("Arama sonuçlariniz:");

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }

        }

        private static void AddNewPhoneNumber(Phone phone) 
        {
            Console.WriteLine("Yeni numara ekleme işlemini seçtiniz.");

            Console.WriteLine("Lütfen isim giriniz:");
            string name = GetStringInputFromUser();
            Console.WriteLine("Lütfen soy isim giriniz:");
            string surname = GetStringInputFromUser();
            Console.WriteLine("Lütfen telefon numarasi giriniz:");
            string phoneNumber = GetStringInputFromUser();

            Person newPerson = new Person()
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber
            };

            phone.SavePerson(newPerson);
            Console.WriteLine("Kaydetme işlemi başarili. Kaydedilen kişi:");
            Console.WriteLine(newPerson.ToString());
            Console.WriteLine();

        }
        
        private static void DeleteFromPhone(Phone phone) 
        {
            Console.WriteLine("Silme işlemini seçtiniz.");
            
            while(true) 
            {
                Console.WriteLine("Lütfen numarasini silmek istediğiniz kişinin adini ya da soyadini giriniz:");

                var input = GetStringInputFromUser();
                var person = phone.FindPersonByNameOrLastName(input);

                if(person == null) 
                {
                    Console.WriteLine("Aradiğiniz krtiterlere uygun veri rehberde bulunamadi. Lütfen bir seçim yapiniz.");
                    Console.WriteLine("* Silmeyi sonlandirmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");

                    var userInput = GetSingleInputFromUser();

                    switch(userInput) 
                    {
                        case '1':
                            Console.WriteLine("Ana menüye dönülüyor...");
                            break;
                        
                        default:
                            continue;

                    }

                    break;
                }
                else
                {
                    Console.WriteLine($"{person.ToString()} isimli kişi rehberden silinmek üzere, onayliyor musunuz ?(y/n)");
                    var userInput = GetSingleInputFromUser();

                    switch(userInput) 
                    {
                        case 'y':
                            phone.DeletePerson(input);
                            Console.WriteLine("Silme işlemi gerçekleştirildi");
                            break;
                        
                        default:
                            break;

                    }

                    break;
                }

            }

        }

        private static void EditPerson(Phone phone) 
        {
            Console.WriteLine("Lütfen numarasini güncellemek istediğiniz kişinin adini ya da soyadini giriniz:");
            var input = GetStringInputFromUser();
            var person = phone.FindPersonByNameOrLastName(input);

            if(person == null) 
            {
                Console.WriteLine("Böyle bir kişi bulunamadi.");
                return;
            }

            Console.WriteLine("Yeni numarayi giriniz.");
            input = GetStringInputFromUser();


            Console.WriteLine($"{person.ToString()} kişisinin numarasi değiştirildi.");
            phone.EditPerson(person, input);
            Console.WriteLine($"Yeni numara: {person.PhoneNumber}");



        }


        public static void Main(string[] args)
        {
            var phoneUser = new Person() 
            {
                Name = "Ad",
                Surname = "Soyad",
                PhoneNumber = "553"
            };

            var phone = new Phone(phoneUser);

            phone.Persons = new List<Person>() 
            {
                // Create 5 users and add them to the list
                new Person { Name = "John", Surname = "Doe", PhoneNumber = "5551234567" },
                new Person { Name = "Jane", Surname = "Smith", PhoneNumber = "5559876543" },
                new Person { Name = "Mike", Surname = "Johnson", PhoneNumber = "5557890123" },
                new Person { Name = "Emily", Surname = "Williams", PhoneNumber = "5553456789" },
                new Person { Name = "David", Surname = "Brown", PhoneNumber = "5552345678" }
            };


            Console.WriteLine(phoneUser.ToString());

     
            while(true) 
            {
                WriteMenuOperationsToConsole();
                
                var keyInfo = GetSingleInputFromUser();
                
                switch (keyInfo)
                {
                    case '1':
                        AddNewPhoneNumber(phone);
                        break;
                    case '2':
                        DeleteFromPhone(phone);
                        break;

                    case '3':
                        EditPerson(phone);
                        break;
                    case '4':
                        Console.WriteLine("You pressed '4'");
                        Console.WriteLine("Rehberdeki bütün numaralar listeleniyor...");
                        Console.WriteLine(phone.ToString());
                        break;
                    case '5':
                        SearchInPhone(phone);
                        break;
                    default:
                        Console.WriteLine("Invalid key. Please press '1', '2', '3', '4', or '5'.");
                        break;
                }

                Console.WriteLine();

            }
        }
    }
}


