using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class Booking
    {
        //Creation des classes associe au table 
        private int bookingid;
        private int hotelid;
        private int bedroomid;
        private string statut;
        private double prixnuits;
        private int nbrenuits;
        private int clientid;


        public Booking(string Statut, double prixParNuits, int nbreNuits, int ClientId)
        {
            this.statut = Statut;
            this.prixnuits = prixParNuits;
            this.nbrenuits = nbreNuits;
            this.clientid = ClientId;
        }


        public string Statut { get { return statut; } set { this.statut = value; } }
        public double prixParNuits { get { return prixnuits; } set { this.prixnuits = value; } }
        public int nbreNuits { get { return nbreNuits; } set { this.nbreNuits = value; } }
        public int ClientId { get { return clientid; } set { this.clientid = value; } }
        public int BookingId { get { return bookingid; } set { this.bookingid = value; } }
        public int HotelId { get { return hotelid; } set { this.hotelid = value; } }
        public int BedroomId { get { return bedroomid; } set { this.bedroomid = value; } }

     


        public override string ToString()
        {
            return $"id:{this.BookingId} {this.HotelId} {this.BedroomId} Statut: {this.Statut}, Prix par nuit: {this.prixParNuits}, Nombre De Nuits: {this.nbreNuits}, Id Client: {this.ClientId}";
        }

    }
}
