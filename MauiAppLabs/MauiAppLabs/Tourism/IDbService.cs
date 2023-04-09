using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLabs.Tourism
{
    public interface IDbService
    {
        IEnumerable<TouristRoutes> GetAllTouristRoutes();
        IEnumerable<Attraction> GetTouristRoutesAttraction(int id);
        void Init();
    }
}
