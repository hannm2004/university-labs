namespace Lab05.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBContentStudent")
        {
        }

        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<StudentMajor> StudentMajor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.Major)
                .WithMany()
                .HasForeignKey(s => s.MajorID);

            modelBuilder.Entity<Student>()
                .HasOptional(s => s.Faculty)
                .WithMany(f => f.Student)
                .HasForeignKey(s => s.FacultyID);

            modelBuilder.Entity<Major>()
                .HasOptional(m => m.Faculty)
                .WithMany()
                .HasForeignKey(m => m.FacultyID);

            modelBuilder.Entity<StudentMajor>()
                .HasOptional(sm => sm.Student)
                .WithMany(s => s.StudentMajor)
                .HasForeignKey(sm => sm.StudentID);

            modelBuilder.Entity<StudentMajor>()
                .HasOptional(sm => sm.Major)
                .WithMany(m => m.StudentMajor)
                .HasForeignKey(sm => sm.MajorID);
        }
    }
}
