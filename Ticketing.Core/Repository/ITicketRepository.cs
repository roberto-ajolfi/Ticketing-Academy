using System;
using System.Collections.Generic;
using System.Text;
using Ticketing.Core.Model;

namespace Ticketing.Core.Repository
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Ticket GetTicketByTitle(string title);
    }
}
