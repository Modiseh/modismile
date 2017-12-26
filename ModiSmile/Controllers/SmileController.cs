using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModiSmile.DataAccess.Entities;
using ModiSmile.DataAccess.Repositories;
using ModiSmile.Models;

namespace ModiSmile.Controllers
{
    [Route("api/[controller]")]
    public class SmileController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public SmileController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET api/values
        [HttpGet]
        public string Get([FromQuery] EventQuery value)
        {
            if (value.UserIds!=null && value.UserIds.Length > 1)
            {
                value.UserIds = value.UserIds[0].Split(',');
            }
            return _eventRepository.GetUserEvents(value.AggregateId, value.AggregateType, value.UserIds, value.ClientId, value.Action, value.From, value.To);
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]Event value)
        {
            if (value == null)
                return false;
            if(!value.AddDate.HasValue)
                value.AddDate = DateTime.Now;
            _eventRepository.Insert(value);
            return true;
        }

       
    }
}
