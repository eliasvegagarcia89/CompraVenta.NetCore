using CompraVenta.Repositories.Northwind;

namespace CompraVenta.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }
        IUserRepository Users { get; }
    }
}
