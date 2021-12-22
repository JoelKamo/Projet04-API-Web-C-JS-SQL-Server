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
    public class HotelController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HotelController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            // Liste tous les champs de la table 
            string query = @"
                        select HotelId,HotelName from 
                        Hotel
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
        public JsonResult Post(Hotel otel)
        {
            string query = @"
                        insert into Hotel (HotelName) values
                                                    (@HotelName);
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@HotelName", otel.HotelName);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Hotel otel)
        {
            string query = @"
                        update Hotel set 
                        HotelName =@HotelName
                        where HotelId=@HotelId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@HotelId", otel.HotelId);
                    myCommand.Parameters.AddWithValue("@HotelName", otel.HotelName);

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
                        delete from Hotel 
                        where HotelId=@HotelId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@HotelId", id);

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
