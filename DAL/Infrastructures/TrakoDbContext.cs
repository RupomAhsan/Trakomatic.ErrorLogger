using Configurations.Authentications;
using Domain.Entities.Utility;
using Entities.Authentications;
using Entities.Corporates;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures
{
    public class TrakoDbContext: DbContext
    {
        public TrakoDbContext():base("TrakoDbContext")
        {
                
        }
        static TrakoDbContext()
        {
            Database.SetInitializer<TrakoDbContext>(new TrakoSeedData());
        }

        public static TrakoDbContext Create()
        {
            return new TrakoDbContext();
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public string Connectionstring()
        {
           return Database.Connection.ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Add Table Configurations
            modelBuilder.Configurations.Add(new ADLoginConfig());

        }
        #region DB Sets
        //Authentications
        public DbSet<ADLogin> ADLogins { get; set; }
        public DbSet<GooglePlus> GooglePluses { get; set; }
        public DbSet<Logins> Logins { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAction> UserActions { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupMap> UserGroupMaps { get; set; }
        public DbSet<UserRights> UserRights { get; set; }

        //Corporates
        public DbSet<AlertType> AlertTypes { get; set; }
        public DbSet<AlertTypeMap> AlertTypeMaps { get; set; }
        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<DeviceTypeSetup> DeviceTypeSetups { get; set; }
        public DbSet<FTPSetup> FTPSetups { get; set; }
        public DbSet<InstallDevice> InstallDevices { get; set; }
        public DbSet<OcrowdSetup> OcrowdSetups { get; set; }
        public DbSet<OsenseSetup> OsenseSetups { get; set; }
        public DbSet<OtrackSetup> OtrackSetups { get; set; }
        public DbSet<QueueSetup> QueueSetups { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SetupZoneDevices> SetupZoneDevices { get; set; }
        public DbSet<SupportEmails> SupportEmails { get; set; }
        public DbSet<SupportSMS> SupportSMSs { get; set; }
        public DbSet<ZoneSetup> ZoneSetups { get; set; }

        //Utility
        public DbSet<Notification> Notification { get; set; }
        #endregion
    }
}
