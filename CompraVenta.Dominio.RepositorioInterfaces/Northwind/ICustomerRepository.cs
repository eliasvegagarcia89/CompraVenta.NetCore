using CompraVenta.Dominio.Entidades;
using System.Collections.Generic;

namespace CompraVenta.Dominio.RepositorioInterfaces.Northwind
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        IEnumerable<Customer> PagedList(int startRow, int endRow);

        int Count();
    }
}
