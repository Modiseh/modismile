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
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IAggregateRepository _aggregateRepository;

        public EventController(IEventRepository eventRepository, IAggregateRepository aggregateRepository)
        {
            _eventRepository = eventRepository;
            _aggregateRepository = aggregateRepository;
        }

        // GET api/values
        [HttpGet]
        public double? Get([FromQuery] EventQuery value)
        {
            if (value.UserIds!=null && value.UserIds.Length > 1)
            {
                value.UserIds = value.UserIds[0].Split(',');
            }
            return _eventRepository.GetUserEvents(value.AggregateId, value.AggregateType, value.UserIds, value.ClientId, value.Action, value.From, value.To);
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody] Event value)
        {
            if (value == null)
                return false;
            if(!value.AddDate.HasValue)
                value.AddDate = DateTime.Now;
            if (value.AggregateId == 0)
            {
                if (string.IsNullOrEmpty(value.AggregateType))
                {
                    return false;
                }
                value.AggregateId = _aggregateRepository.GetByTitle(value.AggregateType).Id;
            }
            _eventRepository.Insert(value);
            return true;
        }

       
    }
}
