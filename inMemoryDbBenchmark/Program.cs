using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csvReader;
using RedisDatabase;

namespace inMemoryDbBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvReader = new Csv();
            csvReader.ReadCsv("source.csv");

            var redis = new Redis();

            var watch = Stopwatch.StartNew();
            redis.Write("test", csvReader.stock);
            watch.Stop();
            Console.WriteLine("Write in secs: " +watch.Elapsed.TotalSeconds);

            watch.Restart();
            redis.Read("test");
            watch.Stop();
            Console.WriteLine("Read in secs: " + watch.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
    }
}
