using Data.SqLite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    [Table("User")]
    public class UserEntity : IKeyedTable<int>
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Age")]
        public int Age { get; set; }
    }
}
