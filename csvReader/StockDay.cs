using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csvReader
{
    public class StockDay
    {
        public DateTime Date;
        public float Open;
        public float High;
        public float Low;
        public float Close;
        public float Daco;
        public float Volume;

        public StockDay(string[] data)
        {
            if (data == null || data.Length != 8) return;

            DateTime.TryParse(data[1], out Date);
            float.TryParse(data[2], out Open);
            float.TryParse(data[3], out High);
            float.TryParse(data[4], out Low);
            float.TryParse(data[5], out Close);
            float.TryParse(data[6], out Daco);
            float.TryParse(data[7], out Volume);
        }

        public StockDay()
        { }
    }
}
