using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ticketing.Client.Model;
using Ticketing.Helpers;

namespace Ticketing.Client.Context
{
    public sealed class TicketContext : DbContext
    {
        DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionBuilder
        )
        {
            string connString = Config.GetConnectionString("TicketDb");
            // OPPURE
            //string connString = Config.GetSection("ConnectionStrings")["TicketDb"];

            optionBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ticketModel = modelBuilder.Entity<Ticket>();

            ticketModel
                .HasKey(t => t.Id); // non è necessario se si rispettano le convenzioni
            
            ticketModel
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            ticketModel
                .Property(t => t.Description)
                .HasMaxLength(500);

            ticketModel
                .Property(t => t.Category)
                .IsRequired();

            ticketModel
                .Property(t => t.Requestor)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
