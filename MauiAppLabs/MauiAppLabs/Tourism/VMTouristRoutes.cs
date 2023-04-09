
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLabs.Tourism
{
    public class VMTouristRoutes : INotifyPropertyChanged
    {
        private List<TouristRoutes> cocktails;
        public List<TouristRoutes> TouristRoutes
        {
            get => cocktails;
            set
            {
                if (cocktails != value)
                {
                    cocktails = value;
                    OnPropertyChanged();
                }
            }
        }

        private IEnumerable<Attraction> ingredients;
        public IEnumerable<Attraction> Attractions
        {
            get => ingredients;
            set
            {
                if (ingredients != value)
                {
                    ingredients = value;
                    OnPropertyChanged();
                }
            }
        }

        private IDbService _db;

        public VMTouristRoutes(IDbService db)
        {
            _db = db;
            _db.Init();
            TouristRoutes = _db.GetAllTouristRoutes().ToList();
        }

        private string output;

        public string Output
        {
            get => output;
            set
            {
                if (output != value)
                {
                    output = value;
                    OnPropertyChanged();
                }
            }
        }

        public void ChangedCocktail(int id)
        {
            Output = "Описание:\n" + TouristRoutes[id - 1].Description +
                "Цена: " + TouristRoutes[id - 1].Price.ToString() + "\nИнгредиенты:\n";

            Attractions = _db.GetTouristRoutesAttraction(id);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
