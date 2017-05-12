using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARZrestConsoleclient.Models
{
    public class PlayerT
    {
        public List<GameT> GamesT_ { get; set; }
        public int IDPlayer { get; set; }
        public string SignupDate { get; set; }
        public string Email_Address { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PlayerT() { this.GamesT_ = new List<GameT>(); }

    }
}
