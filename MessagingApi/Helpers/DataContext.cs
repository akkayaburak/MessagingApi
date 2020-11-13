using Microsoft.Extensions.Configuration;
using MessagingApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("MessagingServiceDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(p => p.Receiver)
                .WithMany(t => t.MessagesReceived)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(p => p.Sender)
                .WithMany(t => t.MessagesSent)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Block>()
                .HasOne(p => p.BlockBy)
                .WithMany(t => t.BlocksBy)
                .HasForeignKey(m => m.BlockById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Block>()
                .HasOne(p => p.BlockTo)
                .WithMany(t => t.BlocksTo)
                .HasForeignKey(m => m.BlockToId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Token> Tokens { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Block> Blocks { get; set; }
    }
}
