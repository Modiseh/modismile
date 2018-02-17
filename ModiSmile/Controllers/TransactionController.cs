using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModiSmile.DataAccess.Entities;
using ModiSmile.DataAccess.Repositories;
using ModiSmile.Models;

namespace ModiSmile.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IAggregateRepository _aggregateRepository;

        public TransactionController(IEventRepository eventRepository, IAggregateRepository aggregateRepository)
        {
            _eventRepository = eventRepository;
            _aggregateRepository = aggregateRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Event> GetAll([FromQuery] EventQuery value)
        {
            if (value.UserIds != null && value.UserIds.Length > 1)
            {
                value.UserIds = value.UserIds[0].Split(',');
            }
            return _eventRepository.GetUserEventTransactions(value.AggregateId, value.AggregateType, value.UserIds, value.ClientId, value.From, value.To);
        }
    }
}
