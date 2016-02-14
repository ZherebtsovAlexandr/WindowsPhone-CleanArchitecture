using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqLite
{
    public interface IKeyedTable<T>
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        T Id { get; set; }
    }
}
