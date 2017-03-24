using System;
using System.DirectoryServices.AccountManagement;

namespace WorkWithAD
{
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
            catch (Exception e)
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
