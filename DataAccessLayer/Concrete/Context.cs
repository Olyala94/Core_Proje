using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    // "Context'in" - 2 tane temel Görevi olacak : 
    //1. Veri tabanı Yapılandırılmamız içerisindeki  Bağlantı stringini tutan 
    //2. Veri Tabanına Yansıtılacak olan Tabloları tutan Clasımız  
    //DbSeti Kullanabilmek için DbContexti çagırıyoruz...

   //public class Context:DbContext //Veri taabanına yansıtmak istediğimiz tabloları çağıracağız "DbSet" üzerinden 

    public class Context : IdentityDbContext< WriterUser, WriterRole, int >  
    {
        //MVC de Web Config dosyasının içerisine ayarlıyorduk, ama burada Web Config Dosyası yok 
        //Onun yerine farkı baglantı string kullanılır 
        //Configuration Metodu - Bu metod benim bağlantı adresimi tutacak olan Metod!!

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=CoreProjeDB;integrated security=true");
        }
       
        public DbSet<About> Abouts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }
      
        public DbSet<ToDoList> ToDoLists { get; set; }

        public DbSet<Test> Test { get; set; }

        public DbSet<Announcement> Announcements { get; set; }  

        public DbSet<WriterMessage> WriterMessages { get; set; }  
    }
}
