using PracticaCORE.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCORE.Repositories
{
    public class Repository1
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Repository1()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=NETCORE;Persist Security Info=True;User ID=SA;Password='MCSD2023'";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<string> GetClientes()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_CLIENTES";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List <string> clientes = new List<string>();
            while (this.reader.Read())
            {
                clientes.Add(this.reader["EMPRESA"].ToString());
            }
            this.reader.Close();
            this.cn.Close();
            return clientes;
        }

        public ResumenEmpresas FindClientes(string codCliente)
        {
            string sql = "select * from clientes where codigoCliente=@codCliente";
            SqlParameter pamCodCliente = new SqlParameter("@codCliente", codCliente);
            this.com.Parameters.Add(pamCodCliente);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            ResumenEmpresas clientes = new ResumenEmpresas();
            this.reader.Read();
            clientes.codCliente = this.reader["codigoCliente"].ToString();
            clientes.empresa = this.reader["empresa"].ToString();
            clientes.contacto = this.reader["contacto"].ToString();
            clientes.cargo = this.reader["cargo"].ToString();
            clientes.ciudad = this.reader["ciudad"].ToString();
            clientes.telefono = this.reader["telefono"].ToString();
           
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();
            return clientes;
        }

        public List<Pedido> GetPedidos(string codCliente)
        {
            string sql = "select * from pedidos where codigoCliente=@codCliente";
            SqlParameter pamCodCliente = new SqlParameter("@codCliente", codCliente);
            this.com.Parameters.Add(pamCodCliente);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
           List <Pedido> list = new List<Pedido>();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Pedido pedido = new Pedido();
                pedido.codPedido = this.reader["FechaEntrega"].ToString();
                pedido.codCliente = this.reader["FechaEntrega"].ToString();
                pedido.FechaEntrtega = this.reader["FechaEntrega"].ToString();
                pedido.formaEnvio = this.reader["FechaEntrega"].ToString();
                pedido.importe = int.Parse(this.reader["FechaEntrega"].ToString());
                list.Add(pedido);
            }
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();
            return list;

        }
    }
}
