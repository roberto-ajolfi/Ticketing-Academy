using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Core.EF.Context;
using Ticketing.Core.Model;

namespace Ticketing.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            using var _ctx = new TicketContext();

            return _ctx.Tickets.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var _ctx = new TicketContext();

            var ticket = _ctx.Tickets
                .SingleOrDefault(t => t.Id == id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult Post(Ticket ticket)    // <== Model Binding
        {
            using var _ctx = new TicketContext();

            if (ticket != null)
            {
                _ctx.Tickets.Add(ticket);
                _ctx.SaveChanges();

                return Ok();
            }

            return BadRequest("Invalid Ticket.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var _ctx = new TicketContext();

            var ticket = _ctx.Tickets
                .SingleOrDefault(t => t.Id == id);

            if (ticket != null)
            {
                _ctx.Tickets.Remove(ticket);
                _ctx.SaveChanges();
            }
            else
                return NotFound();

            return Ok();
        }
    }
}
