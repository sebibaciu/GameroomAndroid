using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Gameroom.Models 
{
 public class ReviewList
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}
}
