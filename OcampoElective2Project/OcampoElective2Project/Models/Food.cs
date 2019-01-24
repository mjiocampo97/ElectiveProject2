using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OcampoElective2Project.Helpers;
using SQLite;

namespace OcampoElective2Project.Models
{
    public class Food : OcampoElective2ProjectViewModel
    {
        public ObservableCollection<Food> FoodList = new ObservableCollection<Food>();

        public string NameOfFood { get; set; }
        public double Price { get; set; }
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}
