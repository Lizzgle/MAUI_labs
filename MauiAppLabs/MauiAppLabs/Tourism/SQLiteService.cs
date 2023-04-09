using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLabs.Tourism
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection Database;

        public SQLiteService()
        {

        }

        public IEnumerable<TouristRoutes> GetAllTouristRoutes()
        {
            Init();

            return Database.Table<TouristRoutes>();
        }

        public IEnumerable<Attraction> GetTouristRoutesAttraction(int id)
        {
            Init();

            return Database.Table<Attraction>().Where(t => t.TourId == id);
        }

        public void Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            Database.CreateTable<TouristRoutes>();
            Database.CreateTable<Attraction>();

            AddTouristRoutes();
            AddAttraction();
        }

        public void Clear()
        {
            Database.DropTable<TouristRoutes>();
            Database.DropTable<Attraction>();
        }

        private void AddTouristRoutes()
        {
            Database.InsertOrReplace(new TouristRoutes
            {
                Name = "Германия",
                Id = 1,
                Description = "Германия — это высокие Альпы, баварские деревушки и холмы, " +
                "старинные замки с башнями, речные долины с зелеными лугами, " +
                "средневековые городки и высокоиндустриальные города, " +
                "сказки братьев Гримм, самобытные традиции и всем известная немецкая дисциплина.",
                Price = 12
            });

            Database.InsertOrReplace(new TouristRoutes
            {
                Name = "Италия",
                Id = 2,
                Description = "Италия — одна из самых романтичных и посещаемых стран мира. " +
                "Каждый уголок этой страны неповторим и уникален. " +
                "Италия — муза для художников и поэтов, ее воздух пропитан атмосферой творчества и свободы.",
                Price = 18
            });
        }

        private void AddAttraction()
        {
            Database.InsertOrReplace(new Attraction
            {
                AttrId = 1,
                TourId = 1,
                Name = "Берлин"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 2,
                TourId = 1,
                Name = "Кёльн"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 3,
                TourId = 1,
                Name = "Дрезден"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 4,
                TourId = 1,
                Name = "Гамбург"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 5,
                TourId = 1,
                Name = "Франкфурт-на-Майне"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 6,
                TourId = 1,
                Name = "Рим"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 7,
                TourId = 2,
                Name = "Милан"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 8,
                TourId = 2,
                Name = "Венеция"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 9,
                TourId = 2,
                Name = "Генуя"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 10,
                TourId = 2,
                Name = "Болонья"
            });

            Database.InsertOrReplace(new Attraction
            {
                AttrId = 11,
                TourId = 2,
                Name = "Пиза"
                //Measur = "г",
                //Volume = 60
            });
        }
    }
}
