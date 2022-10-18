using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Specialized;
using System.Web;
using System.Xml.Linq;


namespace Phone_Book_App
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        // The following configures EF to create a Sql Server database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($"server=localhost;Database=Phonebook;Trusted_Connection=True;");
        }
    }
}
