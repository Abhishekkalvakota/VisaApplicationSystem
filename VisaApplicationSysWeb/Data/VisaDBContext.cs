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

        public DbSet<ApplicantProfile> tblProfile { get; set; }

        public DbSet<VisaType> tblVisaType { get; set; }

    }
}
