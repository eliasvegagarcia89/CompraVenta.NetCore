using CompraVenta.Dominio.Entidades;
using CompraVenta.Dominio.RepositorioInterfaces.Northwind;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CompraVenta.Datos.Repositorio.Northwind
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }        
        public int Count()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(Id) FROM dbo.Customer");
            }
        }

        public IEnumerable<Customer> PagedList(int startRow, int endRow)
        {
            if (startRow >= endRow) return new List<Customer>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);
                return connection.Query<Customer>(
                    "dbo.CustomerPagedList",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
