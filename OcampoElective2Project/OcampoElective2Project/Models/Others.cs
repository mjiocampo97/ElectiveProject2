using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OcampoElective2Project.Helpers;
using SQLite;
using Xamarin.Forms;

namespace OcampoElective2Project.Models
{
    [Table("Others")]
    public class Others : OcampoElective2ProjectViewModel
    {

    //    public ObservableCollection<Others> OthersList = new ObservableCollection<Others>();
        
        public string Name { get; set; }

        public double Price { get; set; }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
