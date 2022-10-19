using ConsoleTableExt;

namespace Phone_Book_App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool closeProgram = false;
            string[] menu = { "Phone Book", "1: Add a Phone #", "2: Delete a Phone #", "3: Update an existing Phone #", "4: View your Contacts","0: Exit" };
            List<string> menuList = new(menu);
            int menuChoice = 0;
            using var db = new ContactContext();
            string name, number;
            while (!closeProgram)
            {               
                Console.Clear();
                ConsoleTableBuilder.From(menuList).ExportAndWriteLine(TableAligntment.Center);
                menuChoice = DataValidation.CountCheck(4, 0);
                Console.Clear();
                switch(menuChoice)
                {
                    default:                            // Exit Program
                        closeProgram = true;
                        break;
                    case 1:                             // Create
                        Console.WriteLine("What is the name of the person/organization?");
                        name = DataValidation.EmptyStringCheck();
                        Console.WriteLine("And what is their phone number?");
                        number = DataValidation.EmptyStringCheck();
                        db.Add(new Contact (name,number));
                        db.SaveChanges();
                        break;
                    case 2:                             // Delete
                        break;
                    case 3:                             //Update
                        break;
                    case 4:                             //View
                        var query = from b in db.Contacts
                                    orderby b.Id
                                    select b;
                        foreach(var item in query)
                            Console.WriteLine($"{item.Name}: {item.PhoneNumber}");
                        Console.ReadKey();
                        break;      
                }
            }   
        }
    }
}

