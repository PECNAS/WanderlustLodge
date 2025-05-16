using Microsoft.EntityFrameworkCore;
using WpfApp1.Base.Entities;

namespace WebApplication1.Models
{
    public class DatabaseContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Visitor> Visitors { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Reserve> Reserves { get; set; }
		public DbSet<Review> Reviews { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/*modelBuilder.Entity<Reserve>()
				.HasOne(r => r.Visitor)
				.WithMany(v => v.Reserves);

			modelBuilder.Entity<Reserve>()
				.HasOne(r => r.Room)
				.WithOne(r => r.Reserve);*/


			base.OnModelCreating(modelBuilder);
		}
	}
}
