using Microsoft.EntityFrameworkCore;

namespace Api_Passport_and_Visa_Service.Model;

public class VisaDbContext : DbContext
{
    public DbSet<Post_List> postList { get; set; }
    public DbSet<Employee> employees { get; set; }
    public DbSet<Registration> registration { get; set; }
    public DbSet<PassportData> passportData { get; set; }
    public DbSet<Client> client { get; set; }
    public DbSet<RecordAppointment> recordAppointment { get; set; }
    public DbSet<PaymentInvoice> paymentInvoice { get; set; }
    public DbSet<RequestOnIntPassport> requestOnIntPassport { get; set; }
    public DbSet<Status> status { get; set; }
    public DbSet<DepartureCountry> departureCountry { get; set; }
    public DbSet<RequestOnVisa> requestOnVisa { get; set; }
    public DbSet<Visa> visa { get; set; }
    public DbSet<InternationalPassport> internationalPassport { get; set; }

    public VisaDbContext()
    {
        
    }

    public VisaDbContext(DbContextOptions<VisaDbContext> options)
        : base(options)
    {
        
    }
}