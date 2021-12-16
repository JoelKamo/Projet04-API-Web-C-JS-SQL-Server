using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class Hotel
    {

        private string hotelname;
        private int hotelid;


        public Hotel(string HotelName)
        {
            this.hotelname = HotelName;
        }


        public string HotelName { get { return hotelname; } set { this.hotelname = value; } }
       
        public int HotelId { get { return hotelid; } set { this.hotelid = value; } }




        public override string ToString()
        {
            return $"id:{this.HotelId} Nom: {this.HotelName}";
        }


       
    }
}
