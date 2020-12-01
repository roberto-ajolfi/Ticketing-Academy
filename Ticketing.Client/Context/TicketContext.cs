using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ticketing.Client.Model;

namespace Ticketing.Client.Context
{
    public class TicketContext : DbContext
    {
        DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionBuilder
        )
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("TicketDb");
            // OPPURE
            //string connString = config.GetSection("ConnectionStrings")["TicketDb"];

            optionBuilder.UseSqlServer(connString);
        }
    }
}
