using CompraVenta.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraVenta.Repositories.Northwind
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> PagedList(int startRow, int endRow);

        int Count();
    }
}
