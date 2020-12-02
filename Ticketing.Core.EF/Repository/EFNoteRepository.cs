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
    public class EFNoteRepository : INoteRepository
    {
        public bool Add(Note item)
        {
            using (var _ctx = new TicketContext())
            {
                if (item == null)
                    return false;

                var ticket = _ctx.Tickets
                    .Include(t => t.Notes)
                    .Where(t => t.Id == item.TicketId)
                    .SingleOrDefault();

                if (ticket != null)
                {
                    ticket.Notes.Add(item);
                    _ctx.SaveChanges();
                }


                return true;
            }
        }

        public bool DeleteById(int id)
        {
            using (var _ctx = new TicketContext())
            {
                if (id <= 0)
                    return false;

                var note = _ctx.Notes.Find(id);

                if (note != null)
                {
                    _ctx.Notes.Remove(note);
                    _ctx.SaveChanges();
                }

                return true;
            }
        }

        public IEnumerable<Note> Get(Func<Note, bool> filter = null)
        {
            using (var _ctx = new TicketContext())
            {
                if (filter != null)
                    return _ctx.Notes
                        .Where(filter);

                return _ctx.Notes;
            }
        }

        public Note GetByID(int id)
        {
            using (var _ctx = new TicketContext())
            {
                if (id <= 0)
                    return null;

                return _ctx.Notes.Find(id);

            }
        }

        public bool Update(Note item)
        {
            using (var _ctx = new TicketContext())
            {
                _ctx.Entry<Note>(item).State = EntityState.Modified;
                _ctx.SaveChanges();

                return true;
            }
        }
    }
}
