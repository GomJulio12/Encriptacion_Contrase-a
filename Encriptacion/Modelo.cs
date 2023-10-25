using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encriptacion
{
    class Modelo
    {
        public int registro (Usuarios usuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open ();

            string sql = "INSERT INTO USUARIO(nombre,usuario, password, id_tipo)" +
                "VALUES (@nombre,@usuario,@password, @id_tipo)";
            MySqlCommand comando = new MySqlCommand (sql, conexion);

            comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@usuario", usuario.Usuario);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.Parameters.AddWithValue("@id_tipo", 1);

            int resultado = comando.ExecuteNonQuery ();
            return resultado;

        }

        //Verificar que no haya usuarios duplicados 
        public bool existeUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id FROM USUARIO WHERE usuario like @usuario";
            MySqlCommand comando = new MySqlCommand (sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
