using System;
using System.Configuration;
using System.Threading;
using nj4x;
using nj4x.Metatrader;

namespace nj4x_p1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create strategy
            var mt4 = new Strategy();
            // Connect to the Terminal Server
            mt4.Connect(
            ConfigurationManager.AppSettings["terminal_host"],
            int.Parse(ConfigurationManager.AppSettings["terminal_port"]),
            new Broker(ConfigurationManager.AppSettings["broker"]),
            ConfigurationManager.AppSettings["account"],
            ConfigurationManager.AppSettings["password"]
            );
            // Use API methods …

            Console.WriteLine($"Account {mt4.AccountNumber()}");
            Console.WriteLine($"Equity {mt4.AccountEquity()}");
            Thread.Sleep(3000);
            Console.Clear();
            var Total = mt4.OrdersTotal();
            var Total_tmp = Total;
            //IOrderInfo Order_info = mt4.OrderGet(15328321, SelectionType.SELECT_BY_TICKET, SelectionPool.MODE_TRADES);
            IOrderInfo Order_info = mt4.OrderGet(6, SelectionType.SELECT_BY_POS, SelectionPool.MODE_TRADES);
            var open_Price = Order_info.GetOpenPrice();
            Console.WriteLine($"Ticket ID :{Order_info.GetTicket()} . Open Price :{open_Price}");
            //while (true)
            //{
            //    //Console.WriteLine($"{Total}");
            //    if()
            //}

            //while (true)
            //{
            //    double bid = mt4.Marketinfo("AUDCAD-STD", MarketInfo.MODE_BID);
            //    Console.WriteLine($"AUDCAD-STD bid={bid}");
            //    Thread.Sleep(50);
            //    Console.Clear();
            //}
            //double bid = mt4.Marketinfo("AUDCAD-STD", MarketInfo.MODE_BID);
            //try
            //{
            //    var ticket = mt4.OrderSend("AUDCAD-STD", 
            //        TradeOperation.OP_SELL, 
            //        0.01, bid, 2, 0, 0, 
            //        "Order_Sell_Demo", 0, 
            //        MT4.NoExpiration
            //        );
            //    Console.WriteLine($"New Sell_Order ID: {ticket}");
            //}
            //catch (MT4Exception e)
            //{
            //    Console.WriteLine($"Order Placing Error #{e.ErrorCode}:{e.Message}");
            //}
            //try
            //{
            //    var ticket = mt4.OrderSend("AUDCAD-STD",
            //        TradeOperation.OP_BUY,
            //        0.01, bid, 2, 0, 0,
            //        "Order_Sell_Demo", 0,
            //        MT4.NoExpiration
            //        );
            //    Console.WriteLine($"New Buy_Order ID: {ticket}");
            //}
            //catch (MT4Exception e)
            //{
            //    Console.WriteLine($"Order Placing Error #{e.ErrorCode}:{e.Message}");
            //}


            //
            Console.ReadLine();
        }
    }
}