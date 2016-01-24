using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAI.DomainModel
{
    public class Goods:IAggregateRoot
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
