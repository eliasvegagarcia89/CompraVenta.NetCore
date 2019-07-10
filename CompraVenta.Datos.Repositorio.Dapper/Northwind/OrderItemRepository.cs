﻿using CompraVenta.Dominio.Entidades;
using CompraVenta.Dominio.RepositorioInterfaces.Northwind;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CompraVenta.Datos.Repositorio.Northwind
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(string connectionString) : base(connectionString)
        {
        }

        public int Count()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(Id) FROM dbo.[OrderItem]");
            }
        }

        public IEnumerable<OrderItem> PagedList(int startRow, int endRow)
        {
            if (startRow >= endRow) return new List<OrderItem>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);
                return connection.Query<OrderItem>(
                    "dbo.OrderItemPagedList",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
