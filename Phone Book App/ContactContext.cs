using Microsoft.EntityFrameworkCore;

namespace Phone_Book_App
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public string DbPath = $"server=localhost;Database=Phonebook;Trusted_Connection=True;";

        // The following configures EF to create a Sql Server database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(DbPath);
        }
    }
}
