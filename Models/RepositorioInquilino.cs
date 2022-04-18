using System.Data.SqlClient;

namespace Inmobiliaria.Models
{
    public class RepositorioInquilino
    {

        string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Inmobiliaria;Trusted_Connection=true;MultipleActiveResultSets=true";

        public RepositorioInquilino()
        {

        }
        public IList<Inquilino> obtenerTodos()
        {
            var res = new List<Inquilino>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id,Nombre,Apellido,lugarTrabajo,Telefono,Email,Dni
                        FROM Inquilinos;"; 
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        var i = new Inquilino
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            lugarTrabajo = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            Email = reader.GetString(5),
                            Dni = reader.GetString(6),
                        };
                        res.Add(i);
                    }
                    conn.Close();
                }
                return res;
            }

        }
              
            public int Alta(Inquilino i)
        {
            var res = -1;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string sql = @"INSERT INTO Inquilinos (Nombre,Apellido, lugarTrabajo, Telefono,Email,Dni)
                               VALUES(@{nameof(i.nombre)},@{nameof(i.apellido)},@{nameof(i.lugarTrabajo)},@{nameof(i.telefono)},@{nameof(i.email)},@{nameof(i.dni)});";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue($"@{nameof(i.Nombre)}", i.Nombre);
                    comm.Parameters.AddWithValue($"@{nameof(i.Apellido)}", i.Apellido);
                    comm.Parameters.AddWithValue($"@{nameof(i.lugarTrabajo)}", i.lugarTrabajo);
                    comm.Parameters.AddWithValue($"@{nameof(i.Telefono)}", i.Telefono);
                    comm.Parameters.AddWithValue($"@{nameof(i.Email)}", i.Email);
                    comm.Parameters.AddWithValue($"@{nameof(i.Dni)}", i.Dni);
                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    i.Id = res;
                }
            }
            return res;
        }
    }
}



