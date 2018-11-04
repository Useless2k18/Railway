using System.Data.Entity;

namespace BusinessLogicWPF
{
    class IrctcAppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public IrctcAppDbContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
