using System;
using System.IO;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        Thread.Sleep(10000);
        string connectionString = "Server=mysql-db;Database=mydb;User=root;Password=rootpassword;";

        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful!");

                string seedSql = File.ReadAllText("seed.sql");

                using (var command = new MySqlCommand(seedSql, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database seeded successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
