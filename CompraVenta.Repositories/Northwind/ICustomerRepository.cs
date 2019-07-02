using CompraVenta.Models;
using System.Collections.Generic;

namespace CompraVenta.Repositories.Northwind
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        IEnumerable<Customer> PagedList(int startRow, int endRow);

        int Count();
    }
}
