using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace OcampoElective2Project.Models
{
    [Table("Income")]
    public class Income
    {
        public string Name{ get; set; }
        public double IncomeMoney { get; set; }
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
