using Entities.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeManager
{
    public class ExchangeManager : IExchangeManager
    {
        List<IExchange> _exchanges;
        List<List<string>> _exchangeTickets;

        //Список содержащий потокобезопасные сущности используемы несколькими потоками
        List<Coin> _prices;

        public ExchangeManager(List<IExchange> exchanges)
        {
            _exchanges = exchanges;
            _exchangeTickets = new List<List<string>>();
        }

        //Возвращает только токены присутствующие на всех зарегистрированных биржах
        public async Task<List<string>> GetCoinsList()
        {
            var ticketsList = new List<string>();
            foreach(var ex in _exchanges)
            {
                _exchangeTickets.Add(await ex.GetCoinsList());
            }

            foreach(var ticket in _exchangeTickets[0])
            {
                bool isTicketExistInAllExchanges = true;
                foreach(var ex in _exchangeTickets)
                {
                    if(!ex.Exists(x => x == ticket)) { isTicketExistInAllExchanges = false;}
                }
                if (isTicketExistInAllExchanges)
                {
                    ticketsList.Add(ticket);
                }
            }

            return ticketsList;
        }

        //Запускаем таски, которые через сокеты обновляют общие сущности в списке _prices
        public async Task Subscribe(string name, Func<List<Coin>, Task> callBack, CancellationToken token)
        {
            _prices = new List<Coin>();
            for (int i = 0; i < _exchanges.Count; i++)
            {
                _prices.Add(new Coin() { Name = name });
                var ex = _exchanges[i];
                var price = _prices[i];
                new Task(() => ex.Subscribe(price, token)).Start();
            }
            Monitor(callBack, token);
        }

        //Каждые 5 секунд проверяет список с общими сущностями и вызывает обновление контролов
        private async Task Monitor(Func<List<Coin>, Task> callBack, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if(_prices.All(x => x.GetLastPrice() != null))
                {
                    callBack.Invoke(_prices);
                    await Task.Delay(5000);
                }
            }
        }
    }
}
