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
        public string StringValue { get; set; }
        public long NumericValue { get; set; }
        public DateTime? DateValue { get; set; }
        public string UserId { get; set; }
        public string ClientId { get; set; }
        public DateTime? AddDate { get; set; }


    }
}
