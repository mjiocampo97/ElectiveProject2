using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OcampoElective2Project.Helpers;
using SQLite;

namespace OcampoElective2Project.Models
{
    [Table("Clothes")]
    public class Clothes
    {
     //   public ObservableCollection<Clothes> ClothesList = new ObservableCollection<Clothes>();
        public string Name { get; set; }
        public double Price { get; set; }
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int UserId { get; set; }

    }
}
