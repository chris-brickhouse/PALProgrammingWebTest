
/*
 * first, copy all files. then, change namespsace to the web by mass search and replace.
install-package Microsoft.EntityFrameworkCore
install-package Microsoft.EntityFrameworkCore.SqlServer
install-package Microsoft.Extensions.Configuration
install-package Microsoft.Extensions.Configuration.FileExtensions
install-package Microsoft.Extensions.Configuration.Json
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using PALProgrammingWebTest.Models;

using System;

// create models class second
namespace PALProgrammingWebTest {

    // explain what dbcontext class is
    public class PALModels : DbContext {

        // these are our lists
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAttendance> UsersAttendance { get; set; }
        public virtual DbSet<UsersGrades> UsersGrades { get; set; }

        // explain this function
        public static string GetConnectionString() {
            string applicationExeDirectory = Environment.CurrentDirectory;
            var builder = new ConfigurationBuilder()
            .SetBasePath(applicationExeDirectory)
            .AddJsonFile("appsettings.json");
            var appSettingsJson = builder.Build();
            return appSettingsJson["ConnectionStrings:Students"];
        }      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }
}
