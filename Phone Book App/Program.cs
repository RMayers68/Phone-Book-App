using ConsoleTableExt;

namespace Phone_Book_App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool closeProgram = false;
            string[] menu = { "Phone Book", "1: Add a Phone #", "2: Delete a Phone #", "3: Update an existing Phone #", "4: Delete a Phone #" };
            List<string> menuList = new(menu);
            while (!closeProgram)
            {               
                Console.Clear();
                ConsoleTableBuilder.From(menuList).ExportAndWriteLine(TableAligntment.Center);
                Console.ReadKey();
            }   
        }
    }

}

