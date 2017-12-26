using System;

namespace ModiSmile.DataAccess.Entities
{
    public class Aggregate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Version { get; set; }
        public AggregateValueTypes ValueType { get; set; }


    }
}
