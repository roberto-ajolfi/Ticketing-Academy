using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Core.BL;
using Ticketing.Core.EF.Context;
using Ticketing.Core.EF.Repository;
using Ticketing.Core.Model;
using Ticketing.Core.Repository;

namespace Ticketing.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private DataService dataService;

        public TicketController(DataService service)
        {
            this.dataService = service;
        }

        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            //using var _ctx = new TicketContext();

            //var result = _ctx.Tickets
            //    //.Include(t => t.Notes)
            //    .ToList();

            var result = dataService.List();

            return result;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //using var _ctx = new TicketContext();

            //var ticket = _ctx.Tickets
            //    .SingleOrDefault(t => t.Id == id);

            var ticket = dataService.GetTicketById(id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult Post(Ticket ticket)    // <== Model Binding
        {
            //using var _ctx = new TicketContext();

            if (ticket != null)
            {
                //_ctx.Tickets.Add(ticket);
                //_ctx.SaveChanges();

                var result = dataService.Add(ticket);

                if(result)
                    return Ok();
            }

            return BadRequest("Invalid Ticket.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Ticket ticket) //<== Doppio Model Binding
        {
            using var _ctx = new TicketContext();

            if(ticket != null && id == ticket.Id)
            {
                var result = dataService.Edit(ticket);

                if(result)
                    return Ok();

                //bool saved = false;
                //do
                //{
                //    try
                //    {
                //        _ctx.Entry<Ticket>(ticket).State = EntityState.Modified;
                //        _ctx.SaveChanges();

                //        saved = true;
                //    }
                //    catch (DbUpdateConcurrencyException ex)
                //    {
                //        foreach (var entity in ex.Entries)
                //        {
                //            var dbValues = entity.GetDatabaseValues();
                //            entity.OriginalValues.SetValues(dbValues);
                //        }
                //    }
                //} while (!saved);
            }

            return BadRequest("Error updating Ticket");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //using var _ctx = new TicketContext();

            //var ticket = _ctx.Tickets
            //    .SingleOrDefault(t => t.Id == id);

            //if (ticket != null)
            //{
            //    _ctx.Tickets.Remove(ticket);
            //    _ctx.SaveChanges();
            //}
            //else
            //    return NotFound();

            var result = dataService.Delete(id);

            if(result)
                return Ok();

            return BadRequest("Cannot delete Ticket");
        }
    }
}
