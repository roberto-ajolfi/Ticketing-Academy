using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ticketing.Core.EF.Context;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.Core.EF.Repository
{
    public class EFTicketRepository : ITicketRepository
    {
        public bool Add(Ticket item)
        {
            using (var _ctx = new TicketContext())
            {
                if (item == null)
                    return false;

                _ctx.Tickets.Add(item);
                _ctx.SaveChanges();

                return true;
            }
        }

        public bool DeleteById(int id)
        {
            using (var _ctx = new TicketContext())
            {
                if (id <= 0)
                    return false;

                var ticket = _ctx.Tickets.Find(id);

                if (ticket != null)
                {
                    _ctx.Tickets.Remove(ticket);
                    _ctx.SaveChanges();
                }

                return true;
            }
        }

        public IEnumerable<Ticket> Get(Func<Ticket, bool> filter = null)
        {
            using (var _ctx = new TicketContext())
            {
                if (filter != null)
                    return _ctx.Tickets
                        .Include(t => t.Notes)
                        .Where(filter).ToList();

                return _ctx.Tickets
                    .Include(t => t.Notes)
                    .ToList();
            }
        }

        public Ticket GetByID(int id)
        {
            using (var _ctx = new TicketContext())
            {
                if (id <= 0)
                    return null;

                return _ctx.Tickets
                    .Include(t => t.Notes)
                    .Where(t => t.Id == id)
                    .SingleOrDefault();

            }
        }

        public Ticket GetTicketByTitle(string title)
        {
            using (var _ctx = new TicketContext())
            {
                return _ctx.Tickets
                    .Include(t => t.Notes)
                    .Where(t => t.Title == title)
                    .SingleOrDefault();
            }
        }

        public bool Update(Ticket item)
        {
            using (var _ctx = new TicketContext())
            {
                bool saved = false;
                do
                {
                    try
                    {
                        _ctx.Entry<Ticket>(item).State = EntityState.Modified;
                        _ctx.SaveChanges();

                        saved = true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        foreach (var entity in ex.Entries)
                        {
                            var dbValues = entity.GetDatabaseValues();
                            entity.OriginalValues.SetValues(dbValues);
                        }
                    }
                } while (!saved);

                return true;
            }
        }
    }
}
