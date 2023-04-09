using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TableAttribute = SQLite.TableAttribute;

namespace MauiAppLabs.Tourism
{
    [Table("TouristRoutes")]
    public class TouristRoutes
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return Name + "\n" +
                Description + "\n" +
                Price;
        }
    }
}
