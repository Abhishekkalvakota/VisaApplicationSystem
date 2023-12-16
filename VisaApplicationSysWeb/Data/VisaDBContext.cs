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


        public DbSet<ApplicantProfile> tblprofile { get; set; }
     

        public DbSet<StudentVisaForm> tblStudentVisaForm { get; set; }

        public DbSet<EmploymentVisaForm> tblEmploymentVisaForm { get; set; }

        public DbSet<TouristVisaForm> tblTouristVisaForm { get; set; }

        public DbSet<BusinessVisaForm> tblBusinessVisaForm { get; set; }

        public DbSet<VisaStatusModel> tblVisaStatus{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add configurations for VisaStatusModel
            modelBuilder.Entity<VisaStatusModel>().HasNoKey();

            // Add configurations for ApplicantProfile
            modelBuilder.Entity<ApplicantProfile>()
                .Property(ap => ap.MonthlySalary)
                .HasColumnType("decimal(18,2)");

            // Add configurations for EmploymentVisaForm
            modelBuilder.Entity<EmploymentVisaForm>()
                .Property(evf => evf.MonthlySalary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<VisaStatusModel>().HasKey(x => x.ApplicantId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=ABHI;Database=VisaUAEDB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=true",
                options => options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null));
        }

    }
}
