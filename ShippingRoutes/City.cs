using System;
using System.IO;

namespace ShippingRoutes
{
    public class City
    {
        public static City[] RootCities;
        public Route[] Connections;
        private string CityName;

        public City(string city)
        {
            Connections = null;
            CityName = city;
        }

        public string GetCityName()
        {
            return CityName;
        }
    }
}
