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
            try
            {
                DirectoryEntry CurrentDomain = new DirectoryEntry();
                Console.WriteLine(CurrentDomain.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
    //ActiveDirectory
    class AD
    {
        DirectoryEntry CurrentDomain;
        DirectoryEntries Tree;
        IEnumerator Reed;

        public AD(string path, string username, string password)
        {
            this.CurrentDomain = new DirectoryEntry(path, username, password);
            this.Tree = CurrentDomain.Children;
            this.Reed = Tree.GetEnumerator();
        }
        public AD()
        {
            this.CurrentDomain = new DirectoryEntry();
            this.Tree = CurrentDomain.Children;
            this.Reed = Tree.GetEnumerator();
        }
    }
}
