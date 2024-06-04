using Bybit.Net.Clients;
using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BybitExchange
{
    public class BybitAPI : IExchange
    {
        BybitSocketClient _socketClient;
        public BybitAPI()
        {
            _socketClient = new BybitSocketClient();
        }

        public async Task Subscribe(Coin currentCoin, CancellationToken token)
        {
            var subscription = await _socketClient.V5SpotApi.SubscribeToTickerUpdatesAsync(currentCoin.Name, update =>
            {
                currentCoin.SetLastPrice(update.Data.LastPrice);
            },
            token);
        }

        public async Task<List<string>> GetCoinsList()
        {
            var tickets = new List<string>();
            using (var client = new BybitRestClient())
            {
                var exchangeTickets = client.V5Api.ExchangeData.GetSpotSymbolsAsync().Result.Data.List;
                foreach (var ticket in exchangeTickets)
                {
                    tickets.Add(ticket.Name);
                }
            }
            return tickets;
        }
    }
}
