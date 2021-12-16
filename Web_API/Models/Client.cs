using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class Client
    {

        private string name;
        private int clientid;
        private Char gender;
        private string email;


        public Client(string Name, Char Gender, string Email)
        {
            this.name = Name;
            this.gender = Gender;
            this.email = Email;
        }


        public string Name { get { return name; } set { this.name = value; } }
        public Char Gender { get { return gender; } set { this.gender = value; } }
        public string Email { get { return email; } set { this.email = value; } }

        public int ClientId { get { return clientid; } set { this.clientid = value; } }




        public override string ToString()
        {
            return $"id:{this.ClientId} Nom: {this.Name}, Genre: {this.Gender}, Courriel: {this.Email}";
        }


    }
}
