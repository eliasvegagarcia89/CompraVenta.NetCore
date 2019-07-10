using CompraVenta.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraVenta.Dominio.RepositorioInterfaces.Northwind
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> PagedList(int startRow, int endRow);

        int Count();
    }
}
