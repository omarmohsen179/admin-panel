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
        }

    }
}
