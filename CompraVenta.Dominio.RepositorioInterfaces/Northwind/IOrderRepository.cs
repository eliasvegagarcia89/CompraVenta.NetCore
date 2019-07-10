using CompraVenta.Dominio.Entidades;
using System.Collections.Generic;

namespace CompraVenta.Dominio.RepositorioInterfaces.Northwind
{
    public interface IOrderRepository: IRepository<Order>
    {
        IEnumerable<Order> PagedList(int startRow, int endRow);
        int Count();
        IEnumerable<Order> OrderByCustomer(int customerId);
    }
}
