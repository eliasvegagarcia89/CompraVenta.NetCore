using CompraVenta.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraVenta.Repositories.Northwind
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> PagedList(int startRow, int endRow);

        int Count();
    }
}
