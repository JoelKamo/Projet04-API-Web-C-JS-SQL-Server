using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        // Creation controleur Booking

        private readonly IConfiguration _configuration;
        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()

        {
            
            // Liste tous les champs de la table 
            string query = @"
                        select ClientId,Name, Gender, Email from 
                        Client
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(Client client)
        {
            string query = @"
                        insert into Client (Name) values (@Name);
                        insert into Client (Gender) values (@Gender);
                        insert into Client (Email) values (@Email);
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Name", client.Name);
                    myCommand.Parameters.AddWithValue("@Gender", client.Gender);
                    myCommand.Parameters.AddWithValue("@Email", client.Email);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Client client)
        {
            string query = @"
                        update Client set 
                        Name =@Name
                        Gender =@Gender
                        Email =@Email
                        where ClientId=@ClientId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ClientId", client.ClientId);
                    myCommand.Parameters.AddWithValue("@Name", client.Name);
                    myCommand.Parameters.AddWithValue("@Gender", client.Gender);
                    myCommand.Parameters.AddWithValue("@Email", client.Email);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }



        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from Client 
                        where ClientId=@ClientId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@ClientId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

    }
}
