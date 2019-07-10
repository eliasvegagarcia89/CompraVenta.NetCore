using CompraVenta.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraVenta.Dominio.RepositorioInterfaces.Northwind
{
    public interface IUserRepository: IRepository<User>
    {
        User ValidaterUser(string email, string password);

        IEnumerable<User> PagedList(int startRow, int endRow);

        int Count();
    }
}
