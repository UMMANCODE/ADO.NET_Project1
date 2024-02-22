using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp40 {
    internal static class BrandServer {

        const string ConnectionString = "Server=DELL-UMMAN\\SQLEXPRESS;Database=Worklife;Trusted_Connection=true;";
        public static void CreateBrand(string? name, DateTime? year) {
            Brand? brand = new(name, year);
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            string? query = "INSERT INTO Brands (Name, Year) VALUES (@name, @year)";
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@year", year);
            command.ExecuteNonQuery();
        }

        public static void DeleteBrandById(int id) {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            string? query = "DELETE FROM Brands WHERE Id=@id";
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public static Brand? GetBrandById(int id) {
            Brand? brand = null;
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            string? query = "SELECT * FROM Brands WHERE Id=@id";
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                brand = new Brand() {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Year = reader.GetDateTime(2)
                };
            return brand;
        }

        public static List<Brand?>? GetAllBrands() {
            List<Brand?>? brands = new List<Brand?>();
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            string query = "SELECT Id, Name, Year FROM Brands";
            using SqlCommand command = new(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                DateTime? year = reader.IsDBNull(2) ? null : reader.GetDateTime(2);
                brands.Add(new Brand() {
                    Id = id,
                    Name = name,
                    Year = year
                });
            }
            return brands;
        }


        public static void UpdateBrandById(int id, string? newName, DateTime? newYear) {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            string? query = "UPDATE Brands SET Name=@newName, Year=@newYear WHERE Id=@id";
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@newName", newName);
            command.Parameters.AddWithValue("@newYear", newYear);
            command.ExecuteNonQuery();
        }
    }
}
