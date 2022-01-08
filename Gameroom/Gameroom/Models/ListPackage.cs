using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Gameroom.Models
{
    public class ListPackage
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ReviewList))]
        public int ReviewListID { get; set; }
        public int PackageID { get; set; }
    }
}
