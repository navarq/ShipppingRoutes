using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingRoutes
{
    public struct Route
    {
        private int Days;
        private City City;
        public Route(City city, int days)
        {
            City = city;
            Days = days;
        }

        public City GetCity()
        {
            return City;
        }

        public int GetDays()
        {
            return Days;
        }
    }
}
