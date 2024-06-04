using Autofac;
using BinanceExchange;
using BitgetExchange;
using BybitExchange;
using Entities.Interfaces;
using KucoinExchange;
using ExManager = ExchangeManager.ExchangeManager;

namespace CoinPrices
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();

            //������ ������ ������� ������������ ����
            //!!!!����� ������������������!!!!
            var exchanges = new List<IExchange>
            {
                new BinanceAPI(),
                new BybitAPI(),
                new BitgetAPI(),
                new KucoinAPI()
            };

            //������������ ��������� � ���������� � ������� ��� ������ ������� ����
            builder.RegisterType<ExManager>().As<IExchangeManager>().SingleInstance().WithParameter("exchanges", exchanges);

            var container = builder.Build();
            var service = container.Resolve<IExchangeManager>();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(service));
        }
    }
}