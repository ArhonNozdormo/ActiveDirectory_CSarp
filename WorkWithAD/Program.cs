using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.Collections;

namespace WorkWithAD
{
    class Program
    {
        static void Main(string[] args)
        {
            AD ad = new AD();
            var result = ad.searchUser("admin");
            if(result == null)
            {
                Console.WriteLine("Result is null");
            }
            else
            {
                Console.WriteLine(result.ToString());
            }
            Console.Read();
        }
    }
    //ActiveDirectory
    class AD
    {
        
        DirectoryEntry CurrentDomain;
        //DirectoryEntries Trees;
        //IEnumerator Reed;

        public AD(string path, string username, string password)
        {
            this.CurrentDomain = new DirectoryEntry(path, username, password);
        }
        public AD()
        {
            this.CurrentDomain = new DirectoryEntry();
        }
        public object searchUser (string ADUsername, string ADGroup = "SAMAccountName")
        {
            try
            {
                SearchResult result;
                using (DirectorySearcher searcher = new DirectorySearcher(CurrentDomain))
                {
                    searcher.Filter = String.Format("({0}={1})", ADGroup, ADUsername);
                    searcher.PropertiesToLoad.Add("cn");
                    result = searcher.FindOne();
                }
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        ~AD()
        {
            Console.WriteLine("Destroy CurrentDomain");
            CurrentDomain.Close();
        }
    }
}
