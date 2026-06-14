using Clean.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Students> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.Category)
                .WithMany(ca => ca.Courses)
                .HasForeignKey(c => c.categoryId);

            modelBuilder.Entity<Courses>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.instructorId);

            modelBuilder.Entity<Students>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.courseId);

            modelBuilder.Entity<Categories>().HasData(
                new Categories { id = 1, name = "קורס 4 שעות", description = "קטגוריה לקורס עזרה ראשונה בהיקף 4 שעות" },
                new Categories { id = 2, name = "קורס 8 שעות", description = "קטגוריה לקורס עזרה ראשונה בהיקף 8 שעות" },
                new Categories { id = 3, name = "קורס 22 שעות", description = "קטגוריה לקורס עזרה ראשונה בהיקף 22 שעות" },
                new Categories { id = 4, name = "קורס 30 שעות", description = "קטגוריה לקורס עזרה ראשונה בהיקף 30 שעות" },
                new Categories { id = 5, name = "קורס 48 שעות", description = "קטגוריה לקורס עזרה ראשונה בהיקף 48 שעות" },
                new Categories { id = 6, name = "הדרכת דפיברילטור", description = "קטגוריה להדרכת שימוש בדפיברילטור" }
            );
        }
    }
}
