using Entities.Interfaces;
using Entities.Models;
using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KucoinExchange
{
    public class KucoinAPI : IExchange
    {
        KucoinSocketClient _socketClient;
        public KucoinAPI()
        {
            _socketClient = new KucoinSocketClient();
        }

        public async Task Subscribe(Coin currentCoin, CancellationToken token)
        {
            var ticketName = "";
            if (currentCoin.Name.IndexOf("BTC") > 0) { ticketName = currentCoin.Name.Replace("BTC", "-BTC"); }
            else if (currentCoin.Name.IndexOf("ETH") > 0) { ticketName = currentCoin.Name.Replace("ETH", "-ETH"); }
            else if (currentCoin.Name.IndexOf("USDT") > 0) { ticketName = currentCoin.Name.Replace("USDT", "-USDT"); }
            else if (currentCoin.Name.IndexOf("USDC") > 0) { ticketName = currentCoin.Name.Replace("USDC", "-USDC"); }
            var subscription = await _socketClient.SpotApi.SubscribeToTickerUpdatesAsync(ticketName, update =>
            {
               currentCoin.SetLastPrice(update.Data.LastPrice);              
            },
            token);
        }
        public async Task<List<string>> GetCoinsList()
        {
            var tickets = new List<string>();
            using (var client = new KucoinRestClient())
            {
                var exchangeTickets = client.SpotApi.ExchangeData.GetTickersAsync().Result.Data.Data;
                foreach (var ticket in exchangeTickets)
                {
                    tickets.Add(ticket.SymbolName.Replace("-", ""));
                }
            }
            return tickets;
        }
    }
}
