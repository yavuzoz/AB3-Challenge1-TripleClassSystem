using Backend.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Kurs> Kurse { get; set; }
        public DbSet<Dozent> Dozenten { get; set; }
        public DbSet<Studierende> Studierende { get; set; }

        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // OnModelCreating metod override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity configurations
            modelBuilder.Entity<Kurs>()
                .HasKey(k => k.ID);  // ID property is primary key

            modelBuilder.Entity<Dozent>()
                .HasKey(d => d.ID);

            modelBuilder.Entity<Studierende>()
                .HasKey(s => s.ID);

            // releshionship konfigürasyonları
            modelBuilder.Entity<Kurs>()
                .HasOne<Dozent>()  // each course has one instructor
                .WithMany()       // each instructor can have many courses
                .HasForeignKey(k => k.DozentID);

            modelBuilder.Entity<Studierende>()
                .HasOne<Kurs>()   // each student can take one course
                .WithMany()       // one course can have many students
                .HasForeignKey(s => s.KursID);
        }
    }
}
