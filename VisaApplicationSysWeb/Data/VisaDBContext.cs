using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VisaApplicationSysWeb.Models;

namespace VisaApplicationSysWeb.Data
{
    public class VisaDBContext : DbContext
    {
        public VisaDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> tblUser { get; set; }

        public DbSet<VisaType> tblVisaType { get; set; }

        public DbSet<StudentVisaForm> tblStudentVisaForm { get; set; }

        public DbSet<EmploymentVisaForm> tblEmploymentVisaForm { get; set; }

        public DbSet<TouristVisaForm> tblTouristVisaForm { get; set; }

        public DbSet<BusinessVisaForm> tblBusinessVisaForm { get; set; }

        public DbSet<VisaStatusModel> tblVisaStatus { get; set; }

        public DbSet<Applicant> tblApplicant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmploymentVisaForm>()
                .Property(e => e.MonthlySalary)
                .HasColumnType("decimal(18, 2)"); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=ABHI;Database=VisaApplicationDB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=true",
                options => options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null));
        }

    }
}
