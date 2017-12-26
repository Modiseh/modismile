using System;
using ModiSmile.DataAccess.Entities;

namespace ModiSmile.DataAccess.Repositories
{
    public interface IEventRepository
    {
        long? GetUserEvents(int? aggregateId, string aggregateType, string[] userIds,string clientId, ActionTypes action, DateTime? from, DateTime? to);
        void Insert(Event newEvent);
    }
}