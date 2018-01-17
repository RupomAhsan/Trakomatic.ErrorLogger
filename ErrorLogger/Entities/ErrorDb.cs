namespace ErrorLogger.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public partial class ErrorLoggerEntities : DbContext
    {
        public ErrorLoggerEntities()
            : base("name=ErrorLoggerEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Error> Errors { get; set; }
    }

    public class Error
    {
        public int Id { get; set; }
        public string LoggingLevel { get; set; }
        public string ErrorType { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> DateTimeUTC { get; set; }
    }

    public class AuditLog
    {
        public int Id { get; set; }
        public int CorporateId { get; set; }
        public int DeviceId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> LastActiveDateTime { get; set; }
        public Nullable<System.DateTime> LoggingDateTime { get; set; }
        public int LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
    }
}