namespace Phone_Book_App
{
    public class DataValidation
    {
        public static int CountCheck(int count, int menuOrList)
        {
            int a;
            while (!Int32.TryParse(Console.ReadLine(), out a) || a < menuOrList || a > count)
                Console.WriteLine("Invalid input, enter again:");
            return a;
        }

        public static string EmptyStringCheck()
        {
            string a = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(a))
            {
                Console.WriteLine("Invalid input, enter again:");
                a = Console.ReadLine();
            }
            return a;
        }
    }
}
