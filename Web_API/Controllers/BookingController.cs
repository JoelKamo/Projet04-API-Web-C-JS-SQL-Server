using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;
namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public BookingController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select BookingId,HotelId,BedroomId,
                        Statut, prixParNuits, nbreNuits, ClientId
                        from 
                        Booking
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
        public JsonResult Post(Booking booking)
        {
            // Liste tous les champs de la table 
            string query = @"
                        insert into Booking 
                        (Statut,prixParNuits,nbreNuits,ClientId) 
                        values
                         (@Statut,@prixParNuits,@nbreNuits,@ClientId) ;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Statut", booking.Statut);
                    myCommand.Parameters.AddWithValue("@prixParNuits", booking.prixParNuits);
                    myCommand.Parameters.AddWithValue("@nbreNuits", booking.nbreNuits);
                    myCommand.Parameters.AddWithValue("@ClientId", booking.ClientId);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Booking booking)
        {
            string query = @"
                        update Booking set 
                        Statut =@Statut,
                        prixParNuits =@prixParNuits,
                        nbreNuits =@nbreNuits,
                        ClientId =@ClientId
                        where BookingId=@BookingId && HotelId=@HotelId && BedroomId=@BedroomId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@BookingId", booking.BookingId);
                    myCommand.Parameters.AddWithValue("@HotelId", booking.HotelId);
                    myCommand.Parameters.AddWithValue("@BedroomId", booking.BedroomId);
                    myCommand.Parameters.AddWithValue("@Statut", booking.Statut);
                    myCommand.Parameters.AddWithValue("@prixParNuits", booking.prixParNuits);
                    myCommand.Parameters.AddWithValue("@nbreNuits", booking.nbreNuits);
                    myCommand.Parameters.AddWithValue("@ClientId", booking.ClientId);

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
                        delete from Booking 
                       where BookingId=@BookingId && HotelId=@HotelId && BedroomId=@BedroomId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookingConnection");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@BookingId, @HotelId, @BedroomId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {

                var httpReuest = Request.Form;
                var postedFile = httpReuest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("IN.png");
            }
        }
    }
}
