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
    public class BedroomController : ControllerBase
    {
        // Creation controleur Booking
       
        private readonly IConfiguration _configuration;
        public BedroomController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            // Liste tous les champs de la table 
            string query = @"
                        select BedroomId,NumChambre, HotelId from 
                        Bedroom
                        
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
        public JsonResult Post(Bedroom bedroom)
        {
            string query = @"
                        insert into Bedroom (NumChambre) values (@NumChambre);
                        insert into Bedroom (HotelId) values (@HotelId);
                       
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@NumChambre", bedroom.NumChambre);
                    myCommand.Parameters.AddWithValue("@HotelId", bedroom.HotelId);
               

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Bedroom bedroom)
        {
            string query = @"
                        update Bedroom set 
                        NumChambre =@NumChambre
                        HotelId =@HotelId
                        where BedroomId=@BedroomId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@BedroomId", bedroom.BedroomId);
                    myCommand.Parameters.AddWithValue("@NumChambre", bedroom.NumChambre);
                    myCommand.Parameters.AddWithValue("@HotelId", bedroom.HotelId);

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
                        delete from Bedroom 
                        where BedroomId=@BedroomId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@BedroomId", id);

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
