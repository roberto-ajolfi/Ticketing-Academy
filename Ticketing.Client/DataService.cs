using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Ticketing.Client.Context;
using Ticketing.Client.Model;

namespace Ticketing.Client
{
    public class DataService
    {
        public void ListLazy()
        {
            using var ctx = new TicketContext();

            Console.WriteLine("-- TICKET LIST (LAZY) --");
            foreach (var t in ctx.Tickets)
            {
                Console.WriteLine($"[{t.Id}] {t.Title}");
                foreach (var n in t.Notes)
                    Console.WriteLine($"\t{n.Comments}");
            }
            Console.WriteLine("-----------------");
        }

        public List<Ticket> ListEager()
        {
            using var ctx = new TicketContext();

            return ctx.Tickets
                .Include(t => t.Notes)
                .ToList();
        }

        public bool Add(Ticket ticket)
        {
            try
            {
                using var ctx = new TicketContext();

                if (ticket != null)
                {
                    ctx.Tickets.Add(ticket);
                    ctx.SaveChanges();
                }
                else
                    Console.WriteLine("Ticket non può essere nullo.");

                return true;
            } catch(Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }  
        }

        public bool AddNote(Note newNote)
        {
            try
            {
                using var ctx = new TicketContext();

                if (newNote != null)
                {
                    var ticket = ctx.Tickets.Find(newNote.TicketId);
                    if (ticket != null)
                    {
                        ticket.Notes.Add(newNote);
                        ctx.SaveChanges();
                    }

                    // OPPURE
                    //newNote.Ticket = ticket;
                    //ctx.Notes.Add(newNote);
                    //ctx.SaveChanges();
                }
                else
                    Console.WriteLine("Note non può essere nullo.");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex.Message);
                return false;
            }
        }

        public Ticket GetTicketByIDViaSTP(int id)
        {
            using var ctx = new TicketContext();

            SqlParameter idParam = new SqlParameter("@id", id);

            var result = ctx.Tickets.FromSqlRaw("exec stpGetTicketById @id", idParam).AsEnumerable();

            return result.FirstOrDefault();
        }

        public Ticket GetTicketById(int id)
        {
            using var ctx = new TicketContext();

            if (id > 0)
                return ctx.Tickets.Find(id);

            return null;
        }

        public bool Edit(Ticket ticket)
        {
            using var ctx = new TicketContext();
            bool saved = false;

            do
            {
                try
                {
                    if (ticket == null)
                        return false;

                    Console.WriteLine("Smandrappa il Ticket e poi premi enter ...");
                    Console.ReadKey();

                    ctx.Entry<Ticket>(ticket).State = EntityState.Modified;
                    ctx.SaveChanges();

                    saved = true;
                    
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // ...
                    Console.WriteLine("Error: " + ex.Message);
                    //return false;
                    saved = false;
                }
            } while (!saved);

            return true;
        }
    }
}