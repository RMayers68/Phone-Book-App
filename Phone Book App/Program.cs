using ConsoleTableExt;

namespace Phone_Book_App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool closeProgram = false;
            string[] menu = { "Phone Book", "1: Add a Phone #", "2: Delete a Phone #", "3: Update an existing Phone #", "4: View your Contacts", "0: Exit" };
            List<string> menuList = new(menu);
            int menuChoice = 0;
            using var db = new ContactContext();
            string name, number;
            while (!closeProgram)
            {
                bool validID = false;
                Console.Clear();
                ConsoleTableBuilder.From(menuList).ExportAndWriteLine(TableAligntment.Center);
                menuChoice = DataValidation.CountCheck(4, 0);
                Console.Clear();
                switch (menuChoice)
                {
                    default:                            // Exit Program
                        closeProgram = true;
                        break;
                    case 1:                             // Create
                        Console.WriteLine("What is the name of the person/organization?");
                        name = DataValidation.EmptyStringCheck();
                        Console.WriteLine("And what is their phone number?");
                        number = DataValidation.EmptyStringCheck();
                        db.Add(new Contact(name, number));
                        db.SaveChanges();
                        break;
                    case 2:                             // Delete
                        List<Contact> deleteList = View(db);
                        if (deleteList.Count < 1) break;
                        Console.WriteLine("Please enter the ID of the entry you would like to delete:");
                        Contact deleteContact = DataValidation.IDVerification(deleteList);
                        db.Remove(deleteContact);
                        db.SaveChanges();
                        break;
                    case 3:                             //Update
                        List<Contact> updateList = View(db);
                        if (updateList.Count < 1) break;
                        Console.WriteLine("Please enter the ID of the entry you would like to update:");
                        Contact updateContact = DataValidation.IDVerification(updateList);
                        Console.WriteLine("What is the name of the person/organization?");
                        updateContact.Name = DataValidation.EmptyStringCheck();
                        Console.WriteLine("And what is their phone number?");
                        updateContact.PhoneNumber = DataValidation.EmptyStringCheck();
                        db.Update(updateContact);
                        db.SaveChanges();
                        break;
                    case 4:                             //View
                        View(db);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // View DB EF method
        public static List<Contact> View(ContactContext db)
        {
            var query = from b in db.Contacts
                        orderby b.Id
                        select b;
            List<Contact> list = new();
            foreach (var item in query)
                list.Add(item);
            ConsoleTableBuilder.From(list).ExportAndWriteLine(TableAligntment.Center);
            return list;
        }
    }
}

