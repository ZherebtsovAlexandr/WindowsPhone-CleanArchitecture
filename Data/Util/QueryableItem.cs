using System;

namespace Data.Util
{
    public class QueryableItem<T>
    {
        public IObservable<T> Subject { get; set; }
        public string RawSql { get; set; }        
    }
}
