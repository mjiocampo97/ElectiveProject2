using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OcampoElective2Project.Helpers;
using SQLite;

namespace OcampoElective2Project.Models
{
    [Table("Transportation")]
    public class Transportation : OcampoElective2ProjectViewModel
    {
    //    public ObservableCollection<Transportation> TransporationList = new ObservableCollection<Transportation>();
        public string Name { get; set; }
        public double Price { get; set; }
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
