using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLabs.Tourism
{
    [Table("Attractions")]
    public class Attraction
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int AttrId { get; set; }
        public string Name { get; set; }
        //public int Volume { get; set; }

        //public string Measur { get; set; }

        [Indexed]
        public int TourId { get; set; }

        public override string ToString()
        {
            return Name;
            //return Name + "  " + Volume + Measur;
        }
    }
}
