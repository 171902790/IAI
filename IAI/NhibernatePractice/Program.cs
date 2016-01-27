using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode.Conformist;

namespace NhibernatePractice
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
    
    public class Order
    {
        public virtual Guid Id { get; set; }
        public virtual string Code { get; set; }
        public virtual IList<OrderItem> Items { get; set; }
    }

    public class OrderItem
    {
        public virtual Guid Id { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual int ProductNumber { get; set; }
    }

    public class ProcutMap : ClassMapping<Product>
    {
        
    }
}
