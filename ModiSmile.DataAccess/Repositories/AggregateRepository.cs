using Dapper.Contrib.Extensions;
using ModiSmile.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ModiSmile.DataAccess.Repositories
{
    public class AggregateRepository : IAggregateRepository
    {

        private readonly IDbConnection _connection;
        public AggregateRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public Aggregate Get(int id)
        {
            return _connection.Get<Aggregate>(id);
        }

        public void Insert(Aggregate aggregate)
        {
            if (aggregate == null)
                return;
            _connection.Insert(aggregate);
        }

        public List<Aggregate> GetAll()
        {
            return _connection.GetAll<Aggregate>().Where(x=>
            (!x.FromDate.HasValue && !x.ToDate.HasValue) ||
            (x.FromDate.HasValue && !x.ToDate.HasValue && x.FromDate<=DateTime.Now && 
                            x.ExpiresDaysAfter.HasValue && x.FromDate.Value.AddDays(x.ExpiresDaysAfter.Value)>=DateTime.Now) ||
            (x.FromDate.HasValue && !x.ToDate.HasValue && x.FromDate <= DateTime.Now && !x.ExpiresDaysAfter.HasValue) ||
            (!x.FromDate.HasValue && x.ToDate.HasValue && x.ToDate.Value>=DateTime.Now))
            ?.ToList();
        }

        public void Update(Aggregate aggregate)
        {
            if (aggregate == null)
                return;
            _connection.Update(aggregate);
        }

        public Aggregate GetByTitle(string title)
        {
            return GetAll().Where(x => x.Title == title)?.OrderByDescending(x => x.Priority)?.First();
        }
    }
}
