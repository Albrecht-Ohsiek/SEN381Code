using CallCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace CarrierPidgeon
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<Call> Calls { get; set; } = null!;
        public DbSet<CallReport> CallReports { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Login> Logins { get; set; } = null!;
        public DbSet<RequestLog> RequestLogs { get; set; } = null!;
        public DbSet<Technician> Technicians { get; set; } = null!;
        public DbSet<Work> Work { get; set; } = null!;
        public DbSet<WorkRequest> WorkRequests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Call>()
                .HasKey(t => t.callId);

            modelBuilder.Entity<CallReport>()
                .HasKey(t => t.callReportId);

            modelBuilder.Entity<Client>()
                .HasKey(t => t.clientId);

            modelBuilder.Entity<Contract>()
                .HasKey(t => t.contractId);

            modelBuilder.Entity<Employee>()
                .HasKey(t => t.employeeId);

            modelBuilder.Entity<Login>()
                .HasKey(t => t.EmployeeId);

            modelBuilder.Entity<RequestLog>()
                .HasKey(t => t.requestId);

            modelBuilder.Entity<Technician>()
                .HasKey(t => t.technicianId);

            modelBuilder.Entity<Work>()
                .HasKey(t => t.workId);

            modelBuilder.Entity<WorkRequest>()
                .HasKey(t => t.requestId);
        }
    }
}