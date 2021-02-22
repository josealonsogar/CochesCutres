using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CochesCutres.Models
{
    public class GestionEmpleado
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["cochescutrescon"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Empleado empleado)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO dbo.empleados(nif, nombre, apellidos, telefono, direccion, email) " +
                "VALUES (@nif, @nombre, @apellidos, @telefono, @direccion, @email)", con);
            comando.Parameters.Add("@nif", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellidos", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);

            comando.Parameters["@nif"].Value = empleado.nif;
            comando.Parameters["@nombre"].Value = empleado.nombre;
            comando.Parameters["@apellidos"].Value = empleado.apellidos;
            comando.Parameters["@telefono"].Value = empleado.telefono;
            comando.Parameters["@direccion"].Value = empleado.direccion;
            comando.Parameters["@email"].Value = empleado.email;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Empleado> GetAll()
        {
            Conectar();
            List<Empleado> empleados = new List<Empleado>();

            SqlCommand com = new SqlCommand("SELECT nif, nombre, apellidos, telefono, direccion, email from dbo.empleados", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Empleado e = new Empleado
                {
                    nif = registros["nif"].ToString(),
                    nombre = registros["nombre"].ToString(),
                    apellidos = registros["apellidos"].ToString(),
                    telefono = registros["telefono"].ToString(),
                    direccion = registros["direccion"].ToString(),
                    email = registros["email"].ToString()
                };
                empleados.Add(e);
            }
            con.Close();
            return empleados;
        }
    }
}