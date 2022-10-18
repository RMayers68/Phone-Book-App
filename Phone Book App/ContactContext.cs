using Microsoft.EntityFrameworkCore;


namespace Phone_Book_App
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public string DbPath { get; }

        public ContactContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        // The following configures EF to create a Sql Server database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($"Data Source={DbPath}");
        }
    }
}
