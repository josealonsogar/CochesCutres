using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CochesCutres.Models
{
    public class GestionVehiculo
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["cochescutrescon"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Vehiculo vehiculo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("INSERT INTO dbo.vehiculos(marca, modelo, numPuertas, color, kilometros, tipoVehiculo, garantia, stock, fotografia) " +
                "VALUES (@marca, @modelo, @numPuertas, @color, @kilometros, @tipoVehiculo, @garantia, @stock, @fotografia)", con);
            comando.Parameters.Add("@marca", SqlDbType.VarChar);
            comando.Parameters.Add("@modelo", SqlDbType.VarChar);
            comando.Parameters.Add("@numPuertas", SqlDbType.Int);
            comando.Parameters.Add("@color", SqlDbType.VarChar);
            comando.Parameters.Add("@kilometros", SqlDbType.Int);
            comando.Parameters.Add("@tipoVehiculo", SqlDbType.VarChar);
            comando.Parameters.Add("@garantia", SqlDbType.Int);
            comando.Parameters.Add("@stock", SqlDbType.Bit);
            comando.Parameters.Add("@fotografia", SqlDbType.VarChar);

            comando.Parameters["@marca"].Value = vehiculo.marca;
            comando.Parameters["@modelo"].Value = vehiculo.modelo;
            comando.Parameters["@numPuertas"].Value = vehiculo.numPuertas;
            comando.Parameters["@color"].Value = vehiculo.color;
            comando.Parameters["@kilometros"].Value = vehiculo.kilometros;
            comando.Parameters["@tipoVehiculo"].Value = vehiculo.tipoVehiculo;
            comando.Parameters["@garantia"].Value = vehiculo.garantia;
            comando.Parameters["@stock"].Value = vehiculo.stock;
            comando.Parameters["@fotografia"].Value = vehiculo.fotografia;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Vehiculo> GetAll()
        {
            Conectar();
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            SqlCommand com = new SqlCommand("SELECT marca, modelo, numPuertas, color, kilometros, tipoVehiculo, garantia, stock, fotografia from dbo.vehiculos", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Vehiculo v = new Vehiculo
                {
                    marca = registros["marca"].ToString(),
                    modelo = registros["modelo"].ToString(),
                    numPuertas = int.Parse(registros["numPuertas"].ToString()),
                    color = registros["color"].ToString(),
                    kilometros = int.Parse(registros["kilometros"].ToString()),
                    tipoVehiculo = registros["tipoVehiculo"].ToString(),
                    garantia = int.Parse(registros["garantia"].ToString()),
                    stock = bool.Parse(registros["stock"].ToString()),
                    fotografia = registros["fotografia"].ToString()
                };
                vehiculos.Add(v);
            }
            con.Close();
            return vehiculos;
        }

        public Vehiculo GetVehiculo(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("SELECT marca, modelo, numPuertas, color, kilometros, tipoVehiculo, garantia, stock, fotografia " +
                "WHERE id = @id", con);

            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;

            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Vehiculo vehiculo = new Vehiculo();
            if (registros.Read())
            {
                vehiculo.marca = registros["codigo"].ToString();
                vehiculo.modelo = registros["modelo"].ToString();
                vehiculo.numPuertas = int.Parse(registros["numPuertas"].ToString());
                vehiculo.color = registros["color"].ToString();
                vehiculo.kilometros = int.Parse(registros["kilometros"].ToString());
                vehiculo.tipoVehiculo = registros["tipoVehiculo"].ToString();
                vehiculo.garantia = int.Parse(registros["garantia"].ToString());
                vehiculo.stock = bool.Parse(registros["stock"].ToString());
                vehiculo.fotografia = registros["fotografia"].ToString();
            }
            con.Close();
            return vehiculo;
        }

        public int Modificar(Vehiculo vehiculo)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("UPDATE dbo.vehiculos " +
                "SET marca = @marca, modelo = @modelo, numPuertas = @numPuertas, color = @color, kilometros = @kilometros, " +
                "tipoVehiculo = @tipoVehiculo, garantia = @garantia, stock = @stock, fotografia = @fotografia WHERE id = @id", con);

            comando.Parameters.Add("@id", SqlDbType.VarChar);
            comando.Parameters["@id"].Value = vehiculo.id;
            comando.Parameters.Add("@marca", SqlDbType.VarChar);
            comando.Parameters["@marca"].Value = vehiculo.marca;
            comando.Parameters.Add("@modelo", SqlDbType.VarChar);
            comando.Parameters["@modelo"].Value = vehiculo.modelo;
            comando.Parameters.Add("@numPuertas", SqlDbType.Int);
            comando.Parameters["@numPuertas"].Value = vehiculo.numPuertas;
            comando.Parameters.Add("@color", SqlDbType.VarChar);
            comando.Parameters["@color"].Value = vehiculo.color;
            comando.Parameters.Add("@kilometros", SqlDbType.Int);
            comando.Parameters["@kilometros"].Value = vehiculo.kilometros;
            comando.Parameters.Add("@tipoVehiculo", SqlDbType.VarChar);
            comando.Parameters["@tipoVehiculo"].Value = vehiculo.tipoVehiculo;
            comando.Parameters.Add("@garantia", SqlDbType.Int);
            comando.Parameters["@garantia"].Value = vehiculo.garantia;
            comando.Parameters.Add("@stock", SqlDbType.Bit);
            comando.Parameters["@stock"].Value = vehiculo.stock;
            comando.Parameters.Add("@fotografia", SqlDbType.VarChar);
            comando.Parameters["@fotografia"].Value = vehiculo.fotografia;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}