using StackExchange.Redis;
using csvReader;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace RedisDatabase
{
    public class Redis
    {
        private IConnectionMultiplexer _connection { get; set; } = ConnectionMultiplexer.Connect("localhost:6379, allowAdmin=true");

        public Redis()
        {
            var server = _connection.GetServer("localhost:6379");
            server.FlushDatabase();
        }

        public void Write(string data, Stock stock)
        {
            var db = _connection.GetDatabase();
            foreach (var stockDay in stock.Values)
            {
                var json = JsonConvert.SerializeObject(stockDay);
                db.SortedSetAdd(data, json, stockDay.Date.Ticks);          
            }
        }

        public void Read(string data)
        {
            var db = _connection.GetDatabase();
            var values = db.SortedSetRangeByScore(data);
            Stock stock = new Stock();
            
            foreach (var json in values)
            {
                var stockDay = JsonConvert.DeserializeObject<StockDay>(json);                
                stock.AddDay(stockDay);
            }
        }
    }
}
