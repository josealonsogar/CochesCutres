using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CochesCutres.Models
{
    public class GestionCliente
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["cochescutrescon"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Cliente cliente)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO dbo.clientes(nif, nombre, apellidos, telefono, direccion, email) " +
                "VALUES (@nif, @nombre, @apellidos, @telefono, @direccion, @email)", con);
            comando.Parameters.Add("@nif", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellidos", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);

            comando.Parameters["@nif"].Value = cliente.nif;
            comando.Parameters["@nombre"].Value = cliente.nombre;
            comando.Parameters["@apellidos"].Value = cliente.apellidos;
            comando.Parameters["@telefono"].Value = cliente.telefono;
            comando.Parameters["@direccion"].Value = cliente.direccion;
            comando.Parameters["@email"].Value = cliente.email;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Cliente> GetAll()
        {
            Conectar();
            List<Cliente> clientes = new List<Cliente>();

            SqlCommand com = new SqlCommand("SELECT nif, nombre, apellidos, telefono, direccion, email from dbo.clientes", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Cliente c = new Cliente
                {
                    nif = registros["nif"].ToString(),
                    nombre = registros["nombre"].ToString(),
                    apellidos = registros["apellidos"].ToString(),
                    telefono = registros["telefono"].ToString(),
                    direccion = registros["direccion"].ToString(),
                    email = registros["email"].ToString()
                };
                clientes.Add(c);
            }
            con.Close();
            return clientes;
        }
    }
}