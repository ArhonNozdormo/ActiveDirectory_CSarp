using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Collections;

namespace WorkWithAD
{
    class Program
    {
        static void Main(string[] args)
        {
            AD ad = new AD();
            var vs = ad.searchUser("arhon");
            if(vs)
            {
                Console.WriteLine("User is found");
            }
            using (PrincipalContext ctx = new PrincipalContext(ContextType.Machine))
            {
                string username = "ARHON2";
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username);
                if (user == null)
                {
                    Console.WriteLine("User {0} not found", username);
                }
                else
                {
                    Console.WriteLine("User {0} has found", user.Name);
                }
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
        public bool searchUser(string ADUsername, string ADGroup = "SAMAccountName")
        {
            try
            {
                using (PrincipalContext contex = new PrincipalContext(ContextType.Domain))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(contex, ADUsername);
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        ~AD()
        {
            Console.WriteLine("Destroy CurrentDomain");
            CurrentDomain.Close();
        }
    }
}
