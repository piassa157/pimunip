using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace pimUnipAPI.Controllers
{
    [ApiController]
    [Route("/person")]
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
    

    [HttpPost]
    public IActionResult CreatePerson(Person person)
    {
        try
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Pessoa (NOME, CPF, ENDERECO_ID) VALUES (@Nome, @Cpf, @EnderecoId)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", person.Nome);
                    command.Parameters.AddWithValue("@Cpf", person.Cpf);
                    command.Parameters.AddWithValue("@EnderecoId", person.EnderecoId);

                    command.ExecuteNonQuery();
                }
            }

            return Ok("Person created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error creating person: {ex.Message}");
        }
    }


    [HttpPut("{id}")]
    public IActionResult UpdatePerson(int id, Person person)
    {
        try
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "UPDATE Pessoa SET ";

                if (!string.IsNullOrEmpty(person.Nome))
                {
                    query += "NOME = @Nome, ";
                }

                if (person.Cpf != null)
                {
                    query += "CPF = @Cpf, ";
                }

                if (person.EnderecoId != null)
                {
                    query += "ENDERECO_ID = @EnderecoId, ";
                }

                // Remove a vírgula extra no final da consulta
                query = query.TrimEnd(',', ' ');

                query += " WHERE ID = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", !string.IsNullOrEmpty(person.Nome) ? person.Nome : DBNull.Value);
                    command.Parameters.AddWithValue("@Cpf", person.Cpf != null ? person.Cpf : DBNull.Value);
                    command.Parameters.AddWithValue("@EnderecoId", person.EnderecoId != null ? person.EnderecoId : DBNull.Value);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }

            return Ok("Person updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error updating person: {ex.Message}");
        }
    }


        [HttpDelete("{id}")]
    public IActionResult DeletePerson(int id)
    {
        if (id == 0)
        {
            return BadRequest("Invalid ID");
        }

        try
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "DELETE FROM Pessoa WHERE ID = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }

            return Ok("Person deleted successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error deleting person: {ex.Message}");
        }
    }
    

        

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } // Remove the question mark (?)
        public string Nome {get; set;}
        public long Age { get; set; }
        public int EnderecoId { get; set; } // Add the missing property

        public long Cpf {get; set;}
    }   

}
}