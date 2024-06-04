using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Coin
    {
        public string? Name;
        private decimal? LastPrice;
        private object? _lock;

        public Coin()
        {
            _lock = new object();
        }

        public void SetLastPrice(decimal? price)
        {
            lock (_lock)
            {
                LastPrice = price;
            }
        }

        public decimal? GetLastPrice()
        {
            lock (_lock)
            {
                return LastPrice;
            }
        }
    }
}
