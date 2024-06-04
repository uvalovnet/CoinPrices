using Bitget.Net.Clients;
using CryptoExchange.Net.Interfaces;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BitgetExchange
{
    public class BitgetAPI : IExchange
    {
        BitgetSocketClient _socketClient;

        public BitgetAPI()
        {
            _socketClient = new BitgetSocketClient();
        }
        public async Task Subscribe(Coin currentCoin, CancellationToken token)
        {
            var subscription = await _socketClient.SpotApi.SubscribeToTickerUpdatesAsync(currentCoin.Name, update =>
            {
                currentCoin.SetLastPrice(update.Data.LastPrice);
            },
            token);
        }

        public async Task<List<string>> GetCoinsList()
        {
            var tickets = new List<string>();
            using (var client = new BitgetRestClient())
            {
                var exchangeTickets = client.SpotApi.ExchangeData.GetTickersAsync().Result.Data;
                foreach (var ticket in exchangeTickets)
                {
                    tickets.Add(ticket.Symbol);
                }
            }
            return tickets;
        }
    }
}
