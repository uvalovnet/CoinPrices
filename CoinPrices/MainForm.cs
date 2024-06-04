using BinanceExchange;
using Entities.Interfaces;
using Entities.Models;
using ExchangeManager;
using static System.Collections.Specialized.BitVector32;

namespace CoinPrices
{
    public partial class MainForm : Form
    {
        IExchangeManager _exchangeManager;
        List<string> _coins;
        List<Label> _exchangeMonitor;
        CancellationToken _token;
        CancellationTokenSource _cancelTokenSource;

        public MainForm(IExchangeManager exchangeManager)
        {
            _exchangeManager = exchangeManager;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _coins = _exchangeManager.GetCoinsList().Result;
            FillMonitorList();
            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;
            FillSetCoin();
        }

        private void SetCoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cancelTokenSource.Cancel();

            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;

            var selectedItem = SetCoin.SelectedItem.ToString();
            if(selectedItem != null || selectedItem.Length > 3)
            {
                new Task(() => _exchangeManager.Subscribe(selectedItem, ChangePrices, _token)).Start();
            }
        }

        private async Task FillSetCoin()
        {
            SetCoin.DataSource = _coins;
        }

        //Регистрация контролов для вывода котировок !!!!ВАЖНА ПОСЛЕДОВАТЕЛЬНОСТЬ!!!!
        private async Task FillMonitorList()
        {
            _exchangeMonitor = new List<Label>()
            {
                BinancePrice,
                BybitPrice,
                BitgetPrice,
                KucoinPrice,
            };
        }

        //Вызывается из других потоков, выводит котировки
        private async Task ChangePrices(List<Coin> receivedData)
        {
            for(int i = 0; i < receivedData.Count; i++)
            {
                var label = _exchangeMonitor[i];
                var data = receivedData[i];
                BeginInvoke(() => label.Text = data.GetLastPrice().ToString());
            }
        }
    }
}
