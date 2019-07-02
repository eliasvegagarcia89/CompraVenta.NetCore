using CompraVenta.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraVenta.Repositories.Northwind
{
    public interface IUserRepository: IRepository<User>
    {
        User ValidaterUser(string email, string password);

        IEnumerable<User> PagedList(int startRow, int endRow);

        int Count();
    }
}
