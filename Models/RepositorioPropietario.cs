using System.Data.SqlClient;

namespace Inmobiliaria.Models
{
    public class RepositorioPropietario
    {
        string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Inmobiliaria;Trusted_Connection=true;MultipleActiveResultSets=true";

        public RepositorioPropietario()
        {

        }

        public IList<Propietario> obtenerTodos()
        {
            var res = new List<Propietario>();
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Nombre,Apellido,Telefono,Email,Dni
                        FROM Propietarios;";
             using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        var p = new Propietario
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Telefono = reader.GetString(3),
                            Email = reader.GetString(4),
                            //Dni = reader.GetString(5),
                        };
                        res.Add(p);
                    }
                    conn.Close();
                }
                return res;
            }
            
        }

        public int Alta(Propietario p)
        {
            var res = -1;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sql = @"INSERT INTO Propietarios (Nombre,Apellido,Telefono,Email,Dni)
                               VALUES(@{nameof(p.nombre)},@{nameof(p.apellido)},@{nameof(p.telefono)},@{nameof(p.email)},@{nameof(p.dni)});";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue($"@{nameof(p.Nombre)}", p.Nombre);
                    comm.Parameters.AddWithValue($"@{nameof(p.Apellido)}", p.Apellido);
                    comm.Parameters.AddWithValue($"@{nameof(p.Telefono)}", p.Telefono);
                    comm.Parameters.AddWithValue($"@{nameof(p.Email)}", p.Email);
                    comm.Parameters.AddWithValue($"@{nameof(p.Dni)}", p.Dni);
                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    p.Id = res;
                }
            }
            return res;
        }
    }
}
