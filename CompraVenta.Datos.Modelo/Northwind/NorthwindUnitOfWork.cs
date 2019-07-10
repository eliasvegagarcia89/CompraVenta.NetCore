using CompraVenta.Datos.IModelo;
using CompraVenta.Datos.Repositorio.Northwind;
using CompraVenta.Dominio.RepositorioInterfaces.Northwind;

namespace CompraVenta.Datos.Modelo.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customers { get; private set; }
        public IOrderItemRepository OrderItems { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }
        public IUserRepository Users { get; private set; }

        public NorthwindUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);
            OrderItems = new OrderItemRepository(connectionString);
            Orders = new OrderRepository(connectionString);
            Products = new ProductRepository(connectionString);
            Suppliers = new SupplierRepository(connectionString);
            Users = new UserRepository(connectionString);
        }
    }
}
