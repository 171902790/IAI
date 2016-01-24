using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAI.DomainModel;

namespace IAI.IRepository
{
    public interface IRepository<in TAggregate> where TAggregate:IAggregateRoot
    {
        void Add(TAggregate aggregate);
        void Get(Guid id);
        void Update(TAggregate aggregate);
        void Delete(Guid id);
    }
}
