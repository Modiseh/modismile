using ModiSmile.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModiSmile.Models
{
    public class EventQuery
    {
        public int AggregateId { get; set; }
        public string AggregateType { get; set; }
        public string[] UserIds { get; set; }
        public string ClientId { get; set; }
        public ActionTypes Action { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

    }
}
