using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace web1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
        public int UserID { set; get; }
        public string Fname { set; get; }
        public string Lname { set; get; }       
        public int Age { set; get; } 
        public string Gender { set; get; } 
        public DateTime DOB { set; get; }
        public DateTime CreatedTime { set; get; }
        public DateTime UpdatedTime { set; get; }

        public ICollection<Book> Books { set; get; }
        public ICollection<BookImage> BookImages { set; get; }
        public ICollection<Section> Sections { set; get; }        
        public ICollection<SectionImage> SectionImages { set; get; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Book
    {
        [Key]
        public int BookID { set; get; }
        public string BookTitle { set; get; }
        public string BookContent { set; get; }
        public string BookMetaDescription { set; get; }
        public string BookMetaKeywords { set; get; }
        public string BookMetaAuthor { set; get; }
        public DateTime BookCreatedTime { set; get; }
        public DateTime BookUpdatedTime { set; get; }


        public ICollection<BookImage> BookImages { set; get;}
        public ICollection<Section> Sections { set; get; }

        public string Id { set; get; }
        public ApplicationUser User { set; get; }

    }

    public class BookImage
    {
        [Key]
        public int BookImageID { set; get; }
        public string BookSocialMedia { set; get; } //fb tw wa li is
        public string BookMetaImage { set; get; }
        public string BookMetaImageWidth { set; get; }
        public string BookMetaImageHeight { set; get; }
        public DateTime BookImageCreatedTime { set; get; }
        public DateTime BookImageUpdatedTime { set; get; }

        public int BookID { set; get; }
        public Book Book { set; get; }

        public string Id { set; get; }
        public ApplicationUser User { set; get; }
    }

    public class Section
    {
        [Key]
        public int SectionID { set; get; }
        public string SectionTitle { set; get; }
        public string SectionContent { set; get; }
        public string SectionMetaDescription { set; get; }
        public string SectionMetaKeywords { set; get; }
        public string SectionMetaAuthor { set; get; }
        public DateTime SectionCreatedTime { set; get; }
        public DateTime SectionUpdatedTime { set; get; }
        public ICollection<SectionImage> SectionImages { set; get; }
        
        public int BookID { set; get; }
        public Book Book { set; get; }

        public string Id { set; get; }
        public ApplicationUser User { set; get; }

    }

    public class SectionImage
    {
        [Key]
        public int SectionImageID { set; get; }
        public string SectionSocialMedia { set; get; } //fb tw wa li is
        public string SectionMetaImage { set; get; }
        public string SectionMetaImageWidth { set; get; }
        public string SectionMetaImageHeight { set; get; }
        public DateTime SectionImageCreatedTime { set; get; }
        public DateTime SectionImageUpdatedTime { set; get; }

        public int SectionID { set; get; }
        public Section Section { set; get; }

        public string Id { set; get; }
        public ApplicationUser User { set; get; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("mysql", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionImage> SectionImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(u => u.UserID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            
        }
    }
}