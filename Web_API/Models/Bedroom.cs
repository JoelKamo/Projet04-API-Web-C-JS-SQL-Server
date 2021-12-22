using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class Bedroom
    {

        //Creation des classes associe au table 
        
        private int numchambre;
        private int bedroomid;
        private int hotelid;


        public Bedroom(int NumChambre, int HotelId)
        {
            this.numchambre = NumChambre;
            this.hotelid = HotelId;
        }


        public int NumChambre { get { return numchambre; } set { this.numchambre = value; } }
        public int BedroomId { get { return bedroomid; } set { this.bedroomid = value; } }
        public int HotelId { get { return hotelid; } set { this.hotelid = value; } }




        public override string ToString()
        {
            return $"id:{this.BedroomId} Numero: {this.NumChambre}, Numero Hotel: {this.HotelId}";
        }


    }
}
