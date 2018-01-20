using System.Collections.Generic;
using ModiSmile.DataAccess.Entities;

namespace ModiSmile.DataAccess.Repositories
{
    public interface IAggregateRepository
    { 
        Aggregate Get(int id);
        List<Aggregate> GetAll();
        void Insert(Aggregate aggregate);
        void Update(Aggregate aggregate);
        Aggregate GetByTitle(string title);
    }
}