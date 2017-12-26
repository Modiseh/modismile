using Dapper;
using Dapper.Contrib.Extensions;
using ModiSmile.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ModiSmile.DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _connection;
        public EventRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Insert(Event newEvent)
        {
            _connection.Insert(newEvent);
        }

        public string GetUserEvents(int? aggregateId, string aggregateType, string[] userIds, string clientId, ActionTypes action, DateTime? from, DateTime? to)
        {
            Aggregate aggregate;
            List<Event> events;
            string baseQuery = "";
            List<string> clientIds = _connection.Query<string>($"SELECT ClientId FROM [Events] WHERE [UserId] in @UserIds AND [ClientId] Is Not NULL", new { UserIds = userIds })?.ToList();
            if (clientIds == null)
            {
                clientIds = new List<string>();
            }
            if (!string.IsNullOrEmpty(clientId))
            {
                clientIds.Add(clientId);
            }


            if (clientIds != null && clientIds.Count() > 0)
            {
                List<string> allUserIds = new List<string>();
                allUserIds.AddRange(clientIds);
                allUserIds.Add(clientId);
            }

            // get aggregate
            if (aggregateId.HasValue)
            {
                aggregate = _connection.Get<Aggregate>(aggregateId);
                baseQuery = "SELECT * FROM [Events] WHERE [AggregateId]=@AggregateId";
            }
            else if (!string.IsNullOrEmpty(aggregateType))
            {
                aggregate = _connection.Query<Aggregate>("SELECT top 1 * FROM Aggregates WHERE Title=@title ORDER BY [Id] DESC", new { title = aggregateType }).First();
                baseQuery = "SELECT * FROM [Events] WHERE [AggregateType]=@AggregateType";
            }
            else
            {
                return null;
            }

            baseQuery = $"{baseQuery} AND (([UserId] IN @UserIds) OR ([ClientId] IN @ClientIds))";
            // Query
            if (from.HasValue && to.HasValue)
            {
                events = _connection.Query<Event>($"{baseQuery}  AND ([AddDate] BETWEEN @From and @To) ORDER BY [Id] DESC",
                    new { AggregateId = aggregateId, AggregateType = aggregateType, UserIds = userIds, ClientIds = clientIds, From = from, To = to }).AsList();
            }
            else if (from.HasValue)
            {
                events = _connection.Query<Event>($"{baseQuery} AND [AddDate]>=@From ORDER BY [Id] DESC",
                    new { AggregateId = aggregateId, AggregateType = aggregateType, UserIds = userIds, ClientIds = clientIds, From = from }).AsList();
            }
            else if (to.HasValue)
            {
                events = _connection.Query<Event>($"{baseQuery} AND [AddDate]<=@T ORDER BY [Id] DESCo",
                    new { AggregateId = aggregateId, AggregateType = aggregateType, UserIds = userIds, ClientIds = clientIds, To = to }).AsList();
            }
            else
            {
                events = _connection.Query<Event>($"{baseQuery} ORDER BY [Id] DESC", new { AggregateId = aggregateId, UserIds = userIds, ClientIds = clientIds }).AsList();
            }

            switch (action)
            {
                case ActionTypes.Sum:
                    if (aggregate.ValueType != AggregateValueTypes.Numeric)
                    {
                        return null;
                    }
                    return events.Sum(x => x.NumericValue).ToString();
                case ActionTypes.Count:
                    return events.Count().ToString();
                case ActionTypes.Average:
                    if (aggregate.ValueType != AggregateValueTypes.Numeric)
                    {
                        return null;
                    }
                    return events.Average(x => x.NumericValue).ToString();
                case ActionTypes.Duration:
                    if(aggregate.ValueType!= AggregateValueTypes.DateTime)
                    {
                        return null;
                    }
                    return DateTime.Now.Subtract(events.First().DateValue.Value).TotalDays.ToString();
                case ActionTypes.First:
                    switch (aggregate.ValueType)
                    {
                        case AggregateValueTypes.Numeric:
                            return events.Last().NumericValue.ToString();
                        case AggregateValueTypes.String:
                            return events.Last().StringValue;
                        case AggregateValueTypes.DateTime:
                            return events.Last().DateValue.ToString();
                        default:
                            break;
                    }
                    break;
                case ActionTypes.Last:
                    switch (aggregate.ValueType)
                    {
                        case AggregateValueTypes.Numeric:
                            return events.First().NumericValue.ToString();
                        case AggregateValueTypes.String:
                            return events.First().StringValue;
                        case AggregateValueTypes.DateTime:
                            return events.First().DateValue.ToString();
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return null;
        }

    }
}
