using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_12_EF02.Model
{
    internal class AppDbContext : DbContext 
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= . ; Database = EventHubDB ; Trusted_Connection=True;" +
                "TrustServerCertificate=True; ");
        }

        //=========================================================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table Attendee
            modelBuilder.Entity<Attendee>(entity =>
            {
                entity.HasKey(A => A.AttendeeID);
                entity.Property(A => A.FullName).HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(true);

                entity.HasIndex(A => A.Email).IsUnique();

                entity.OwnsOne(A => A.Address, address =>
                {
                    address.Property(a => a.City).IsRequired();
                });

              });
            #endregion

            #region Table Event 
            modelBuilder.ApplyConfiguration<Event>(new EventConfiguration());
                #endregion

                #region Table Profile 
                modelBuilder.Entity<Profile>(en =>
                {
                    en.HasKey(p => p.ProfileID);
                    en.Property(p => p.Bio)
                    .HasMaxLength(200);

                    en.Property(p => p.WebsiteURL).IsRequired();


                });

                #endregion

                #region Table Session

                modelBuilder.Entity<Session>(ent =>
               {
                   ent.HasKey(s => s.SessionID);
                   ent.Property(s => s.Title).HasMaxLength(100).IsRequired();
                   ent.Property(s => s.StartTime).HasDefaultValueSql("GETDATE()");
               });

                #endregion

                #region Table Badge
                modelBuilder.Entity<Badge>(entity =>
                {
                    entity.HasKey(b => b.BadgeID);
                    entity.Property(b => b.BadgeNumber).IsRequired();
                });

                #endregion

                #region Registration
                modelBuilder.Entity<Registration>(entity =>
                {
                    entity.HasKey(R => R.RegistrationID);
                    entity.Property(R => R.Notes).HasMaxLength(100);
                    entity.Property(R => R.RegistrationDate).HasDefaultValueSql("GETDATE()");

                });
           
                #endregion


            }

        #region Class To Table 

        public DbSet <Organizer>    organizers{ get; set; }
        public DbSet  <Attendee>    Attendees{ get; set; }
        public DbSet  <Event>       Events{ get; set; }
        public DbSet  <Profile>     Profiles{ get; set; }
        public DbSet  <Session>     Sessions{ get; set; }
        public DbSet  <Badge>       Badges { get; set; }
        public DbSet <Registration> Registrations{ get; set; }
        #endregion
    }
}
