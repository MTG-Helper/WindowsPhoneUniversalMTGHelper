using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace WindowsUniversalMTGHelper.Model.extras
{
    class Stats
    {
       
        public int quantityDownloadedCardsImages = 0;
        public int one = 0;
        public int two = 0;
        public int three = 0;
        public int four = 0;
        public int five = 0;
        public int six = 0;
        public int quantityDuelsPerOpen = 0;
        public int quantityUsedDice = 0;
        public int quantityPoisonVictories = 0;
        public int quantityDuels = 0;
        public int quantitySearchedCards = 0;
        public int quantityUsedCoin = 0;
        public int quantityLifeVictories = 0;
       

        public async void Post()
        {
            if (HasInternetConnection())
            {
                Uri requestUri = new Uri("http://localhost:9000/stats"); //replace your Url  
                dynamic dynamicJson = new ExpandoObject();
                
                dynamicJson.quantitySearchedCards = quantitySearchedCards;
                dynamicJson.quantityUsedDice = quantityUsedDice;
                dynamicJson.quantityUsedCoin = quantityUsedCoin;

                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicJson);
                var objClint = new HttpClient();
                HttpResponseMessage respon = await objClint.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                string responJsonText = await respon.Content.ReadAsStringAsync();
            }
            
        }

        internal static bool HasInternetConnection()
        {
            var connections = NetworkInformation.GetConnectionProfiles().ToList();
            connections.Add(NetworkInformation.GetInternetConnectionProfile());

            foreach (var connection in connections)
            {
                if (connection == null)
                    continue;

                if (connection.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                    return true;
            }

            return false;
        }

        internal void Coin()
        {
            quantityUsedCoin++;
        }

        internal void Dice()
        {
            quantityUsedDice++;
        }

        internal void Reset()
        {
        quantityDownloadedCardsImages = 0;
        one = 0;
        two = 0;
        three = 0;
        four = 0;
        five = 0;
        six = 0;
        quantityDuelsPerOpen = 0;
        quantityUsedDice = 0;
        quantityPoisonVictories = 0;
        quantityDuels = 0;
        quantitySearchedCards = 0;
        quantityUsedCoin = 0;
        quantityLifeVictories = 0;
    }

        internal void SearchedCard()
        {
            quantitySearchedCards++;
        }
    }
}
