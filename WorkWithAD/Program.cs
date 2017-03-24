using System;

namespace WorkWithAD
{
    class Program
    {
        static void Main(string[] args)
        {
            AD ad = new AD();
            bool isEntry = ad.searchUser("arhon");
            if (isEntry)
                Console.WriteLine("Is entry");
            Console.Read();
        }
    }
}
