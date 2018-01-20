using System;
using System.Collections.Generic;
using System.Text;

namespace ModiSmile.DataAccess.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int AggregateId { get; set; }
        public string AggregateType { get; set; }
        public string EventDetails { get; set; }
        public long Value { get; set; }
        public string UserId { get; set; }
        public string ClientId { get; set; }
        public DateTime? AddDate { get; set; }


    }
}
