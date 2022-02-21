using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPanelApi.Services;
using AdminPanelApi.EntityConfiguration;

namespace AdminPanelApi.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //public DbSet<Name> Name { get; set; }

        }
        public DbSet<Benefit> Benefit { get; set; }

        public DbSet<Branch> Branch { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<Member> Member { get; set; }

        public DbSet<Number> Number { get; set; }

        public DbSet<Section> Section { get; set; }
        public DbSet<SectionImages> SectionImages { get; set; }

        public DbSet<Step> Step { get; set; }
        public DbSet<Text> Text { get; set; }
        public DbSet<Inventor> Inventors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BenefitsConfiguration());
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new ContactUsConfiguration());
            modelBuilder.ApplyConfiguration(new MemeberConfiguration());
            modelBuilder.ApplyConfiguration(new NumberConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new SectionImagesConfiguration());
            modelBuilder.ApplyConfiguration(new StepsConfiguration());
            modelBuilder.ApplyConfiguration(new TextConfiguration());
            modelBuilder.ApplyConfiguration(new InventorConfiguration());
        
            SeedRoles(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ProductControlConfigurations());

        }

        private void SeedRoles(ModelBuilder builder)
        {


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = Services.UserRoles.Admin, ConcurrencyStamp = "2", NormalizedName = Services.UserRoles.Admin },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = Services.UserRoles.SuperAdmin, ConcurrencyStamp = "3", NormalizedName = Services.UserRoles.SuperAdmin },
                new IdentityRole() { Id = "0E50AF81-221B-43A5-9DA0-B0F2CF5A7DD2", Name = Services.UserRoles.User, ConcurrencyStamp = "4", NormalizedName = Services.UserRoles.User }
            );
          builder.Entity<Step>().HasData(
    new Step() { Id =1,Title= "Create a form" ,TitleEn= "Create a form" ,Description= "Use the 99Inbound form builder to easily create a great looking form." ,DescriptionEn= "Use the 99Inbound form builder to easily create a great looking form." },
    new Step() { Id =2, Title = "Link Zendesk Sell", TitleEn = "Link Zendesk Sell", Description = "Use the 99Inbound form builder to easily create a great looking form.", DescriptionEn = "Use the 99Inbound form builder to easily create a great looking form." },
    new Step() { Id = 3, Title = "Publish your form", TitleEn = "Publish your form", Description = "Use the 99Inbound form builder to easily create a great looking form.", DescriptionEn = "Use the 99Inbound form builder to easily create a great looking form." }
);
            builder.Entity<Section>().HasData(new Section()
            { Id = 1, SectionName = "Home", Index=1 }, new Section()
            { Id = 2, SectionName = "Home", Index = 2 }
                , new Section() { Id = 3, SectionName = "Home", Index = 3 }
                 , new Section() { Id = 4, SectionName = "Home", Index = 4 }
                , new Section() { Id =5, SectionName = "aboutus", Index =1 }
                , new Section() { Id =6, SectionName = "aboutus", Index = 2}
               , new Section() { Id = 7, SectionName = "footer", Index = 1 }
                );
            builder.Entity<SectionImages>().HasData(new SectionImages() { SectionId = 1, ImagePath= ""});

          builder.Entity<Text>().HasData(
                new Text() { Id = 1, Content = "Build a", ContentEn = "Build a", Title = "Title Text ", TitleEn = "Title Text ", SectionId = 1 },
new Text() { Id = 2, Content = "are slanted", ContentEn= "are slanted", Title="Animated Text ", TitleEn = "Animated Text ", SectionId =1 },
new Text() { Id = 3, Content = "Some strings are bold", ContentEn = "Some strings are bold", Title = "Animated Text ", TitleEn = "Animated Text ", SectionId = 1 },
new Text() { Id = 4, Content = "HTML characters &times; &copy;", ContentEn = "HTML characters &times; &copy;", Title = "Animated Text ", TitleEn = "Animated Text ", SectionId = 1 },
new Text() { Id = 5, Content = "in minutes", ContentEn = "in minutes", Title = "Title Text ", TitleEn = "Title Text ", SectionId = 1 },
new Text() { Id = 6, Content = "Build forms and share them online. Get an email or Slack message for each submission.", ContentEn = "Build forms and share them online. Get an email or Slack message for each submission.", Title = "description Text ", TitleEn = "description Text ", SectionId = 1 },
new Text() { Id = 7, Content = "Get started free", ContentEn = "Get started free", Title = "button  Text ", TitleEn = "Title Text ", SectionId = 1 },
new Text() { Id = 8, Content = "How it works", ContentEn = "How it works", Title = "Title Text ", TitleEn = "Title Text ", SectionId =2 },
new Text() { Id = 9, Content = "", ContentEn = "", Title = "description Text ", TitleEn = "Title Text ", SectionId = 2},
new Text() { Id = 10, Content = "Zendesk Sell lead capture automation", ContentEn = "Zendesk Sell lead capture automation", Title = "Title Text ", TitleEn = "Title Text ", SectionId = 3 },
new Text() { Id = 11, Content = "Our forms do a lot of heavy lifting so you don't have to.Create LeadsNew submissions create a lead and add a note with all the form values.", ContentEn = "Our forms do a lot of heavy lifting so you don't have to.Create LeadsNew submissions create a lead and add a note with all the form values.", Title = "description Text ", TitleEn = "Title Text ", SectionId =3 },
new Text() { Id = 12, Content = "Customers love using 99inbound for their forms", ContentEn = "Customers love using 99inbound for their forms", Title = "Title Text ", TitleEn = "Title Text ", SectionId = 4 },
new Text() { Id = 13, Content = "The seamless nature of the service has saved my team a ton of time manually inserting lead data into our CRM and the quick notifications means our response time has dramatically decreased. This has directly resulted in more sales and productivity.", Title = "description Text ", TitleEn = "Title Text ", SectionId = 4 },
new Text() { Id = 14, Content = "Our Location", ContentEn = "Our Location", Title = "Title Text ", TitleEn = "Title Text ", SectionId = 5},
new Text() { Id = 15, Content = "", ContentEn = "", Title = "Description Text ", TitleEn = "Description Text ", SectionId = 5},
new Text() { Id = 16, Content = "Meet Our Investors", ContentEn = "Meet Our Investors", Title = "Title Text ", TitleEn = "Title Text ", SectionId =6},
new Text() { Id = 17, Content = "", ContentEn = "", Title = "Description Text ", TitleEn = "Description Text ", SectionId = 6 },
new Text() { Id = 19, Content = "Solutions for Ships Tracking", ContentEn = "Solutions for Ships Tracking", Title = "Text ", TitleEn = "Text ", SectionId =7 },
new Text() { Id = 20, Content = "Copyright © 2021. All rights reserved ", ContentEn = "Copyright © 2021. All rights reserved", Title = "Text ", TitleEn = "Text ", SectionId =7 }

);
        }

    }
}
