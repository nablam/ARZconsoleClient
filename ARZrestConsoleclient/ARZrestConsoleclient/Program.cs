using ARZrestConsoleclient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARZrestConsoleclient
{
    class Program
    {
        static void Main(string[] args)
        {
            RESTERSHARPER r = new RESTERSHARPER(); ;
             r.ADD_GAMEttoplayer(58);
          //  Console.WriteLine(  r.GettheMaxGameID());
      
        }
    }
}
