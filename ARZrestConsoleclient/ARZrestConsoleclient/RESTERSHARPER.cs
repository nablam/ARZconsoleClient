using ARZrestConsoleclient.Models;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARZrestConsoleclient
{
    public class RESTERSHARPER
    {

        //must implement the add game to player in services too
        public void ADD_GAMEttoplayer(int pid) {
            int newGameid = GettheMaxGameID() + 1;
            DateTime DT = DateTime.Now.AddHours(0);

            GameT g = new GameT();
            g.Accuracy = 50.0;
            g.Headshots = 120;
            g.IDPlayer = pid;
            g.IDGame = newGameid;
            g.Kills = 100;
            g.Score = 1337;
            g.Timestamp = DT.ToString();

            //RestClient restClient = new RestClient("http://24.61.47.62:1337");
            RestClient restClient = new RestClient("http://localhost:57759");
            string postit = "/Api/ARZAPIctrl/AddGameToPlayerID"+"/"+pid;


            var request = new RestRequest(postit, Method.POST);
            request.AddJsonBody(g);
            IRestResponse Ires = restClient.Execute(request);

            if (Ires.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //now the new max is TRIPid .. I should make a slef update function in MNGR 
                Console.WriteLine("gamesent sent");
            }



        }

        public int GettheMaxPlayerID() {
           // RestClient restClient = new RestClient("http://24.61.47.62:1337");
            RestClient restClient = new RestClient("http://localhost:57759");
            string getit = "/Api/ARZAPIctrl/MaxPlayerID";
            var request = new RestRequest(getit, Method.GET);
            IRestResponse responseRaw = restClient.Execute(request);
            JsonDeserializer deserial = new JsonDeserializer();
            int maxPid = deserial.Deserialize<int>(responseRaw);

            return maxPid;
            
        }

        public int GettheMaxGameID() {
            // RestClient restClient = new RestClient("http://24.61.47.62:1337");
            RestClient restClient = new RestClient("http://localhost:57759");
            string getit = "/Api/ARZAPIctrl/MaxGameID";
            var request = new RestRequest(getit, Method.GET);
            IRestResponse responseRaw = restClient.Execute(request);
            JsonDeserializer deserial = new JsonDeserializer();
            int maxGid = deserial.Deserialize<int>(responseRaw);

            return maxGid;
        }

        public void ADD__PLAYER(string str)
        {
            //RestClient restClient = new RestClient("http://24.61.47.62:1337");
            RestClient restClient = new RestClient("http://localhost:57759");
            string postit = "/Api/ARZAPIctrl/AddPlayer";  
            //get the maxID of curent trips. It should already be in MNGR
            int MAXID = GettheMaxPlayerID(); ///////////////////////////////////////////////////////////////////////////////////////////////////TODO get maxid
            int PlayerId = MAXID + 1;


            //get date time
            DateTime DT = DateTime.Now.AddHours(0);

            //make a trip to send to SQL and another to add to MNGR just to compare;
            PlayerT PlayerForSQL = new PlayerT();

            PlayerForSQL.IDPlayer = PlayerId;
            PlayerForSQL.FirstName = str+"bob";

            PlayerForSQL.LastName = str + "bobobo";
            PlayerForSQL.UserName = str + "BBOB";
            PlayerForSQL.Email_Address = str + "bob@bob.com";
            PlayerForSQL.SignupDate = DT.ToString();


  

            var request = new RestRequest(postit, Method.POST);
            request.AddJsonBody(PlayerForSQL);
            IRestResponse Ires = restClient.Execute(request);

            if (Ires.StatusCode == System.Net.HttpStatusCode.OK)
            {
              //now the new max is TRIPid .. I should make a slef update function in MNGR 
                Console.WriteLine(  "bob sent");
            }

        }


        public void SHOWallEmails()
        {
            //http://localhost:57759/Api/ARZAPIctrl/GetAllPlayers
            RestClient restClient = new RestClient("http://24.61.47.62:1337");
            //RestClient restClient = new RestClient("http://localhost:57759");
            //restClient.Authenticator = new HttpBasicAuthenticator("nablam", "pass123");
            //Api/ARZAPIctrl/GetPlayerAccountsansTopScore

            string getit = "/Api/ARZAPIctrl/GetAllPlayers";
            var request = new RestRequest(getit, Method.GET);
            IRestResponse responseRaw = restClient.Execute(request);
            JsonDeserializer deserial = new JsonDeserializer();
            List<PlayerT> AllPlayers = deserial.Deserialize<List<PlayerT>>(responseRaw);

            foreach (PlayerT t in AllPlayers)
                Console.WriteLine(t.Email_Address + "\n");


        }


        public void Shwaccounts()
        {
            //http://localhost:57759/Api/ARZAPIctrl/GetAllPlayers
              RestClient restClient = new RestClient("http://24.61.47.62:1337");
            //RestClient restClient = new RestClient("http://localhost:57759");
            //restClient.Authenticator = new HttpBasicAuthenticator("nablam", "pass123");
            //Api/ARZAPIctrl/GetPlayerAccountsansTopScore

            string getit = "/Api/ARZAPIctrl/GetPlayerAccountsansTopScore";
            var request = new RestRequest(getit, Method.GET);
            IRestResponse responseRaw = restClient.Execute(request);
            JsonDeserializer deserial = new JsonDeserializer();
            List<paccount> AllPlayers = deserial.Deserialize<List<paccount>>(responseRaw);

            foreach (paccount t in AllPlayers)
                Console.WriteLine(t.UserFirstName + "\n");
            
        }
    }
}