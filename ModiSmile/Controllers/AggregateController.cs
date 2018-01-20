using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModiSmile.DataAccess.Entities;
using ModiSmile.DataAccess.Repositories;

namespace ModiSmile.Controllers
{
    [Produces("application/json")]
    [Route("api/Aggregate")]
    public class AggregateController : Controller
    {
        private readonly IAggregateRepository _aggregateRepository;
        public AggregateController(IAggregateRepository aggregateRepository)
        {
            _aggregateRepository = aggregateRepository;
        }

        // GET: api/Aggregate
        [HttpGet]
        public IEnumerable<Aggregate> Get()
        {
            return _aggregateRepository.GetAll();
        }

        // GET: api/Aggregate/5
        [HttpGet("{id}", Name = "Get")]
        public Aggregate Get(int id, [FromQuery] string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                _aggregateRepository.GetByTitle(title);
            }
            return _aggregateRepository.Get(id);
        }
        
        // POST: api/Aggregate
        [HttpPost]
        public void Post([FromBody]Aggregate value)
        {
            _aggregateRepository.Insert(value);
        }
        
        // PUT: api/Aggregate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Aggregate value)
        {
            _aggregateRepository.Insert(value);
        }
    }
}
