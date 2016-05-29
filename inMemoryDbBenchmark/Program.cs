using System;
using System.IO;
using System.Reflection;
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
            var basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\"));
            var redisPath = Path.Combine(basePath, "packages\\redis-64.3.0.501\\tools\\redis-server.exe");
            var redisProcess = Process.Start(redisPath);
            
            var redis = new Redis();
                       
            var watch = Stopwatch.StartNew();
            redis.Write("test", csvReader.stock);
            watch.Stop();
            Console.WriteLine("Write in secs: " +watch.Elapsed.TotalSeconds);

            watch.Restart();
            redis.Read("test");
            watch.Stop();
            Console.WriteLine("Read in secs: " + watch.Elapsed.TotalSeconds);

            redisProcess.Kill();          
        }
    }
}
