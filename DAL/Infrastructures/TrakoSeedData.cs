using Entities.Authentications;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Infrastructures
{
    //internal class TrakoSeedData : IDatabaseInitializer<TrakoDbContext>
    internal class TrakoSeedData : DropCreateDatabaseIfModelChanges<TrakoDbContext>
    {
        protected override void Seed(TrakoDbContext context)
        {
            #region Authentication
            //AddADLoginSeed(context);
            UserSeed(context);
            #endregion

            base.Seed(context);
        }

        private void AddADLoginSeed(TrakoDbContext context)
        {
            var adLoginList = new List<ADLogin>
            {
                new ADLogin{CorporateId=1,IsActive=true},
            };

            adLoginList.ForEach(s => context.ADLogins.Add(s));
            context.SaveChanges();
        }

        private void UserSeed(TrakoDbContext context)
        {
            var list = new List<User>
            {
                new User{DisplayName="Ahsan",Email="test@trakomatic.com"},
            };

            list.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}