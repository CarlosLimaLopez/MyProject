using Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Context
{
    public class DevicesContext : DbContext
    {
        public DevicesContext(DbContextOptions<DevicesContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Counter> Counters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
            .HasOne(a => a.Counters)
            .WithOne(a => a.Devices)
            .HasForeignKey<Counter>(c => c.c_serial);

            modelBuilder.Entity<Device>()
            .HasOne(a => a.Gateways)
            .WithOne(a => a.Devices)
            .HasForeignKey<Gateway>(c => c.g_serial);

            modelBuilder.Entity<Device>().ToTable("Devices");
            //modelBuilder.Entity<Device>().Ignore(s => s.d_id);
            modelBuilder.Entity<Gateway>().ToTable("Gateways");
            //modelBuilder.Entity<Gateway>().Ignore(s => s.g_id);
            modelBuilder.Entity<Counter>().ToTable("Counters");
            //modelBuilder.Entity<Counter>().Ignore(s => s.c_id);
        }
    }
}