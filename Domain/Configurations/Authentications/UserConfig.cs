using Entities.Authentications;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations.Authentications
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("user");
            //Property(p => p.CorporateId).IsOptional();

            HasOptional(m => m.Corporate)
                       .WithMany(t => t.UserCorporate)
                       .HasForeignKey(m => m.CorporateId)
                       .WillCascadeOnDelete(false);
        }
    }
}
