using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class Bedroom
    {

        
        private int numchambre;
        private int bedroomid;


        public Bedroom(int NumChambre)
        {
            this.numchambre = NumChambre;
        }


        public int NumChambre { get { return numchambre; } set { this.numchambre = value; } }
        public int BedroomId { get { return bedroomid; } set { this.bedroomid = value; } }




        public override string ToString()
        {
            return $"id:{this.BedroomId} Numero: {this.NumChambre}";
        }


    }
}
