using System;
using System.Collections.Generic;
using ModiSmile.DataAccess.Entities;

namespace ModiSmile.DataAccess.Repositories
{
    public interface IEventRepository
    {
        double? GetUserEvents(int? aggregateId, string aggregateType, string[] userIds,string clientId, ActionTypes action, DateTime? from, DateTime? to);
        void Insert(Event newEvent);
        IEnumerable<Event> GetUserEventTransactions(int? aggregateId, string aggregateType, string[] userIds, string clientId, DateTime? from, DateTime? to);
    }
}