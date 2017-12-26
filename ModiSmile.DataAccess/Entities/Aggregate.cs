using System;

namespace ModiSmile.DataAccess.Entities
{
    public class Aggregate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public double Rate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int ExpireUntilDaysAfter { get; set; }
        public int Priority { get; set; }




    }
}
