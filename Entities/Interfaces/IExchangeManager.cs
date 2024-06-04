using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IExchangeManager
    {

        Task Subscribe(string name, Func<List<Coin>, Task>  callBack, CancellationToken token);
        Task<List<string>> GetCoinsList();
    }
}
