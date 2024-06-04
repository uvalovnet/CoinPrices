using Binance.Net.Clients;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanceExchange
{
    public class BinanceAPI : IExchange
    {
        BinanceSocketClient _socketClient;
        public BinanceAPI()
        {
            _socketClient = new BinanceSocketClient();
        }

        public async Task Subscribe(Coin currentCoin, CancellationToken token)
        {
            var subscription = await _socketClient.SpotApi.ExchangeData.SubscribeToTradeUpdatesAsync(currentCoin.Name, data =>
            {
                currentCoin.SetLastPrice(data.Data.Price);
            },
            token);
        }

        public async Task<List<string>> GetCoinsList()
        {
            var tickets = new List<string>();
            using (var client = new BinanceRestClient())
            {
                var exchangeTickets = client.SpotApi.ExchangeData.GetExchangeInfoAsync().Result.Data.Symbols;
                foreach(var ticket in exchangeTickets)
                {
                    tickets.Add(ticket.Name);
                }
                return tickets;
            }
        }
    }
}
