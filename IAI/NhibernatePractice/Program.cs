using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;

namespace NhibernatePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration().DataBaseIntegration(db =>
                                                                        {
                                                                            db.ConnectionString = "Data Source=.;Initial Catalog=NP;Integrated Security=True";
                                                                            db.Dialect<MsSql2012Dialect>();
                                                                        });

            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);

            new SchemaExport(cfg).Execute(x => { },false, false, TextWriter.Null);

            using (ISessionFactory factory = cfg.BuildSessionFactory())
            {
                using (ISession session = factory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        var product = new Product() { Id = Guid.NewGuid(), Name = "aaa", Price = 13.90 };
//                        var orderItem1 = new OrderItem() { Id = Guid.NewGuid(), ProductNumber = 1, Product = product };
//                        var orderItem2 = new OrderItem() { Id = Guid.NewGuid(), ProductNumber = 3, Product = product };
//                        var order = new Order() { Id = Guid.NewGuid(), Code = "111", Items = new List<OrderItem>() { orderItem1, orderItem2 } };
                        session.Save(product);
                        tx.Commit();
                    }
                }
            }
            
        }
    }


    public class Product
    {
        public Product()
        {
//            Items = new List<OrderItem>();
        }
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
//        public virtual IList<OrderItem> Items { get; set; }
    }

//    public class Order
//    {
//        public Order()
//        {
//            Items = new List<OrderItem>();
//        }
//        public virtual Guid Id { get;  set; }
//        public virtual string Code { get; set; }
//        public virtual IList<OrderItem> Items { get; set; }
//    }
//
//    public class OrderItem
//    {
//        public OrderItem()
//        {
//
//        }
//        public virtual Guid Id { get;  set; }
//        public virtual decimal Amount { get; set; }
//        public virtual Product Product { get; set; }
//        public virtual Order Order { get; set; }
//        public virtual int ProductNumber { get; set; }
//    }

    public class ProcutMap : ClassMapping<Product>
    {
        public ProcutMap()
        {
            Id(x => x.Id);
            Property(x => x.Name);
            Property(x => x.Price);
//            Bag(x => x.Items, x => { x.Table("OrderItem"); }, x => x.OneToMany(m => m.Class(typeof(OrderItem))));
        }
    }
//    public class OrderMap : ClassMapping<Order>
//    {
//        public OrderMap()
//        {
//            Table("OrderTable");
//            Id(x => x.Id);
//            Property(x => x.Code);
//            Bag(x => x.Items, x => { x.Table("OrderItem"); }, x => x.OneToMany(m => m.Class(typeof(OrderItem))));
//        }
//    }
//
//    public class OrderItemMap : ClassMapping<OrderItem>
//    {
//        public OrderItemMap()
//        {
//            Table("OrderItem");
//            Id(x => x.Id);
//            Property(x => x.Amount);
//            Property(x => x.ProductNumber);
//            ManyToOne(x => x.Product, x => { x.Class(typeof(Product)); x.Column("ProductId"); });
//            ManyToOne(x => x.Order, x => { x.Class(typeof(Order)); x.Column("OrderId"); });
//        }
//    }
}
