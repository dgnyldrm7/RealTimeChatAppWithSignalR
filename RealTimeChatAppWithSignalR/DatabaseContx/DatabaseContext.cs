using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealTimeChatAppWithSignalR.Entities;
using System;

namespace RealTimeChatAppWithSignalR.DatabaseContx
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //İlişki sağlandı!
            builder.Entity<Chat>()
            .HasOne(c => c.ApplicationUser) // Chat sınıfı ApplicationUser ile ilişkilendirilir
            .WithMany(u => u.Chats) // ApplicationUser sınıfı Chats ile ilişkilendirilir
            .HasForeignKey(c => c.ChatId);



            // ApplicationUser seed data
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "abc",
                    Name = "Doğan",
                    LName = "Yildirim",
                    Photo = "dnm.jpg",
                    Status = false
                },
                new ApplicationUser
                {
                    Id = "abcd",
                    Name = "Kemal",
                    LName = "Meral",
                    Photo = "dnm2.jpg",
                    Status = false
                }
            );


            builder.Entity<Chat>().HasData(
                new Chat
                {
                    Id = "klm",
                    CreatedTime = DateTime.Now,
                    UserId = 1,
                    ToUserId = 2,
                    
                }
                );
        }
    }
}
