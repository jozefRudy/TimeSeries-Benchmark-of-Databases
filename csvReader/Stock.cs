using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvReader
{
    public class Stock: IEnumerable
    {

        private SortedList<DateTime, StockDay> _data;

        public Stock()
        {
            _data = new SortedList<DateTime, StockDay>();
        }

        public void AddDay(StockDay day)
        {
            _data[day.Date] = day;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            
            return _data.GetEnumerator();
        }

        public StockDay this[DateTime date]
        {
            get { return this._data[date]; }
            set { this._data[date] = value; }
        }

        public IEnumerable<StockDay> Values => _data.Values;
    }
}
