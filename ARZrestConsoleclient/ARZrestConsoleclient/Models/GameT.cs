using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARZrestConsoleclient.Models
{
    public class GameT
    {
        public int IDGame { get; set; }
        public int IDPlayer { get; set; }
        public string Timestamp { get; set; }
        public double Score { get; set; }
        public double Kills { get; set; }
        public double Headshots { get; set; }
        public double Accuracy { get; set; }

        public object GamesT_ { get; set; }
    }
}
