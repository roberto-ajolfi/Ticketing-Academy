using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.BL;
using Ticketing.Core.EF.Context;
using Ticketing.Core.EF.Repository;
using Ticketing.Core.Repository;
using Ticketing.Helpers;

namespace Ticketing.Client
{
    public class DIConfig
    {
        private static readonly string strConnection =
            Config.GetConnectionString("TicketingDb");

        public static ServiceProvider ConfigDI()
        {
            return new ServiceCollection()
                .AddTransient<DataService>()
                //.AddTransient<ITicketRepository, MockTicketRepo>()
                //.AddTransient<INoteRepository, MockNoteRepo>()
                .AddTransient<ITicketRepository, EFTicketRepository>()
                .AddTransient<INoteRepository, EFNoteRepository>()
                //.AddDbContext<TicketContext>()
                .BuildServiceProvider();
        }
    }
}