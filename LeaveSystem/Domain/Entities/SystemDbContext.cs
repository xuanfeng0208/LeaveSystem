using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LeaveSystem.Domain.Entities
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleFunction> RoleFunctions { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Calendar> Calendars { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(x => x.ID).IsClustered(false);
                builder.HasIndex(x => x.SequenceNo).IsClustered();
                builder.Property(x => x.SequenceNo).UseIdentityColumn().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<UserRole>(builder =>
            {
                builder.HasKey(x => x.ID).IsClustered(false);
                builder.HasIndex(x => x.SequenceNo).IsClustered();
                builder.Property(x => x.SequenceNo).UseIdentityColumn().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<Role>(builder =>
            {
                builder.HasKey(x => x.ID).IsClustered(false);
                builder.HasIndex(x => x.SequenceNo).IsClustered();
                builder.Property(x => x.SequenceNo).UseIdentityColumn().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<RoleFunction>(builder =>
            {
                builder.HasKey(x => x.ID).IsClustered(false);
                builder.HasIndex(x => x.SequenceNo).IsClustered();
                builder.Property(x => x.SequenceNo).UseIdentityColumn().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<Function>(builder =>
            {
                builder.HasKey(x => x.ID).IsClustered(false);
                builder.HasIndex(x => x.SequenceNo).IsClustered();
                builder.Property(x => x.SequenceNo).UseIdentityColumn().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<Department>(builder =>
            {
                builder.HasKey(x => x.ID).IsClustered(false);
                builder.HasIndex(x => x.SequenceNo).IsClustered();
                builder.Property(x => x.SequenceNo).UseIdentityColumn().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<Calendar>(builder =>
            {
                builder.HasKey(x => x.ID).IsClustered(false);
                builder.HasIndex(x => x.SequenceNo).IsClustered();
                builder.Property(x => x.SequenceNo).UseIdentityColumn().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });
        }
    } 
}