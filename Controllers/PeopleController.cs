using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace pimUnipAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly string? _connectionString;
        private string connectionString = "server=localhost;port=3306;user=admin;password=admin;database=peoples";

        public PeopleController()
        {
            _connectionString = connectionString;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Person> people = new List<Person>();

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Pessoa";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetValue("Id"));
                            int id = (int) reader.GetValue("Id");
                            Console.WriteLine(id);
                            string name = (string) reader.GetValue("Nome");
                            long age = (long) reader.GetValue("CPF");

                            Person person = new Person
                            {
                                Id = id,
                                Name = name,
                                Age = age
                            };

                            people.Add(person);
                        }
                    }
                }

                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter as pessoas cadastradas: {ex.Message}");
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public long Age { get; set; }
    }
}
