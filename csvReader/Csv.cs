using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvReader
{
    public class Csv
    {
        public Stock stock;

        public Csv()
        {
            stock = new Stock();
        }

        public void ReadCsv(string name)
        {
            var stream = new StreamReader(name);
            string line;

            while ((line = stream.ReadLine()) != null)
            {
                var data = line.Split(',');
                var parsedLine = new StockDay(data);
                stock.AddDay(parsedLine);
            }
            stream.Close();
        }
    }
}
