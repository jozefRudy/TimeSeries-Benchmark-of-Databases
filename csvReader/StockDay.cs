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
            if (data == null || data.Length != 7) return;

            DateTime.TryParse(data[0], out Date);
            float.TryParse(data[1], out Open);
            float.TryParse(data[2], out High);
            float.TryParse(data[3], out Low);
            float.TryParse(data[4], out Close);
            float.TryParse(data[5], out Daco);
            float.TryParse(data[6], out Volume);
        }

        public StockDay()
        { }

        public override string ToString()
        {            
            StringBuilder builder = new StringBuilder();            
            builder.Append(Date);
            builder.Append(',');
            builder.Append(Open);
            builder.Append(',');
            builder.Append(High);
            builder.Append(',');
            builder.Append(Low);
            builder.Append(',');
            builder.Append(Close);
            builder.Append(',');
            builder.Append(Daco);
            builder.Append(',');
            builder.Append(Volume);
            return builder.ToString();

        }
    }
}
