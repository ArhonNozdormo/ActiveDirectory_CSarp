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
            bool isEntry = ad.searchUser("arhon");
            if (isEntry)
                Console.WriteLine("Is entry");
            Console.Read();
        }
    }
    //ActiveDirectory
    class AD
    {
        string currentDomain;
        string username;
        string password;
        ContextType type;

        // Для работы с Active Directory
        public AD(string user, string pass, string domain)
        {
            this.currentDomain = domain;
            this.type = ContextType.Domain;
            this.username = user;
            this.password = pass;
        }

        // Для работы с local users
        public AD()
        {
            this.currentDomain = Environment.MachineName;
            this.type = ContextType.Machine;
            this.username = null;
            this.password = null;
        }
        //поиск пользователя в домене AD
        public bool searchUser(string ADUsername)
        {
            try
            {
                using (PrincipalContext contex = new PrincipalContext(
                    this.type,
                    this.currentDomain,
                    this.username,
                    this.password)
                    )
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(
                        contex, 
                        IdentityType.SamAccountName, 
                        ADUsername
                        );
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
        }
    }
}
