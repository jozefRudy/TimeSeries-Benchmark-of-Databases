using System;
using System.IO;
using System.Linq;
using StackExchange.Redis;
using csvReader;
using System.Text;
using System.Collections.Generic;

namespace RedisDatabase
{
    public class Redis
    {
        private IConnectionMultiplexer _connection { get; set; } = ConnectionMultiplexer.Connect("localhost:6379, allowAdmin=true");

        public Redis()
        {
            Flush();
        }

        public void Flush()
        {
            var server = _connection.GetServer("localhost:6379");
            server.FlushDatabase();
        }

        public void Write(string data, Stock stock)
        {
            var db = _connection.GetDatabase();
            var transaction = db.CreateTransaction();

            foreach (var stockDay in stock.Values)
            {
                var json = stockDay.ToString();
                transaction.SortedSetAddAsync(data, json, stockDay.Date.Ticks);
            }
            var committed = transaction.Execute();            
        }

        public void Read(string data)
        {
            var db = _connection.GetDatabase();
            var values = db.SortedSetRangeByScore(data);
            Stock stock = new Stock();
            foreach (var json in values)
            {
                string[] array = ((string)json).Split(',');
                var stockDay = new StockDay(array);
                stock.AddDay(stockDay);
            }
        }
    }
}
